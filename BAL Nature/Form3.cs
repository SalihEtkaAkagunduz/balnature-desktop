using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAL_Nature
{
    public partial class Form3 : Form
    {
        public Form3(string label2ç,string label4ç,string labeltrh,int ş)
        {
            InitializeComponent();
            label2.Text = label2ç;
            label4.Text = label4ç;
            label1.Text = labeltrh;
        }
        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }

        int SimdikiWidth = 412;
        int SimdikiHeight = 544;

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
             
        }

        private void siticoneButton26_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
