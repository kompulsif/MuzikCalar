using PlayerUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using CSCore.SoundOut;
using System.Drawing;

namespace MuzikOynaticisi
{
    public partial class ListeleriDuzenle : Form
    {
        private string calismaDizini = AppDomain.CurrentDomain.BaseDirectory;
        private string eskiYol;
        private Dictionary<string, ArrayList> icerikler = new Dictionary<string, ArrayList>();
        private CalarKisim _form1;
        public ListeleriDuzenle(CalarKisim form1)
        {
            InitializeComponent();
            dgwListelerim.Columns.Add("Yolu", "Liste Yolu");
            dgwListelerim.Columns.Add("Adi", "Liste Adı");
            dgwListelerim.Columns[0].Visible = false;
            dgwListeIcerik.Columns.Add("Yolu", "Icerik Yolu");
            dgwListeIcerik.Columns.Add("Adi", "Icerik Adı");
            dgwListeIcerik.Columns[0].Visible = false;
            this._form1 = form1;
        }

        private void ListeleriDuzenle_Load(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(calismaDizini + "\\Oynatma Listelerim"))
                {
                    string[] butunDosyalar = Directory.GetFiles(calismaDizini + "\\Oynatma Listelerim\\");
                    foreach (string dosya in butunDosyalar)
                    {
                        string uzanti = Path.GetExtension(dosya).ToLower();
                        if (uzanti == ".txt")
                        {
                            YeniSatirEkleKontrollu(dgwListelerim, dosya, Path.GetFileNameWithoutExtension(dosya));
                            IcerikleriEkle(dosya);
                        }
                    }
                    SatirYuksekligiAyarlaKontrollu(dgwListelerim, 0, dgwListelerim.RowCount - 1, 50);
                    label2.Text = $"Listelerim ({dgwListelerim.Rows.Count})";
                }
                else {
                    try
                    {
                        Directory.CreateDirectory(calismaDizini + "\\Oynatma Listelerim");
                    } catch {
                        CalarKisim.Bilgilendir("Oynatma listesi dizinine erişilemiyor, başka bir program tarafından kullanılıyor veya yönetici izinleriyle tekrar deneyiniz");
                    }
                }
            }
            catch
            {
                CalarKisim.Bilgilendir("Programı yönetici izinleri ile tekrar çalıştırın");
            }
        }
        
        private void IcerikleriEkle(string yol)
        {
            try
            {
                using (StreamReader sr = new StreamReader(yol))
                {
                    icerikler[yol] = new ArrayList();
                    string satir;
                    while ((satir = sr.ReadLine()) != null)
                    {
                        if (satir.Trim() != "")
                            icerikler[yol].Add(satir.Trim());
                    }
                }
            }
            catch
            {
                CalarKisim.Bilgilendir("Erişim hatası! Lütfen yönetici izinleri ile tekrar deneyiniz");
            }
        }

        private void YeniSatirEkleKontrollu(DataGridView dgw, string sutun0, string sutun1)
        {
            if (dgw.InvokeRequired)
            {
                dgw.Invoke((MethodInvoker)delegate
                {
                    YeniSatirEkle(dgw, sutun0, sutun1);
                });
            }
            else
            {
                YeniSatirEkle(dgw, sutun0, sutun1);
            }
        }

        private void YeniSatirEkle(DataGridView dgw, string sutun0, string sutun1)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell hucre0 = new DataGridViewTextBoxCell();
            hucre0.Value = sutun0;
            row.Cells.Add(hucre0);

            DataGridViewTextBoxCell hucre1 = new DataGridViewTextBoxCell();
            hucre1.Value = sutun1;
            row.Cells.Add(hucre1);

            dgw.Rows.Add(row);
        }

        private void SatirYuksekligiAyarlaKontrollu(DataGridView dgw, int basIndex, int bitIndex, int satirYukseklik)
        {
            if (dgw.InvokeRequired)
            {
                dgw.Invoke((MethodInvoker)delegate
                {
                    SatirAyarla(dgw, basIndex, bitIndex, satirYukseklik);
                });
            }
            else
            {
                SatirAyarla(dgw, basIndex, bitIndex, satirYukseklik);
            }
        }

        private void SatirAyarla(DataGridView dgw, int basIndex, int bitIndex, int satirYukseklik)
        {
            for (int rowIndex = basIndex; rowIndex <= bitIndex; rowIndex++)
            {
                dgw.Rows[rowIndex].Height = satirYukseklik + 5;
                dgw.Rows[rowIndex].DefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 14, FontStyle.Bold);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listeyiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwListelerim.SelectedRows.Count > 0)
            {
                try
                {
                    string yolu = dgwListelerim.SelectedRows[0].Cells[0].Value.ToString();
                    File.Delete(yolu);
                    dgwListelerim.Rows.RemoveAt(dgwListelerim.SelectedRows[0].Index);
                    icerikler.Remove(yolu);
                    label2.Text = $"Listelerim ({dgwListelerim.Rows.Count})";
                    dgwListeIcerik.Rows.Clear();
                    label3.Text = $"Liste İçeriği (0)";
                    CalarKisim.Bilgilendir("Oynatma Listeniz silindi!");
                } catch {
                    CalarKisim.Bilgilendir("Oynatma Listeniz silinemedi lütfen daha sonra yönetici izinleri ile tekrar deneyiniz");
                }
            }
        }

        private void yenidenAdlandirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwListelerim.SelectedRows.Count > 0)
            {
                eskiYol = dgwListelerim.SelectedRows[0].Cells[0].Value.ToString();
                try
                {
                    YenidenAdlandirKutucuk k = new YenidenAdlandirKutucuk();
                    k.ShowDialog();
                    if (k.yeniAdi != null)
                    {
                        string yeni = Path.GetDirectoryName(eskiYol) + "\\" + k.yeniAdi + ".txt";
                        File.Move(eskiYol, yeni);
                        dgwListelerim.Rows.Clear();
                        ListeleriDuzenle_Load(null, null);
                        CalarKisim.Bilgilendir("Oynatma Listeniz yeniden adlandırıldı!");
                    }
                }
                catch
                {
                    CalarKisim.Bilgilendir("Oynatma Listeniz yeniden adlandırılamadı lütfen daha sonra yönetici izinleri ile tekrar deneyin");
                }
            }
        }

        private void dgwListelerim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgwListeIcerik.Rows.Clear();
            Thread.Sleep(300);
            string seciliYol = dgwListelerim.SelectedRows[0].Cells[0].Value.ToString();
            foreach (string s in icerikler[seciliYol])
            {
                YeniSatirEkleKontrollu(dgwListeIcerik, s, Path.GetFileNameWithoutExtension(s));
            }
            SatirYuksekligiAyarlaKontrollu(dgwListeIcerik, 0, dgwListeIcerik.Rows.Count - 1, 50);
            label3.Text = $"Liste İçeriği ({dgwListeIcerik.Rows.Count})";
        }

        public static bool seciliSarkiyiKaldir(string oynatmaListesi, string sarkisi, bool tarama = false)
        {
            List<string> satirlar = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(oynatmaListesi))
                {
                    string satir;
                    while ((satir = sr.ReadLine()) != null)
                    {
                        if (satir != "")
                            satirlar.Add(satir.Trim());
                    }
                }
            }
            catch { CalarKisim.Bilgilendir("Oynatma listesine ulaşılamadı!"); }
            try
            {
                int t = -1;
                for (int i = 0; i < satirlar.Count; i++)
                {
                    if (satirlar[i] == sarkisi)
                    { 
                        t = i;
                        break; 
                    }
                }
                if (t != -1)
                {
                    satirlar.RemoveAt(t);
                    using (StreamWriter sw = new StreamWriter(oynatmaListesi))
                    {
                        foreach (string satir in satirlar)
                        {
                            sw.WriteLine(satir);
                        }
                    }
                    return true;
                }
                else { if (!tarama) CalarKisim.Bilgilendir("Silincek şarkı oynatma listesinde bulunamadı"); }
            } catch { CalarKisim.Bilgilendir("Oynatma listesinde düzenleme yapılamadı!"); }
            return false;
        }

        private void listedenKaldirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            if (dgwListeIcerik.SelectedRows.Count > 0)
            {
                string konumu = dgwListelerim.SelectedRows[0].Cells[0].Value.ToString();
                string sarki = dgwListeIcerik.SelectedRows[0].Cells[0].Value.ToString();
                if (seciliSarkiyiKaldir(konumu, sarki))
                {
                    dgwListeIcerik.Rows.RemoveAt(dgwListeIcerik.SelectedRows[0].Index);
                    icerikler[konumu].Remove(sarki);
                    label3.Text = $"Liste İçeriği ({dgwListeIcerik.Rows.Count})";
                    CalarKisim.Bilgilendir("Seçili şarkı kaldırıldı!");
                }
            }
        }

        private void listeyiCalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            ArrayList x = icerikler[dgwListelerim.SelectedRows[0].Cells[0].Value.ToString()];
            if (x.Count > 0)
            {
                _form1.muzikListesi = x;
                _form1.suankiMuzik = 0;
                _form1.oynatmaAcik = true;
                if (_form1.calinanMuzik != null && _form1.calinanMuzik.PlaybackState == PlaybackState.Playing)
                {
                    _form1.calinanMuzik.Stop();
                    _form1.calinanMuzik.Dispose();
                }
                if (_form1.muzikKaynak != null)
                {
                    _form1.muzikKaynak.Dispose();
                }
                _form1.oynatilyor = false;
                _form1.SonrakiSarkiButton_Click(null, null);

            } else { CalarKisim.Bilgilendir("Çalma listenizde müzik bulunmuyor"); }
        }
    }
}
