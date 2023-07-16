using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MuzikOynaticisi
{
    public partial class BilgiGoster : Form
    {
        private string mesaj;
        public BilgiGoster(string mesaj)
        {
            InitializeComponent();
            this.mesaj = mesaj;
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HT_CAPTION = 0x0002;

        private void BilgiGoster_Load(object sender, EventArgs e)
        {
            bilgi.Text = mesaj;
            bilgi.SelectionStart = mesaj.Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
