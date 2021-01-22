using System;
using System.Windows.Forms;

namespace gadd_updater
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Updater up = new Updater();
                Application.Run(up);
                //up.Show();
            }
            catch (Exception errormessage)
            {
            }
        }
    }
}