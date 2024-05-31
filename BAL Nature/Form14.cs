using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;

namespace BAL_Nature
{
    public partial class Form14 : Form
    {
        public Form14(string a)
        {
            /*this.StartWaiting();*/
            InitializeComponent();
            //this.radSpreadsheetRibbonBar1.RibbonBarElement.RibbonCaption.SystemButtons.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            //this.radSpreadsheetRibbonBar1.RibbonBarElement.RibbonCaption.ShouldHandleMouseInput = false;
            //this.radSpreadsheetRibbonBar1.RibbonBarElement.RibbonCaption.CanManageOwnerForm = false;

            //byte[] bytes = File.ReadAllBytes(null);
            //this.radSpreadsheet1.SpreadsheetElement.Workbook = (WorkbookFormatProvidersManager.GetProviderByName("XlsxFormatProvider") as XlsxFormatProvider).Import(bytes);
        }

        private void radSpreadsheetRibbonBar1_Click(object sender, EventArgs e)
        {

        }

        private void Form14_Load(object sender, EventArgs e)
        {
             
            //this.StopWaiting();
            this.radSpreadsheet1.SpreadsheetElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
        }
    }
}
