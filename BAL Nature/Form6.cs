using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAL_Nature
{
    public partial class Form6 : Form
    {
        string eklemeler; int aç = 0; int SimdikiWidth = 1019;
        int SimdikiHeight = 968;
        public Form6(string aa)
        {
            eklemeler = aa;
            InitializeComponent(); 
            List<kayıtsınıfı> Data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<kayıtsınıfı>>(eklemeler);
            
           
            DataTable ff = new DataTable();

             
            bindingSource1.DataSource = Data;
            
           foreach (var a in Data)
                {
                aç += 1;
                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx );
                     


                }
            toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}";
            aç = 0;
            bindingNavigator1.BindingSource = bindingSource1;
        }

        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<kayıtsınıfı> Data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<kayıtsınıfı>>(eklemeler);
            siticoneDataGridView1.DataSource = null;
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                siticoneDataGridView1.Rows.Clear();
                foreach (var a in Data)
                {

                    this.siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    aç += 1;
                }
                
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}";aç = 0;


            }
            if (toolStripComboBox1.SelectedIndex == 1)
            {
                siticoneDataGridView1.Rows.Clear();

                ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.zamanx).ToList();

                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx); aç += 1;
                }
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;
            }
            if (toolStripComboBox1.SelectedIndex == 2)
            {
                siticoneDataGridView1.Rows.Clear();
                Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.zamanx).ToList();

                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx); aç += 1;
                }
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;
            }
            if (toolStripComboBox1.SelectedIndex == 3)
            {
                siticoneDataGridView1.Rows.Clear();
                ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.kayıtdeğerlendirme).ToList();

                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx); aç += 1;
                }
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;
            }
            if (toolStripComboBox1.SelectedIndex == 4)
            {
                siticoneDataGridView1.Rows.Clear();
                ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.kayıtdeğerlendirme).ToList();

                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx); aç += 1;
                }
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;
            }
            if (toolStripComboBox1.SelectedIndex == 5)
            {
                siticoneDataGridView1.Rows.Clear();
                ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.toplamatıkx).ToList();

                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx); aç += 1;
                }
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;
            }
            if (toolStripComboBox1.SelectedIndex == 6)
            {
                siticoneDataGridView1.Rows.Clear();
                ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.toplamatıkx).ToList();

                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx); aç += 1;
                }
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;
            }
            if (toolStripComboBox1.SelectedIndex == 7)
            {
                siticoneDataGridView1.Rows.Clear();
                ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.geridönüştürülenatığıntoplamatığaoranıx).ToList();

                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx); aç += 1;
                }
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;
            }
            if (toolStripComboBox1.SelectedIndex == 8)
            {
                siticoneDataGridView1.Rows.Clear();
                ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.geridönüştürülenatığıntoplamatığaoranıx).ToList();

                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx); aç += 1;
                }
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;
            }
            if (toolStripComboBox1.SelectedIndex == 9)
            {
                siticoneDataGridView1.Rows.Clear();
                ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.toplamatıkoranx).ToList();

                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx); aç += 1;
                }
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;
            }
            if (toolStripComboBox1.SelectedIndex == 10)
            {
                siticoneDataGridView1.Rows.Clear();
                ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.toplamatıkoranx).ToList();

                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx); aç += 1;
                }
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;
            }
            if (toolStripComboBox1.SelectedIndex == 11)
            {
                siticoneDataGridView1.Rows.Clear();
                ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.kayıtbaşlıkx).ToList();

                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx); aç += 1;
                }
                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
