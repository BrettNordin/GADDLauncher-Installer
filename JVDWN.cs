using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADD_Application
{
    public partial class JVDWN : Form
    {
        public void ChangeProgress(int p)
        {
            try
            {
                progressBar1.Value = p;
            }
            catch
            {

            }
        }
        public JVDWN()
        {
            InitializeComponent();
        }
    }
}
