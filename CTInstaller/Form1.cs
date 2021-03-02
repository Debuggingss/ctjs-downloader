using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace CTInstaller
{
    public partial class Form1 : Form
    {
        public static string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Downloading Forge...";
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    new Uri("https://files.minecraftforge.net/maven/net/minecraftforge/forge/1.8.9-11.15.1.2318-1.8.9/forge-1.8.9-11.15.1.2318-1.8.9-installer-win.exe"),
                    desktop + "\\FORGE_INSTALLER.exe"
                );
                wc.DownloadFileCompleted += wc_DownloadFinished1;
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Downloading ctjs...";
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    new Uri("https://github.com/ChatTriggers/ChatTriggers/releases/download/1.3.1/ctjs-1.3.1-1.8.9.jar"),
                    appdata + "\\.minecraft\\mods\\ctjs-1.3.1-1.8.9.jar"
                );
                wc.DownloadFileCompleted += wc_DownloadFinished2;
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        void wc_DownloadFinished1(object sender, AsyncCompletedEventArgs e)
        {
            label1.Text = "Forge Downloaded!";
            Process.Start(desktop + "\\FORGE_INSTALLER.exe");
            MessageBox.Show("Click 'OK' in the Forge Installer window!");
        }

        void wc_DownloadFinished2(object sender, AsyncCompletedEventArgs e)
        {
            label1.Text = "ctjs Downloaded!";
            MessageBox.Show("Now you should be ready to launch forge!");
        }
    }
}
