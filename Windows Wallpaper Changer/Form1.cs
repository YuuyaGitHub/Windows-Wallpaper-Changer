using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Windows_Wallpaper_Changer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("User32.DLL")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);
        public static uint SPI_SETDESKWALLPAPER = 0x0014;


        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "壁紙ファイル|*.jpg;*.jpeg;*.bmp;*.dib;*.png;*.jfif;*.jpe;*.gif;*.tif;*.tiff;*.wdp;*.heic;*.heif;*.heics;*.heifs;*.hif;*.avci;*.avcs;*.avif;*.avifs";
            ofd.FilterIndex = 1;
            ofd.Title = "壁紙の選択";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetWallpaper();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetWallpaper()
        {
            String sName = textBox1.Text;
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, sName, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetWallpaper();
            this.Close();
        }
    }
}
