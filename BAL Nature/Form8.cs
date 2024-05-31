 
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAL_Nature
{
    public partial class Form8 : Form
    {
        string EPosta="";
        string eklemeler; int aç = 0; int SimdikiWidth = 1019;
        int SimdikiHeight = 968;
        public Form8(string aa,string eposta )
        {
            EPosta = eposta;
            eklemeler = aa;
            InitializeComponent();
            List<kayıtsınıfı> Data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<kayıtsınıfı>>(eklemeler);
            DataTable ff = new DataTable();


            bindingSource1.DataSource = Data;

            foreach (var a in Data)
            {
                aç += 1;
                siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



            }
            toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}";
            aç = 0;
            bindingNavigator1.BindingSource = bindingSource1;
        }

    
     
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
             
        }

        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
              
        }
        void griddoldur()
        {
            if (eklemeler == "Boş")
            {
                this.Close();
            }
            else
            {
                List<kayıtsınıfı> Data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<kayıtsınıfı>>(eklemeler);
                siticoneDataGridView1.Rows.Clear();
                foreach (var a in Data)
                {


                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
            }

        }
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand komut;
        void KayıtSil(string numara)
        {
            List<kayıtsınıfı> Data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<kayıtsınıfı>>(eklemeler);

            foreach (var a in Data)
            {
                if (a.kayıtbaşlıkx == numara)
                {
                    Data.Remove(a);

                    eklemeler = Newtonsoft.Json.JsonConvert.SerializeObject(Data);
                    if (eklemeler == "[]" || eklemeler == "" || eklemeler == " ")
                    {
                        eklemeler = "Boş";
                        
                    }
                    else
                    {
                         
                    }
                     
                    SqlConnection con = new SqlConnection("Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "veriekle2"; //Stored Procedure' ümüzün ismi
                    cmd.Parameters.Add("EPosta", SqlDbType.NVarChar, 50).Value = EPosta; //Stored procedure deki parametrelere

                    cmd.Parameters.Add("ekleme", SqlDbType.NText).Value = eklemeler; // textboxlardan değerleri


                    cmd.ExecuteNonQuery();
                    con.Close();
                     



                    break;
                }
                else

                {

                }




            }
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in siticoneDataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                string numara = Convert.ToString(drow.Cells[0].Value);
                KayıtSil(numara);
            }
            griddoldur();
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
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

                toolStripStatusLabel1.Text = $"Toplam öğe sayısı:{Data.Count}  |  Listelenen öğe sayısı: {aç}"; aç = 0;


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
    }
}
