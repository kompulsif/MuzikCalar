using System;
using System.Windows.Forms;

namespace MuzikOynaticisi
{
    public partial class YenidenAdlandirKutucuk : Form
    {
        public string yeniAdi = null;
        public YenidenAdlandirKutucuk()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listeYeniAd.Text.Trim().Length > 2) {
                yeniAdi = listeYeniAd.Text.Trim();
                this.Close();
            } else { MessageBox.Show("Liste adı en az 3 karakter olmalıdır"); }
        }
    }
}
