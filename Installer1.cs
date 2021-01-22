using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace gadd_updater
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            InitializeComponent();
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\GADD_Launcher_Updater.exe");
        }
    }
}