using CSCore.SoundOut;
using MuzikOynaticisi;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Muziklerim : Form
    {
        private CalarKisim _form1;
        private string calismaDizini = AppDomain.CurrentDomain.BaseDirectory;
        public Muziklerim(CalarKisim form1)
        {
            InitializeComponent();
            this._form1 = form1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void YeniSatirEkle(string sutun0, string sutun1, string sutun2)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell hucre0 = new DataGridViewTextBoxCell();
            hucre0.Value = sutun0;
            row.Cells.Add(hucre0);

            DataGridViewTextBoxCell hucre1 = new DataGridViewTextBoxCell();
            hucre1.Value = sutun1;
            row.Cells.Add(hucre1);

            DataGridViewTextBoxCell hucre2 = new DataGridViewTextBoxCell();
            hucre2.Value = sutun2;
            row.Cells.Add(hucre2);

            dgwMuziklerim.Rows.Add(row);
        }
        private void SatirYuksekligiAyarla(int startIndex, int endIndex, int rowHeight)
        {
            for (int rowIndex = startIndex; rowIndex <= endIndex; rowIndex++)
            {
                dgwMuziklerim.Rows[rowIndex].Height = rowHeight + 5;
                dgwMuziklerim.Rows[rowIndex].DefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 14, FontStyle.Bold);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgwMuziklerim.Columns.Add("Index", "Index");
            dgwMuziklerim.Columns.Add("Yolu", "Müzik Yolu");
            dgwMuziklerim.Columns.Add("Adi", "Müzik Adı");
            dgwMuziklerim.Columns[0].Visible = false;
            dgwMuziklerim.Columns[1].Visible = false;
            dgwMuziklerim.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i < _form1.muzikListesi.Count; i++)
            {
                string muzikYolu = (string)_form1.muzikListesi[i];
                YeniSatirEkle(i.ToString(), muzikYolu, Path.GetFileNameWithoutExtension(muzikYolu));
            }
            SatirYuksekligiAyarla(0, dgwMuziklerim.RowCount - 1, 50);
            label1.Text = $"MÜZİKLERİM ({dgwMuziklerim.Rows.Count})";
            if (dgwMuziklerim.Rows.Count == 0) _form1.suankiMuzik = -1;
        }

        private void dgwMuziklerim_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwMuziklerim.SelectedRows.Count > 0)
            {
                _form1.secileniCal(int.Parse((string)dgwMuziklerim.SelectedRows[0].Cells[0].Value));
            }
        }

        private void listedenKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwMuziklerim.SelectedRows.Count > 0)
            {
                while (true)
                {
                    try
                    {
                        if (Directory.Exists(calismaDizini + "\\Oynatma Listelerim"))
                        {
                            ArrayList oynatmaListeleri = new ArrayList();
                            string yolu = dgwMuziklerim.SelectedRows[0].Cells[1].Value.ToString();
                            if (yolu == (string)_form1.muzikListesi[_form1.suankiMuzik])
                            {
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
                            }
                            File.Delete(yolu);
                            dgwMuziklerim.Rows.Clear();
                            dgwMuziklerim.Columns.Clear();
                            _form1.muzikListesi.Remove(yolu);
                            Form2_Load(null, null);
                            if (dgwMuziklerim.Rows.Count > 0) { _form1.suankiMuzik = 0; }
                            _form1.muzikAdi.Text = "";
                            _form1.suankiZaman.Text = "00:00";
                            _form1.bitisZamani.Text = "00:00";
                            _form1.tBar.Value = 0;
                            ListeleriDuzenle ld = new ListeleriDuzenle(new CalarKisim());

                            string[] butunDosyalar = Directory.GetFiles(calismaDizini + "\\Oynatma Listelerim\\");
                            foreach (string dosya in butunDosyalar)
                            {
                                string uzanti = Path.GetExtension(dosya).ToLower();
                                if (uzanti == ".txt")
                                    ListeleriDuzenle.seciliSarkiyiKaldir(dosya, yolu, true);
                            }
                            _form1.SonrakiSarkiButton_Click(null, null);
                            CalarKisim.Bilgilendir("Seçili şarkı her yerden silindi!");
                        }
                        else
                        {
                            try
                            {
                                Directory.CreateDirectory(calismaDizini + "\\Oynatma Listelerim");
                                continue;
                            }
                            catch
                            {
                                CalarKisim.Bilgilendir("Oynatma listesi dizinlerine erişilemiyor. Silinecek şarkı oynatma listelerinden silinemedi, lütfen daha sonra yönetici izinleri ile tekrar deneyiniz");
                            }
                        }
                    }
                    catch
                    {
                        CalarKisim.Bilgilendir("Programı yönetici izinleri ile tekrar çalıştırın");
                    }
                    break;
                }
            }
        }
    }
}
