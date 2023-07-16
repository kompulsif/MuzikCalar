using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class CalmaGecmisi : Form
    {
        private CancellationTokenSource tokenSource1;
        private CancellationToken token;
        private CalarKisim _form1;
        private bool t = true;
        private int i = 0;
        private Thread thr;
        private Thread tt;
        public CalmaGecmisi(CalarKisim form1)
        {
            InitializeComponent();
            this._form1 = form1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                t = false;
                tokenSource1?.Cancel();
                ArrayList tlist = new ArrayList { tt, thr };
                foreach (Thread tm in tlist)
                {
                    try
                    {
                        tm.Abort();
                    }
                    catch { }
                }
                
                this.Close();
            } catch { this.Close(); }
        }

        private void YeniSatirEkleKontrollu(string sutun0, string sutun1, string sutun2)
        {
            if (dgwCalmaGecmisim.InvokeRequired)
            {
                dgwCalmaGecmisim.Invoke((MethodInvoker)delegate
                {
                    YeniSatirEkle(sutun0, sutun1, sutun2);
                });
            }
            else
            {
                YeniSatirEkle(sutun0, sutun1, sutun2);
            }
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
            try
            {
                dgwCalmaGecmisim.Rows.Add(row);
            } catch { t = false; }
        }

        private void SatirYuksekligiAyarlaKontrollu(int basIndex, int bitIndex, int satirYukseklik)
        {
            if (dgwCalmaGecmisim.InvokeRequired)
            {
                dgwCalmaGecmisim.Invoke((MethodInvoker)delegate
                {
                    SatirAyarla(basIndex, bitIndex, satirYukseklik);
                });
            }
            else
            {
                SatirAyarla(basIndex, bitIndex, satirYukseklik);
            }
        }

        private void SatirAyarla(int basIndex, int bitIndex, int satirYukseklik)
        {
            for (int rowIndex = basIndex; rowIndex <= bitIndex; rowIndex++)
            {
                dgwCalmaGecmisim.Rows[rowIndex].Height = satirYukseklik;
                dgwCalmaGecmisim.Rows[rowIndex].DefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 14, FontStyle.Bold);
            }
        }

        private void dgwDoldur()
        {
            dgwCalmaGecmisim.Columns.Add("Index", "Index");
            dgwCalmaGecmisim.Columns.Add("Yolu", "Müzik Yolu");
            dgwCalmaGecmisim.Columns.Add("Adi", "Müzik Adı");
            dgwCalmaGecmisim.Columns[0].Visible = false;
            dgwCalmaGecmisim.Columns[1].Visible = false;
            dgwCalmaGecmisim.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (;i < CalarKisim.calmaGecmisi.Count; i++)
            {
                string muzikYolu = CalarKisim.calmaGecmisi[i][0];
                YeniSatirEkleKontrollu(CalarKisim.calmaGecmisi[i][1].ToString(), muzikYolu, Path.GetFileNameWithoutExtension(muzikYolu));
            }
            SatirYuksekligiAyarlaKontrollu(0, dgwCalmaGecmisim.RowCount - 1, 50);
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            dgwDoldur();
            tokenSource1 = new CancellationTokenSource();
            token = tokenSource1.Token;
            thr = new Thread(() =>
            {
                while (!token.IsCancellationRequested && t)
                {
                    Thread.Sleep(1000);
                    tt = new Thread(() =>
                    {
                        for (; i < CalarKisim.calmaGecmisi.Count; i++)
                        {
                            string muzikYolu = CalarKisim.calmaGecmisi[i][0];
                            YeniSatirEkleKontrollu(CalarKisim.calmaGecmisi[i][1].ToString(), muzikYolu, Path.GetFileNameWithoutExtension(muzikYolu));
                        }
                        SatirYuksekligiAyarlaKontrollu(0, dgwCalmaGecmisim.RowCount - 1, 50);
                    });
                    tt.IsBackground = true;
                    tt.Start();
                }
            });
            thr.IsBackground = true;
            thr.Start();
        }

        private void dgwCalmaGecmisim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwCalmaGecmisim.SelectedRows.Count > 0)
            {
                _form1.secileniCal(int.Parse((string)dgwCalmaGecmisim.SelectedRows[0].Cells[0].Value));
            }
        }
    }
}
