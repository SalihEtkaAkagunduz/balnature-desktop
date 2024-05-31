
 
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
using Telerik.WinControls.Extensions;

namespace BAL_Nature
{
    public partial class Form9 : Form
    {
        string EPosta = "";
        string eklemeler; int aç = 0; int SimdikiWidth = 1019;
        int SimdikiHeight = 968;
        public Form9(string aa, string eposta)
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
        List<kayıtsınıfı> emp = new List<kayıtsınıfı>();
        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            var Result = siticoneDataGridView1.Rows.OfType<DataGridViewRow>().Select(
            r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();
            foreach ( var ri in Result ) {
                if (ri[0] == null)
                {
                    break;
                }
                else if (ri[0] == null || ri[1] == null || ri[2] == null || ri[3] == null || ri[4] == null || ri[5] == null || ri[6] == null || ri[7] == null || ri[8] == null || ri[9] == null || ri[10] == null || ri[11] == null || ri[12] == null || ri[13] == null || ri[14] == null || ri[15] == null || ri[16] == null || ri[17] == null || ri[18] == null || ri[19] == null || ri[20] == null || ri[21] == null || ri[22] == null || ri[23] == null || ri[24] == null || ri[25] == null)
                {
                    MessageBox.Show("Kaydınız Yaoılırken bir sorunla karşılaşıldı.Lütfen kaydınızı yaparken tüm alanları doldurun.Not:Bazı Veriler kaydedilmemiş olabilir", "BalNature Data Servisi");
                    break;
                }
                var t=new List<kayıtsınıfı>();
                List<kayıtsınıfı> kayıt = new List<kayıtsınıfı>();
                kayıtsınıfı kıy = new kayıtsınıfı();
                kıy.camatıkoranx = Convert.ToInt32(ri[12]);
                kıy.camatıkx = Convert.ToInt32(ri[9]);
                kıy.evselatıkorax = Convert.ToInt32(ri[10]);
                kıy.gdcam = Convert.ToInt32(ri[17]);
                kıy.gdcamoran = Convert.ToInt32(ri[21]);
                kıy.gdkağıt = Convert.ToInt32(ri[18]);
                kıy.gdkağıtoran = Convert.ToInt32(ri[22]);
                kıy.gdmetaloran = Convert.ToInt32(ri[20]);
                kıy.gdmetal = Convert.ToInt32(ri[16]);
                kıy.gdplastik = Convert.ToInt32(ri[19]);
                kıy.gdplastikoran = Convert.ToInt32(ri[23]);
                kıy.kayıtdeğerlendirme = Convert.ToDouble(ri[24]);
                kıy.geridönüştürülenatığıntoplamatığaoranıx = Convert.ToInt32(ri[15]);
                kıy.kayıtalanıx = ri[3].ToString();
                kıy.kayıtaçıklamax = ri[1].ToString();
                kıy.kayıtbaşlıkx = ri[0].ToString();
                kıy.kayıttürx = ri[2].ToString();
                kıy.kağıtatıkoranx = Convert.ToInt32(ri[13]);
                kıy.kağıtatıkx = Convert.ToInt32(ri[11]); ;
                kıy.plastikatıkx = Convert.ToInt32(ri[8]);
                kıy.plastikatıkoranx = Convert.ToInt32(ri[14]);
                kıy.toplamatıkoranx = Convert.ToInt32(ri[9]);
                kıy.toplamatıkx = Convert.ToInt32(ri[4]);
                kıy.metalatıkx = Convert.ToInt32(ri[5]);
                kıy.metalatıkoranx = Convert.ToInt32(ri[11]);
                emp.Add(kıy);

            }
            MessageBox.Show("Kaydınız Tamamlandı", "BalNature Data Servisi");
            eklemeler = Newtonsoft.Json.JsonConvert.SerializeObject(emp);
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
        }
    }
}

