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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            chromiumWebBrowser1.LoadUrl("https://balnatureerasmus.wixsite.com/balnature/ba%C4%9F%C4%B1%C5%9F-yap");
        }
        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }



        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void siticoneTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void siticonePictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void webControl2_Click(object sender, EventArgs e)
        {
            
        }

        private void webControl1_Click(object sender, EventArgs e)
        {

        }

        private void label17_MouseEnter(object sender, EventArgs e)
        {
            label17.ForeColor = Color.Green;
            label17.Text = "FOR Future";
        }

        private void label17_MouseLeave(object sender, EventArgs e)
        {
            label17.ForeColor = Color.White;
            label17.Text = "BAL Nature";
        }

        private void siticoneButton26_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siticoneButton27_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int SimdikiWidth = 945;
        int SimdikiHeight = 572;
        private void Form2_Load(object sender, EventArgs e)
        {
             
        }
    }
}
