using PlayerUI;
using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace MuzikOynaticisi
{
    public partial class OynatmaListesiEkle : Form
    {
        private string listeKlasorYolu = AppDomain.CurrentDomain.BaseDirectory + "\\Oynatma Listelerim\\";
        private CalarKisim _form1;
        public OynatmaListesiEkle(CalarKisim form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void YeniSatirEkle(DataGridView dgw, string sutun0, string sutun1, string sutun2)
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

            dgw.Rows.Add(row);
        }
        private void SatirYuksekligiAyarla(DataGridView dgw, int startIndex, int endIndex, int rowHeight)
        {
            for (int rowIndex = startIndex; rowIndex <= endIndex; rowIndex++)
            {
                dgw.Rows[rowIndex].Height = rowHeight + 5;
                dgw.Rows[rowIndex].DefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 14, FontStyle.Bold);
            }
        }

        private void dgwMuzikler_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dgwMuzikler.SelectedRows[0];
            string yol = satir.Cells[1].Value.ToString();
            bool k = true;
            foreach (DataGridViewRow s in dgwListe.Rows)
            {
                if (s.Cells[1].Value.ToString() == yol)
                {
                    CalarKisim.Bilgilendir("Bu şarkı listede mevcuttur");
                    k = false;
                    break;
                }
            }
            if (k)
            {
                YeniSatirEkle(dgwListe, "", yol, satir.Cells[2].Value.ToString());
                SatirYuksekligiAyarla(dgwListe, 0, dgwListe.RowCount - 1, 50);
            }
        }

        private void OynatmaListesiEkle_Load(object sender, EventArgs e)
        {
            dgwMuzikler.Columns.Add("Index", "Index");
            dgwMuzikler.Columns.Add("Yolu", "Müzik Yolu");
            dgwMuzikler.Columns.Add("Adi", "Müzik Adı");
            dgwMuzikler.Columns[0].Visible = false;
            dgwMuzikler.Columns[1].Visible = false;
            dgwMuzikler.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgwListe.Columns.Add("Index", "Index");
            dgwListe.Columns.Add("Yolu", "Müzik Yolu");
            dgwListe.Columns.Add("Adi", "Müzik Adı");
            dgwListe.Columns[0].Visible = false;
            dgwListe.Columns[1].Visible = false;
            dgwListe.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i < _form1.muzikListesi.Count; i++)
            {
                string muzikYolu = (string)_form1.muzikListesi[i];
                YeniSatirEkle(dgwMuzikler, i.ToString(), muzikYolu, Path.GetFileNameWithoutExtension(muzikYolu));
            }
            SatirYuksekligiAyarla(dgwMuzikler, 0, dgwMuzikler.RowCount - 1, 50);
        }

        private void listedenKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwListe.SelectedRows.Count > 0)
            {
                dgwListe.Rows.RemoveAt(dgwListe.SelectedRows[0].Index);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tamPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            string[] yasakliKarakterler = { "<", ">", ":", "\"", "/", "\\", "|", "?", "*" };
            bool tamam = true;
            foreach (string karakter in yasakliKarakterler)
            {
                if (ListeAdi.Text.Contains(karakter))
                {
                    CalarKisim.Bilgilendir("Oynatma listeniz şu karakterleri içermemelidir\n < > : \" / \\ | ? *");
                    tamam = false;
                    break;
                }
            }

            if (tamam)
            {

                if (dgwListe.Rows.Count <= 0) CalarKisim.Bilgilendir("Listenizde şarkı bulunamadı");
                else if (ListeAdi.Text.Trim().Length < 3) CalarKisim.Bilgilendir("Listeniz en az 3 karakter olmalıdır");
                else
                {
                    while (true)
                    {
                        if (!Directory.Exists(listeKlasorYolu))
                        {
                            try
                            {
                                Directory.CreateDirectory(listeKlasorYolu);
                            }
                            catch
                            {
                                CalarKisim.Bilgilendir("Oynatma Listeniz oluşturulurken bir hata meydana geldi, lütfen yönetici izinler ile programı tekrar başlatınız");
                            }
                        }
                        try
                        {
                            string dosya = AppDomain.CurrentDomain.BaseDirectory + $"\\Oynatma Listelerim\\{ListeAdi.Text.Trim()}.txt";
                            if (!File.Exists(dosya))
                            {
                                try
                                {
                                    using (StreamWriter yazDosya = new StreamWriter(dosya))
                                    {
                                        foreach (DataGridViewRow s in dgwListe.Rows)
                                            yazDosya.Write(s.Cells[1].Value.ToString() + " \n");
                                    }
                                    ListeAdi.Text = "";
                                    CalarKisim.Bilgilendir("Oynatma Listeniz Oluşturuldu!");
                                }
                                catch
                                {
                                    CalarKisim.Bilgilendir("Listeniz oluşturulurken bir hata meydana geldi, lütfen yönetici izinleri ile tekrar deneyiniz");
                                }

                            }
                            else { CalarKisim.Bilgilendir("Bu liste adı kullanılıyor"); }
                        }
                        catch
                        {
                            CalarKisim.Bilgilendir("Listeniz oluşturulurken bir hata meydana geldi, lütfen yönetici izinleri ile tekrar deneyiniz");
                        }
                        break;
                    }
                }
            }
        }
    }
}
