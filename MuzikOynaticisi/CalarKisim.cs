using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using System.Collections.Generic;
using System.Linq;
using MuzikOynaticisi;
using System.Diagnostics;

namespace PlayerUI
{
    public partial class CalarKisim : Form
    {
        
        public static List<List<string>> calmaGecmisi = new List<List<string>>();
        private string calismaDizini = AppDomain.CurrentDomain.BaseDirectory;
        public ArrayList muzikListesi = new ArrayList();
        private CancellationTokenSource tokenSource1;
        private bool guncelleniyor = false;
        private CancellationToken token;
        public bool oynatmaAcik = false;
        private Form aktifForm = null;
        public IWaveSource muzikKaynak;
        public ISoundOut calinanMuzik;
        public int suankiMuzik = -1;
        public Label suankiZaman;
        public Label bitisZamani;
        public bool oynatilyor;
        public Label muzikAdi;
        private bool karisik;
        public TrackBar tBar;


        public CalarKisim()
        {
            InitializeComponent();
            muzikAdi = this._muzikAdi;
            suankiZaman = this._suankiZaman;
            bitisZamani = this._bitisZamani;
            tBar = this.trackBar;
            altMenuyuGizle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(calismaDizini + "\\Muziklerim"))
                {
                    string[] butunDosyalar = Directory.GetFiles(calismaDizini + "\\Muziklerim\\");
                    foreach (string dosya in butunDosyalar)
                    {
                        string uzanti = Path.GetExtension(dosya).ToLower();
                        if (uzanti == ".wav" || uzanti == ".mp3" || uzanti == ".aac" || uzanti == ".flac" || uzanti == ".ogg" || uzanti == ".wma")
                            muzikListesi.Add(dosya);
                    }
                    if (muzikListesi.Count > 0) { suankiMuzik = 0; }
                }
                else { Directory.CreateDirectory(calismaDizini + "\\Muziklerim"); }

                if (!Directory.Exists(calismaDizini + "\\Oynatma Listelerim\\"))
                {
                    try
                    {
                        Directory.CreateDirectory(calismaDizini + "\\Oynatma Listelerim\\");
                    }
                    catch
                    {
                        Bilgilendir("Programı yönetici izinleri ile tekrar çalıştırın");
                        Form1_FormClosing(null, null);
                    }
                }
            }
            catch
            {
                Bilgilendir("Programı yönetici izinleri ile tekrar çalıştırın");
                Form1_FormClosing(null, null);
            }


            if (!guncelleniyor)
            {
                this.calinanMuzik = null;
                this.muzikKaynak = null;
                this.oynatilyor = false;
            } else DurdurBaslatButton_Click(null, null);

            trackBar.Minimum = 0;
            trackBar.Maximum = 100;

            if (!guncelleniyor && suankiMuzik != -1)
            {
                Cal();
                calinanMuzik.Pause();
                oynatilyor = false;
            }
        }


        public static void Bilgilendir(string mesaj)
        {
            BilgiGoster bilgilendir = new BilgiGoster(mesaj);
            bilgilendir.ShowDialog();
        }

        private void altMenuyuGizle()
        {
            panelMedyaAltMenu.Visible = false;
            panelListelerAltMenu.Visible = false;
            panelAraclarAltMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                altMenuyuGizle();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMedya_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMedyaAltMenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltFormuAc(new Muziklerim(this));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AltFormuAc(new CalmaGecmisi(this));
        }

        private void btnListeler_Click(object sender, EventArgs e)
        {
            showSubMenu(panelListelerAltMenu);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AltFormuAc(new OynatmaListesiEkle(this));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AltFormuAc(new ListeleriDuzenle(this));
        }

        private void btnAraclar_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAraclarAltMenu);
        }

        private bool UzantiUygunMu(string uzanti)
        {
            string[] desteklenenUzantilar = { ".wav", ".mp3", ".aac", ".flac", ".ogg", ".wma" };
            return Array.IndexOf(desteklenenUzantilar, uzanti) != -1;
        }

        private void YeniMuziklerEkle(List<string> dosyaYollari, string hedefYol)
        {
            foreach (string dosyaYolu in dosyaYollari)
            {
                string uzanti = Path.GetExtension(dosyaYolu);
                if (UzantiUygunMu(uzanti))
                {
                    string kopyalanacakYol = hedefYol + Path.GetFileName(dosyaYolu);
                    try
                    {
                        File.Copy(dosyaYolu, kopyalanacakYol);
                        muzikListesi.Add(kopyalanacakYol);
                    }
                    catch (Exception Ex)
                    {
                        if (Ex.ToString().Contains("'" + kopyalanacakYol + "'" + " already exists"))
                        {
                            Bilgilendir($"{dosyaYolu}\nDosyası hedef klasörde zaten var");
                        }
                        else
                        {
                            Bilgilendir("Kopyalanacak klasör silinmiş veya taşınmış olabilir, kontrol edip tekrar deneyin.");
                        }
                    }
                }
            }
            if (suankiMuzik == -1) suankiMuzik = 0;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ses Dosyaları|*.wav;*.mp3;*.aac;*.flac;*.ogg;*.wma";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] dosyaYollari = openFileDialog.FileNames;
                YeniMuziklerEkle(dosyaYollari.ToList<string>(), $"{calismaDizini}\\Muziklerim\\");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Klasör Seçiniz";
            folderBrowserDialog.SelectedPath = "C:\\";
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string klasorYolu = folderBrowserDialog.SelectedPath;
                List<string> eklenecekDosyalar = new List<string>();
                try
                {
                    string[] butunDosyalar = Directory.GetFiles(klasorYolu);
                    foreach (string dosya in butunDosyalar)
                    {
                        string uzanti = Path.GetExtension(dosya).ToLower();
                        if (uzanti == ".wav" || uzanti == ".mp3" || uzanti == ".aac" || uzanti == ".flac" || uzanti == ".ogg" || uzanti == ".wma")
                            eklenecekDosyalar.Add(dosya);
                    }
                }
                catch
                {
                    Bilgilendir("Programı yönetici izinleri ile tekrar çalıştırın");
                }
                YeniMuziklerEkle(eklenecekDosyalar, $"{calismaDizini}\\Muziklerim\\");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (oynatmaAcik)
            {
                guncelleniyor = true;
                muzikListesi.Clear();
                calmaGecmisi.Clear();
                if (aktifForm != null) aktifForm.Close();
                oynatmaAcik = false;
                Form1_Load(null, null);
                AltFormuAc(new Muziklerim(this));
            }
            else { Bilgilendir("Aktif bir oynatma listesi yok"); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void AltFormuAc(Form altForm)
        {
            if (aktifForm != null) aktifForm.Close();
            aktifForm = altForm;
            altForm.TopLevel = false;
            altForm.FormBorderStyle = FormBorderStyle.None;
            altForm.Dock = DockStyle.Fill;
            panelAltForm.Controls.Add(altForm);
            panelAltForm.Tag = altForm;
            altForm.BringToFront();
            altForm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (calinanMuzik != null && calinanMuzik.PlaybackState == PlaybackState.Playing)
            {
                calinanMuzik.Stop();
                calinanMuzik.Dispose();
            }
            if (muzikKaynak != null)
            {
                muzikKaynak.Dispose();
            }
            Process process = Process.GetCurrentProcess();
            try
            {
                process.Kill();
            }
            catch { Application.Exit(); }
        }

        private void OncesiSarkiButton_Click(object sender, EventArgs e)
        {
            if (suankiMuzik != -1)
            {
                if (calinanMuzik != null && calinanMuzik.PlaybackState == PlaybackState.Playing)
                {
                    calinanMuzik.Stop();
                    calinanMuzik.Dispose();
                }
                if (muzikKaynak != null)
                {
                    muzikKaynak.Dispose();
                }

                if (suankiMuzik > 0)
                    suankiMuzik--;
                else
                    suankiMuzik = muzikListesi.Count - 1;
                Cal();
            }
        }

        public void SonrakiSarkiButton_Click(object sender, EventArgs e)
        {
            if (suankiMuzik != -1)
            {
                if (calinanMuzik != null && calinanMuzik.PlaybackState == PlaybackState.Playing)
                {
                    calinanMuzik.Stop();
                    calinanMuzik.Dispose();
                }
                if (muzikKaynak != null)
                {
                    muzikKaynak.Dispose();
                }
                if (suankiMuzik < muzikListesi.Count - 1)
                    suankiMuzik++;
                else
                    suankiMuzik = 0;
                Cal();
            }
        }

        public void DurdurBaslatButton_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (suankiMuzik != -1 && calinanMuzik != null && muzikKaynak != null)
            {
                if (oynatilyor)
                {
                    try { calinanMuzik.Pause(); }
                    catch {
                        if (calinanMuzik != null && calinanMuzik.PlaybackState == PlaybackState.Playing)
                        {
                            calinanMuzik.Stop();
                            calinanMuzik.Dispose();
                        }
                        if (muzikKaynak != null)
                        {
                            muzikKaynak.Dispose();
                        }
                    }
                    oynatilyor = false;
                }
                else
                {
                    try { calinanMuzik.Play(); }
                    catch {
                        if (calinanMuzik != null && calinanMuzik.PlaybackState == PlaybackState.Playing)
                        {
                            calinanMuzik.Stop();
                            calinanMuzik.Dispose();
                        }
                        if (muzikKaynak != null)
                        {
                            muzikKaynak.Dispose();
                        }
                    }
                    oynatilyor = true;
                }
            }
        }

        private void Cal()
        {
            if (suankiMuzik != -1)
            {
                string yol = muzikListesi[suankiMuzik].ToString();

                try
                {
                    Thread.Sleep(200);
                    muzikKaynak = CodecFactory.Instance.GetCodec(yol);
                    calinanMuzik = new WasapiOut();

                    calinanMuzik.Initialize(muzikKaynak);
                    calinanMuzik.Play();
                    muzikAdi.Text = Path.GetFileNameWithoutExtension(yol);
                    calmaGecmisi.Add(new List<string>() { yol, suankiMuzik.ToString() });
                    TimeSpan ts = muzikKaynak.GetLength();
                    trackBar.Maximum = (int)ts.TotalSeconds;
                    oynatilyor = true;
                    TimeSpan p = TimeSpan.FromSeconds(muzikKaynak.GetLength().TotalSeconds);
                    _bitisZamani.Text = p.ToString(@"hh\:mm\:ss");
                    tokenSource1 = new CancellationTokenSource();
                    token = tokenSource1.Token;
                    Thread updateThread = new Thread(UpdateProgressBar);
                    updateThread.IsBackground = true;
                    updateThread.Start();
                    calinanMuzik.Stopped += BittiKontrol;
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Trim().Contains("File not found"))
                    {
                        string y = (string)muzikListesi[suankiMuzik];
                        if (Directory.Exists(y))
                            Bilgilendir($"{Path.GetFileName(y)}\n Bu şarkı çalınamadı!");
                        else
                        {
                            Bilgilendir($"{Path.GetFileName(y)} dosyası taşınmış veya silinmiş");
                        }
                    }
                    muzikKaynak = null;
                    calinanMuzik = null;
                    oynatilyor = false;
                }
            }
        }

        private void UpdateProgressBar()
        {
            while (!tokenSource1.Token.IsCancellationRequested && calinanMuzik != null && (calinanMuzik.PlaybackState == PlaybackState.Playing || calinanMuzik.PlaybackState == PlaybackState.Paused))
            {
                if (InvokeRequired)
                {
                    try
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            try
                            {
                                token.ThrowIfCancellationRequested();
                                double progress = muzikKaynak.GetPosition().TotalSeconds / muzikKaynak.GetLength().TotalSeconds;
                                trackBar.Value = (int)(progress * trackBar.Maximum);
                                TimeSpan p = TimeSpan.FromSeconds(muzikKaynak.GetPosition().TotalSeconds);
                                _suankiZaman.Text = p.ToString(@"hh\:mm\:ss");
                            }
                            catch {
                                tokenSource1?.Cancel();
                            }
                        });
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch
                    {
                        break;
                    }
                }
                Thread.Sleep(100);
            }
        }


        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (muzikKaynak != null)
            {
                double progress = (double)trackBar.Value / trackBar.Maximum;
                muzikKaynak.SetPosition(TimeSpan.FromSeconds(progress * muzikKaynak.GetLength().TotalSeconds));
            }
        }

        private void BittiKontrol(object sender, PlaybackStoppedEventArgs e)
        {
            if (calinanMuzik == null)
            {
                SonrakiSarkiButton_Click(null, null);
            } else if (calinanMuzik.PlaybackState == PlaybackState.Stopped)
            {
                try { 
                    calinanMuzik.Stop();
                    calinanMuzik.Dispose();
                    muzikKaynak.Dispose();
                    if (!karisik) SonrakiSarkiButton_Click(null, null);
                    else karisikCal();
                } catch { }
            }
        }

        public void secileniCal(int n)
        {
            if (suankiMuzik != -1)
            {
                if (calinanMuzik != null && calinanMuzik.PlaybackState == PlaybackState.Playing)
                {
                    calinanMuzik.Stop();
                    calinanMuzik.Dispose();
                }
                if (muzikKaynak != null)
                {
                    muzikKaynak.Dispose();
                }
                suankiMuzik = n;
                Cal();
            }
        }

        private void karisikCal()
        {
            if (suankiMuzik != -1)
            {
                if (calinanMuzik != null && calinanMuzik.PlaybackState == PlaybackState.Playing)
                {
                    calinanMuzik.Stop();
                    calinanMuzik.Dispose();
                }
                if (muzikKaynak != null)
                {
                    muzikKaynak.Dispose();
                }
                if (muzikListesi.Count > 1)
                {
                    Random r = new Random();
                    int n = suankiMuzik;
                    while (n == suankiMuzik) n = r.Next(muzikListesi.Count - 1);
                    suankiMuzik = n;
                }
                Cal();
            }
        }

        private void karistir_click(object sender, EventArgs e)
        {
            if (karisik)
            {
                karisik = false;
                Bilgilendir("Karışık mod kapalı");
            }
            else
            {
                karisik = true;
                Bilgilendir("Karışık mod açık");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (muzikKaynak != null && calinanMuzik != null)
            {
                trackBar.Value = 0;
                try
                {
                    muzikKaynak.SetPosition(TimeSpan.Zero);
                } catch { }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AltFormuAc(new Muziklerim(this));
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Form1_FormClosing(null, null);
        }
    }
}
