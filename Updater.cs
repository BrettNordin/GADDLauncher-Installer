using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Diagnostics;
using System.ComponentModel;

namespace gadd_updater
{
    public partial class Updater : Form
    {
        public Updater()
        {
            try
            {
                InitializeComponent();
                Downloader();
            }
            catch (Exception errormessage)
            {
            }
        }

        public string installlocation = AppDomain.CurrentDomain.BaseDirectory;

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                progressBar.Value = e.ProgressPercentage;
            }
            catch (Exception errormessage)
            {
            }
        }

        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                var zfs = ZipFile.OpenRead(installlocation + "/pack.szf");
                zfs.ExtractToDirectory(installlocation);
                ProcessSart();
            }
            catch (Exception errormessage)
            {
                MessageBox.Show(errormessage.ToString());
            }
        }

        private void downloadFile()
        {
            try
            {
                string url = "https://ixs.sphub.ca/GADD_LAUNCHER/file.zip";
                string filename = installlocation + "/" + "pack.szf";

                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += DownloadComplete;
                    wc.DownloadFileAsync(new Uri(url), filename);
                }
            }
            catch (Exception errormessage)
            {
            }
        }

        public void Downloader()
        {
            using (var client = new WebClient())
            {
                string[] filePaths = Directory.GetFiles(installlocation);
                foreach (string filePath in filePaths)
                {
                    var name = new FileInfo(filePath).Name;
                    name = name.ToLower();
                    if (name != "GADD_Launcher_Updater.exe")
                    {
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch (Exception e)
                        {
                        }
                    }
                }
                try
                {
                    string[] filePaths2 = Directory.GetFiles(installlocation + "/Resources");
                    foreach (string filePath in filePaths2)
                    {
                        var name = new FileInfo(filePath).Name;
                        name = name.ToLower();
                        if (name != "GADD_Launcher_Updater.exe")
                        {
                            try
                            {
                                File.Delete(filePath);
                            }
                            catch (Exception e)
                            {
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                }
                downloadFile();
            }
        }

        public void ProcessSart()
        {
            try
            {
                Process Launcher = new Process();
                Launcher.StartInfo.FileName = "GADD Application.exe";
                Launcher.Start();
                this.Close();
            }
            catch (Exception errormessage)
            {
            }
        }
    }
}