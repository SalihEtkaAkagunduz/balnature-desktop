using CefSharp;
using DevExpress.XtraCharts;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace BAL_Nature
{
    public partial class Form1 : Form
    {
        int indiriliyor = 0;


        #region intellizecomponenet
        int sıra;
        int SimdikiWidth = 1533;
        int SimdikiHeight = 856;
        double kayıtdeğerlendirme = 0;
        int evselatıkoran = 0, toplamatık = 0, toplamatıkoran = 0, metalatık = 0, metalatıkoran = 0, camatık = 0, camatıkoran = 0, kağıatık = 0, kağıtatıkoran = 0, plastikatık = 0, plastikatıkoran = 0, geridönüştürülenatığıntoplamatığpaoranı = 0, gdmetal = 0, gdmetaloran = 0, gdcam = 0, gdcamoran = 0, gdkağıt = 0, gdkağıtoran = 0, gdplastik = 0, gdplastikoran = 0;
        int Oturumaçıkmıı = 0;
        DateTime kayıtzaman = new DateTime();
        string kayıtbaşlık = "", kayıtaçıklama = "", kayıttür = "", kayıtalanı = "";
        DateTime zaman;
        NotifyIcon notify_Icon2 = new NotifyIcon();
        SiticoneButton stcnbtn3 = new SiticoneButton();
        SiticoneButton stcnbtn = new SiticoneButton();
        SiticoneButton stcnbtn1 = new SiticoneButton();
        SiticoneButton stcnbtn2 = new SiticoneButton();
        NotifyIcon notify_Icon = new NotifyIcon();
        Guid Guidid = new Guid();
        Kullanici dataa;
        string bildirimler = " ", eklemeler = " ";
        string Ad = "", Soyad = "", EPosta = "", telefon = "", şifre = "", doğumgünü = "", doğumayı = "", doğumyılı = "", açıklayıcımetin = "", websitesi = "", twitter = "", facebook = "", linkedin = "", instagram = "", bildirimsesi = "", gündekaçkere = "", kaçgündebir = "";
        int ID = 87, ID2 = 87, ID3 = 87, belgeler = 87, bildirimeposta = 87, bildirimsayısı = 87, eklemesayısı = 87, uygulamaaçıkkenbenihatırla = 87, verilerisakla = 87, başlat = 87, abonelikler = 87, masaüstübildirimler = 87, epostabildirimleri = 87, seazerdinleme = 87, günlükbildirimtf = 87, uyarıver = 87, otomatikbildirimtemizleme = 87, bildirimlersanladepodasaklansın = 87, bildirimler2güngösterilsin = 87, verilerimkaydedilsin = 87, databasekoruması = 87, verilerimleanalizeedilebilirsin = 87, verileriincelenebilsin = 87, diğerürünleriçiniyileştirmeler = 87, verilerbizimlepaylaşılsın = 87, üçüncütarafveriler = 87, kurumhesabı = 87, silindi = 87;
        DateTime OluşturmaZamanı = new DateTime(); Author author1;
        Author author2 = new Author(Properties.Resources.temp_preferences_custom_FILL0_wght400_GRAD0_opsz48, "Bal Nature");
        public Form1()
        {



            InitializeComponent();


            notify_Icon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            notify_Icon2.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

            chromiumWebBrowser2.LifeSpanHandler = new CustomLifeSpanHandler();
            siticoneTabControl1.Visible = false;
            if (Directory.Exists("C:\\ProgramData\\SEAzer\\BALNature"))
            {
                if (File.Exists("C:\\ProgramData\\SEAzer\\BALNature\\info.txt"))
                {



                }
                else
                {


                    string dosya = "C:\\ProgramData\\SEAzer\\BALNature\\info.txt";
                    string dosya2 = "C:\\ProgramData\\SEAzer\\BALNature\\kuruluş.txt";
                    FileInfo fi2 = new FileInfo(dosya2);
                    FileInfo fi = new FileInfo(dosya);
                    StreamWriter sw2 = new StreamWriter(dosya2);
                    StreamWriter sw = new StreamWriter(dosya);
                    sw2.Close();
                    sw.Close();

                    File.WriteAllText("C:\\ProgramData\\SEAzer\\BALNature\\kuruluş.txt", DateTime.Now.ToShortDateString());
                    File.WriteAllText("C:\\ProgramData\\SEAzer\\BALNature\\info.txt", DateTime.Now.ToShortDateString());

                }
            }
            else
            {

                //C'dekiExportReports klasörünün içine Report adında bir metin dosyası oluşturur.


                Directory.CreateDirectory("C:\\ProgramData\\SEAzer\\BALNature");
                string dosya = "C:\\ProgramData\\SEAzer\\BALNature\\info.txt";
                string dosya2 = "C:\\ProgramData\\SEAzer\\BALNature\\kuruluş.txt";
                FileInfo fi2 = new FileInfo(dosya2);
                FileInfo fi = new FileInfo(dosya);
                StreamWriter sw2 = new StreamWriter(dosya2);
                StreamWriter sw = new StreamWriter(dosya);
                sw2.Close();
                sw.Close();

                File.WriteAllText("C:\\ProgramData\\SEAzer\\BALNature\\kuruluş.txt", DateTime.Now.ToShortDateString());
                File.WriteAllText("C:\\ProgramData\\SEAzer\\BALNature\\info.txt", DateTime.Now.ToShortDateString());

                //FileStream fs = File.Create(@"C:\ProgramData\SEAzer\BALNature\mevcutkullanıcı.txt");
                //fs.Close();
            }

            if (File.Exists("C:\\ProgramData\\SEAzer\\BALNature\\mevcutkullanıcı.txt"))
            {
                if (File.Exists("C:\\ProgramData\\SEAzer\\BALNature\\mevcutkullanıcı.txt"))
                {
                    string str = "";
                    string uid = "";
                    str = File.ReadAllText("C:\\ProgramData\\SEAzer\\BALNature\\mevcutkullanıcı.txt");
                    uid = File.ReadAllText("C:\\ProgramData\\SEAzer\\BALNature\\uid.txt");









                    IFirebaseConfig config = new FirebaseConfig
                    {
                        AuthSecret = "txG0YPGu6DZWk6KgyWss2qAveKAGhpjlrzEybbda",
                        BasePath = "https://balnature-default-rtdb.firebaseio.com"
                    };
                    IFirebaseClient client;
                    async void Connection()
                    {
                        client = new FireSharp.FirebaseClient(config);
                        if (client != null)
                        {
                            #region firebase


                            try
                            {
                                List<Kullanici> listStudent = new List<Kullanici>();
                                IFirebaseConfig config3 = new FirebaseConfig
                                {
                                    AuthSecret = "txG0YPGu6DZWk6KgyWss2qAveKAGhpjlrzEybbda",
                                    BasePath = "https://balnature-default-rtdb.firebaseio.com"
                                };

                                IFirebaseClient client3;
                                void Connection3()
                                {
                                    client3 = new FireSharp.FirebaseClient(config3);

                                    if (client3 != null)
                                    {

                                        FirebaseResponse response = null;


                                        async void Insert()
                                        {


                                            response = await client3.GetAsync("kullanicilar/" + uid + "/");
                                            var result = response.Body;
                                            var data = JsonConvert.DeserializeObject<Kullanici>(result);
                                            dataa = data;
                                            siticoneImageButton1.Image = GenerateProfilePhoto(dataa.Isim);
                                            siticoneImageButton1.HoverState.Image = GenerateProfilePhoto(dataa.Isim);
                                            siticoneImageButton1.CheckedState.Image = GenerateProfilePhoto(dataa.Isim);
                                            siticoneImageButton1.PressedState.Image = GenerateProfilePhoto(dataa.Isim);
                                            Oturumaçıkmıı = 1;
                                            Ad = data.Isim;
                                            Soyad = data.Soyisim;
                                            açıklayıcımetin = data.Aciklama;
                                            EPosta = data.Email;
                                            string a = DateTime.Now.ToShortDateString();

                                            string b = (File.ReadAllText("C:\\ProgramData\\SEAzer\\BALNature\\info.txt"));
                                            if (b == a)
                                            {

                                            }
                                            else
                                            {
                                                //yapılacak
                                                 NotifyIconn();
                                            }
                                            if (bildirimler == "Boş" || bildirimler == "Bos" || bildirimler == "")
                                            {

                                            }
                                            else
                                            {

                                                bildirimlistele();

                                            }
                                            label87.Text = Ad + " " + Soyad;
                                            string ilkHarf = Ad.Substring(0, 1).ToUpper();
                                            string ilkHarf2 = Soyad.Substring(0, 1).ToUpper();
                                            label5.Text = ilkHarf + ilkHarf2;
                                            siticoneTextBox4.Text = Ad;
                                            siticoneTextBox5.Text = Soyad;
                                            if (açıklayıcımetin == "Belirtilmemiş")
                                            {
                                                siticoneTextBox6.Text = "";

                                            }
                                            else
                                            {
                                                siticoneTextBox6.Text = açıklayıcımetin;
                                            }
                                            DateTime ii = new DateTime();
                                            int sdf = 1;
                                            doğumayı = "ocak";
                                            doğumgünü = "11";
                                            sdf = Convert.ToInt32(doğumgünü);
                                            int dgf = 1;
                                            if (doğumayı == "Ocak")
                                            {
                                                dgf = 1;
                                            }
                                            if (doğumayı == "Şubat")
                                            {
                                                dgf = 2;
                                            }
                                            if (doğumayı == "Mart")
                                            {
                                                dgf = 3;
                                            }
                                            if (doğumayı == "Nisan")
                                            {
                                                dgf = 4;
                                            }
                                            if (doğumayı == "Mayıs")
                                            {
                                                dgf = 5;
                                            }
                                            if (doğumayı == "Haziran")
                                            {
                                                dgf = 6;
                                            }
                                            if (doğumayı == "Temmuz")
                                            {
                                                dgf = 7;
                                            }
                                            if (doğumayı == "Ağustos" || doğumayı == "Agustos")
                                            {
                                                dgf = 8;
                                            }
                                            if (doğumayı == "Eylül")
                                            {
                                                dgf = 9;
                                            }
                                            if (doğumayı == "Ekim")
                                            {
                                                dgf = 10;
                                            }
                                            if (doğumayı == "Kasım")
                                            {
                                                dgf = 11;
                                            }
                                            if (doğumayı == "Aralık")
                                            {
                                                dgf = 12;
                                            }
                                            int hjk;
                                            hjk = 2000;
                                            try
                                            {
                                                hjk = Convert.ToInt32(doğumyılı);
                                            }
                                            catch (Exception)
                                            {

                                                hjk = 2007;
                                            }
                                            ii = new DateTime(hjk, dgf, sdf);
                                            try
                                            {
                                                siticoneDateTimePicker1.Value = ii;
                                            }
                                            catch (Exception)
                                            {

                                                siticoneDateTimePicker1.Value = new DateTime();
                                            }

                                            if (uygulamaaçıkkenbenihatırla == 1)
                                            {
                                                siticoneToggleSwitch1.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneToggleSwitch1.Checked = false;
                                            }
                                            if (verilerisakla == 1)
                                            {
                                                siticoneToggleSwitch2.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneToggleSwitch2.Checked = false;
                                            }
                                            if (masaüstübildirimler == 1)
                                            {
                                                siticoneToggleSwitch5.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneToggleSwitch5.Checked = false;
                                            }
                                            if (epostabildirimleri == 1)
                                            {
                                                siticoneToggleSwitch4.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneToggleSwitch4.Checked = false;
                                            }
                                            if (seazerdinleme == 1)
                                            {
                                                siticoneToggleSwitch6.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneToggleSwitch6.Checked = false;
                                            }
                                            siticoneTextBox7.Text = EPosta;
                                            if (websitesi == "Belirtilmemiş")
                                            {
                                                siticoneTextBox16.Text = "";
                                            }
                                            else
                                            {
                                                siticoneTextBox16.Text = websitesi;
                                            }

                                            if (twitter == "Belirtilmemiş")
                                            {
                                                siticoneTextBox11.Text = "";
                                            }
                                            else
                                            {
                                                siticoneTextBox11.Text = twitter;
                                            }

                                            if (facebook == "Belirtilmemiş")
                                            {
                                                siticoneTextBox12.Text = "";
                                            }
                                            else
                                            {
                                                siticoneTextBox12.Text = facebook;
                                            }
                                            if (linkedin == "Belirtilmemiş")
                                            {
                                                siticoneTextBox13.Text = "";
                                            }
                                            else
                                            {
                                                siticoneTextBox13.Text = linkedin;
                                            }
                                            if (instagram == "Belirtilmemiş")
                                            {
                                                siticoneTextBox14.Text = "";
                                            }
                                            else
                                            {
                                                siticoneTextBox14.Text = instagram;
                                            }
                                            kaçgündebir = "1" ;
                                            gündekaçkere = "4";
                                            siticoneNumericUpDown1.Value = Convert.ToInt32(kaçgündebir);
                                            siticoneNumericUpDown2.Value = Convert.ToInt32(gündekaçkere);



                                            if (günlükbildirimtf == 1)
                                            {
                                                siticoneCheckBox2.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox2.Checked = false;
                                            }

                                            if (bildirimler2güngösterilsin == 1)
                                            {
                                                siticoneCheckBox3.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox3.Checked = false;
                                            }

                                            if (uyarıver == 1)
                                            {
                                                siticoneCheckBox4.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox4.Checked = false;
                                            }

                                            if (otomatikbildirimtemizleme == 1)
                                            {
                                                siticoneCheckBox5.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox5.Checked = false;
                                            }

                                            if (bildirimlersanladepodasaklansın == 1)
                                            {
                                                siticoneCheckBox6.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox6.Checked = false;
                                            }
                                            if (verilerimkaydedilsin == 1)
                                            {
                                                siticoneCheckBox10.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox10.Checked = false;
                                            }

                                            if (databasekoruması == 1)
                                            {
                                                siticoneCheckBox11.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox11.Checked = false;
                                            }
                                            if (verilerimleanalizeedilebilirsin == 1)
                                            {
                                                siticoneCheckBox12.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox12.Checked = false;
                                            }
                                            if (üçüncütarafveriler == 1)
                                            {
                                                siticoneCheckBox9.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox9.Checked = false;
                                            }
                                            if (verilerbizimlepaylaşılsın == 1)
                                            {
                                                siticoneCheckBox13.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox13.Checked = false;
                                            }
                                            if (diğerürünleriçiniyileştirmeler == 1)
                                            {
                                                siticoneCheckBox7.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox7.Checked = false;
                                            }
                                            if (verilerbizimlepaylaşılsın == 1)
                                            {
                                                siticoneCheckBox8.Checked = true;

                                            }
                                            else
                                            {
                                                siticoneCheckBox8.Checked = false;
                                            }
                                        }

                                    

                                        Insert();
                                    }

                                }
                                Connection3();
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("hgbhdghj");
                            }







                            #endregion


















                        }
                        else
                        {
                            MessageBox.Show("Maalesef Bal Nature'nin 2.13.22.1 sürümü internetsiz işlemleri desteklememektedir lütfen internete bağlanın.", "Bal Nature Connection Services");
                            this.Close();
                        }

                    }

                    Connection();



                }
            }
        
           

            string okunmuş = File.ReadAllText("C:\\ProgramData\\SEAzer\\BALNature\\kuruluş.txt");
            siticoneButton67.Visible = false; siticoneButton68.Visible = false; siticoneButton69.Visible = false; siticoneButton70.Visible = false;
            label73.Text = okunmuş;
            siticoneTabControl3.SelectedTab = tabPage21;
            timer2.Interval = 35;

            timer1.Interval = 50;
            siticonePanel2.Visible = false;
            panel11.Visible = false;
            radCalendar2.SelectedDate = DateTime.Now;
            label133.Text = radCalendar2.SelectedDate.ToShortDateString();

            label79.Visible = false;
            label64.Visible = false; siticonePanel3.Visible = false;
            panel25.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            siticoneButton65.Visible = false;
            label1.Text = "Bal Nature";
            siticoneButton66.Visible = false;
            label123.Visible = false; siticoneTabControl6.SelectedTab = tabPage36; siticoneTabControl7.SelectedTab = tabPage38; this.radChat1.Author = new Author(Properties.Resources.user, "Ben");





















            this.radChat1.Author = new Author(Properties.Resources.user, Ad);


            ChatTextMessage message1 = new ChatTextMessage($"Merhaba {Ad}", author2, DateTime.Now);
            this.radChat1.AddMessage(message1);
            sıracc = 0;


            ChatTextMessage message3 = new ChatTextMessage("Şu anda çeşitli işlemler için yardım alabileceğin destek bölümündesin.\nLütfen yapmak istediklerinden birini seç eğer yapmak istediğin seçeneklerde yoksa yapmak istediğini yaz.", author2, DateTime.Now);
            this.radChat1.AddMessage(message3);
            this.radChat1.AddMessage(new ChatTextMessage("Lütfen seçeneklerden birini seç.", author2, DateTime.Now));

            List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

            actions.Add(new SuggestedActionDataItem("Hata Bildir"));
            actions.Add(new SuggestedActionDataItem("Öneri Yap"));
            actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
            actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
            actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
            actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
            actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
            actions.Add(new SuggestedActionDataItem("Diğer"));

            ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
            this.radChat1.AddMessage(suggestionActionsMessage);
            siticonePanel18.Visible = false;


            flowLayoutPanel15.Visible = false;
            siticoneButton64.Visible = false;
            siticoneTextBox6.Visible = true;
            siticoneTextBox5.Visible = true;
            siticoneButton67.Visible = false; siticoneButton68.Visible = false; siticoneButton69.Visible = false; siticoneButton70.Visible = false;
            pictureBox28.Visible = false; siticoneButton63.Visible = false; siticoneButton63.Visible = false;
            siticoneTextBox4.Visible = true;
            label82.Visible = true; label83.Visible = true; label84.Visible = true; label86.Visible = true; label85.Visible = true;
            siticoneDateTimePicker1.Visible = true; siticoneToggleSwitch2.Visible = true; siticoneToggleSwitch1.Visible = true; siticoneToggleSwitch3.Visible = true;
            siticoneButton37.Visible = true; panel26.Visible = false;
            label45.Text = "Profiliniz";
            label46.Text = "Kendiniz hakkında bilgi ekleyin";
            label88.Visible = false; label90.Visible = false; label89.Visible = false;
            siticoneTextBox7.Visible = false; siticoneTextBox8.Visible = false; siticoneTextBox9.Visible = false; siticoneTextBox10.Visible = false;
            siticoneButton41.Visible = false;

            siticoneCheckBox1.Visible = false;
            label100.Visible = false; siticoneButton42.Visible = false;
            pictureBox27.Visible = false;
            label96.Visible = false; label97.Visible = false; label98.Visible = false; label99.Visible = false;
            label91.Visible = false; label92.Visible = false; label93.Visible = false; label94.Visible = false; label95.Visible = false;
            siticoneButton40.Visible = false;
            siticoneTextBox11.Visible = false; siticoneTextBox12.Visible = false; siticoneTextBox13.Visible = false; siticoneTextBox14.Visible = false; siticoneTextBox16.Visible = false;
            siticonePictureBox26.Visible = false; siticonePictureBox32.Visible = false; siticonePictureBox33.Visible = false; siticonePictureBox34.Visible = false;
            siticoneComboBox3.Visible = false;
            siticoneToggleSwitch6.Visible = false; siticoneToggleSwitch5.Visible = false; siticoneToggleSwitch4.Visible = false;
            label101.Visible = false; label102.Visible = false; label103.Visible = false; label104.Visible = false; label105.Visible = false; label106.Visible = false; label107.Visible = false; label108.Visible = false;
            siticoneComboBox1.Visible = false;
            siticoneNumericUpDown1.Visible = false; siticoneNumericUpDown2.Visible = false;
            siticoneCheckBox2.Visible = false; siticoneCheckBox3.Visible = false; siticoneCheckBox4.Visible = false; siticoneCheckBox5.Visible = false; siticoneCheckBox6.Visible = false;

            label109.Visible = false; label110.Visible = false; label111.Visible = false; label112.Visible = false; label113.Visible = false; label114.Visible = false; label115.Visible = false; label116.Visible = false;
            siticoneCheckBox7.Visible = false; siticoneCheckBox8.Visible = false; siticoneCheckBox9.Visible = false; siticoneCheckBox10.Visible = false; siticoneCheckBox11.Visible = false; siticoneCheckBox12.Visible = false; siticoneCheckBox13.Visible = false;
            linkLabel22.Visible = false; linkLabel23.Visible = false; linkLabel24.Visible = false; linkLabel26.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;

            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            panel11.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;

            siticonePanel1.Visible = false;
            label16.Visible = false;
            label9.Visible = false;
            label80.Visible = false;
            label81.Visible = false;
            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;
            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label10.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;

            label11.Visible = false;

            timer3.Interval = 1;
            siticoneButton54.Visible = false;

            panel4.Visible = false;
            System.Windows.Forms.ScrollBar vScrollBar1 = new VScrollBar();
            panel6.Visible = false;
            panel4.Visible = false;

            label4.Visible = false;

            siticoneButton51.Visible = false;
            siticoneButton53.Visible = false;
            label6.Visible = false;

            vScrollBar1.Dock = DockStyle.Right;


            List<string> söz = new List<string>() { "\"Bir nokta açıktır: Dünyamız emin ellerde değildir ” Yeni dünya düzeni” yeryüzünü ölüme mahkum etmiştir.\"", "\"Ya bizler kentlerimizin kirlenmesini ortadan kaldıracağız ya da kentlerimizin kirlenmesi bizleri.\"", "\"Doğaya hoyratça davranan toplumlarda insanlar arasındaki ilişkiler de hoyratça oluyorlar.\"", "\"Kirletmemek, temizlemekten daha ucuzdur.\"", "\"Havayı, suyu, doğal yaşamı koruma çabalarımız, aslında kendimizi koruma çabalarımızdır.\"", "\"Herkes evinin önünü süpürürse, bütün şehir temiz olur.\"", "\"İnsan, temiz olmayan şeyleri su ile yıkayıp temizler, eğer su kirlenirse, o ne ile nasıl temizlenir?\"", "\"Çevresel tehlikeler, artık yalnızca kuş meraklılarını ilgilendirmiyor, bu tehlikenin çanları hepimiz için çalıyor.\"", "\"Çevre, çevrecilere bırakılmayacak kadar ciddi bir meseledir.\"", "\"Kirli çevre insanın ruhunu kirletir, kirli ruhlar çevreyi kirletir.\"", "\"Biz doğayı korudukça doğa da bizi korur.\"", "\"Temizlik saygı işidir, başaran çağdaş kişidir.\"", "\"Çevreni temiz tut ki geleceğin kirlenmesin.\"", "\"Herkes sağlıklı, dengeli bir doğal çevrede yaşamak hakkına sahiptir.\"", "\"Çevre kirliliği, her anımızı etkileyen sağlıklı bir yaşam konusudur.\"", "\"Sağlıklı yaşam, sağlıklı çevre ile olur.\"", "\"Çevre; miras değil gelecek nesillere devredilecek emanettir.\"", "\"Havayı temiz tutun çevreyi aydınlatın!\"", "\"Yeşili sev, hayatı sev.\"", "\"Yarının doğası bugünden yaratılır.\"", "\"Uçmuyorsa kuşlar, ölüyorsa balıklar, nasıl yaşar insanlar?\"", };
            label2.ForeColor = Color.White;
            label3.Text = söz.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            siticoneTextBox1.Visible = false;
            siticoneComboBox1.Visible = false;
            siticoneButton1.Visible = false;
            siticoneComboBox1.Visible = false;
            siticoneComboBox2.Visible = false;
            siticoneButton55.Visible = false;
            panel6.Visible = false;
            siticoneButton22.Visible = false;
            siticoneButton23.Visible = false;
            siticoneButton24.Visible = false;
            siticoneButton25.Visible = false;
            siticoneButton14.Visible = false;
            siticoneButton15.Visible = false;
            siticoneButton16.Visible = false;
            siticoneButton17.Visible = false;
            panel8.Visible = false;
            siticoneButton44.Visible = false;



            siticoneButton48.Visible = false;
            siticoneButton49.Visible = false;
            siticoneButton50.Visible = false;
            siticoneButton43.Visible = false;
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            siticoneButton18.Visible = false;
            siticoneButton19.Visible = false;
            siticoneButton20.Visible = false;
            siticoneButton21.Visible = false;

            siticoneButton8.Visible = false;
            siticoneButton10.Visible = false;
            siticoneButton11.Visible = false;
            siticoneButton12.Visible = false;
            label119.Visible = false;
            label120.Visible = false;
            label121.Visible = false;
            siticoneTextBox8.BorderColor = Color.Black;
            siticoneTextBox9.BorderColor = Color.Black;
            siticoneTextBox10.BorderColor = Color.Black;

            // This line of code is generated by Data Source Configuration Wizard
            // Fill the JsonDataSource asynchronously
            jsonDataSource1.FillAsync();
            chromiumWebBrowser1.LoadUrl("https://63c848d70d365.site123.me/");
            chromiumWebBrowser3.LoadUrl("https://balnatureerasmus.wixsite.com/balnature/bağış-yap");

        }

        bool seçimyapıldımı = false;
        int seçilenact; int sıracc;
        string hatamesajı;
        int toplamatıkanalizx, toplamatıkanalizsayıx;
        private void radChat1_SuggestedActionClicked(object sender, SuggestedActionEventArgs e)
        {
            /*    actions.Add(new SuggestedActionDataItem("Hata Bildir"));
            actions.Add(new SuggestedActionDataItem("Öneri Yap"));
            actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
            actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
            actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
            actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
            actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
            actions.Add(new SuggestedActionDataItem("Diğer"));*/
            //this.radChat1.AddMessage(new ChatTextMessage("Seçtiğiniz: " + e.Action.Text, this.radChat1.Author, DateTime.Now));
            seçimyapıldımı = true;

            if (e.Action.Text == "Hata Bildir")
            {
                this.radChat1.AddMessage(new ChatTextMessage("Hata Bildirmek istiyorum", this.radChat1.Author, DateTime.Now));
                seçilenact = 1;
                this.radChat1.AddMessage(new ChatTextMessage("Lütfen göndermek istediğiniz hata mesajının konusunu yazın iptal için 'IPTAL' YAzın", author2, DateTime.Now));
                sıracc = 1;
                ChatListOverlay listOverlay = new ChatListOverlay("List overlay");

                listOverlay.ListView.Items.Add("Gelen Hata Mesajı");
                listOverlay.ListView.Items.Add("Çalışmayan Özellik");
                listOverlay.ListView.Items.Add("Eksik Yada Hatalı Veri");
                listOverlay.ListView.Items.Add("Hesap Hataları");
                listOverlay.ListView.Items.Add("İşleyiş Hataları");
                listOverlay.ListView.Items.Add("Diğer");
                bool showAsPopup = false;

                ChatOverlayMessage overlayMessage = new ChatOverlayMessage(listOverlay, showAsPopup, author2, DateTime.Now);
                this.radChat1.AddMessage(overlayMessage);

            }
            if (e.Action.Text == "Öneri Yap")
            {
                this.radChat1.AddMessage(new ChatTextMessage("Öneri Yapmak istiyorum", this.radChat1.Author, DateTime.Now));

                this.radChat1.AddMessage(new ChatTextMessage("Lütfen göndermek istediğiniz öneri mesajının konusunu yazın iptal için 'IPTAL' YAzın", author2, DateTime.Now));
                sıracc = 3;
                ChatListOverlay listOverlay = new ChatListOverlay("List overlay");

                listOverlay.ListView.Items.Add("Veri İşleyişi ile ilgili Öneri");
                listOverlay.ListView.Items.Add("Ekstra özellik için öneri");
                listOverlay.ListView.Items.Add("Algoritma düzeni için öneri");
                listOverlay.ListView.Items.Add("Şirket içi Öneriler");
                listOverlay.ListView.Items.Add("İstatistik Önerileri");
                listOverlay.ListView.Items.Add("Diğer");
                bool showAsPopup = false;

                ChatOverlayMessage overlayMessage = new ChatOverlayMessage(listOverlay, showAsPopup, author2, DateTime.Now);
                this.radChat1.AddMessage(overlayMessage);
            }
            if (e.Action.Text == "Hızlı Veri")
            {
                if (Oturumaçıkmıı == 1)
                {
                    this.radChat1.AddMessage(new ChatTextMessage($"Hızlı Veriyi Seçtiniz Lütfen bir seçenek seçiniz", author2, DateTime.Now));
                    List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                    actions.Add(new SuggestedActionDataItem("Toplam Atık Ortalama"));
                    actions.Add(new SuggestedActionDataItem("Tüm Verileri Listele"));
                    actions.Add(new SuggestedActionDataItem("Toplam Atık Miktarı"));
                    actions.Add(new SuggestedActionDataItem("Toplam Puanı Göster"));
                    actions.Add(new SuggestedActionDataItem("Yıllara Göre Listele"));

                    ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                    this.radChat1.AddMessage(suggestionActionsMessage);
                }
                else
                {
                    this.radChat1.AddMessage(new ChatTextMessage($"Malesef! Bu özellikten yararlanabilmek için önce oturum açmalısınız", author2, DateTime.Now)); List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                    actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                    actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                    actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                    actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                    actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                    actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                    actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                    actions.Add(new SuggestedActionDataItem("Diğer"));

                    ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                    this.radChat1.AddMessage(suggestionActionsMessage);
                }






            }


            if (e.Action.Text == "Toplam Atık Ortalama")
            {

                List<kayıtsınıfı> Data3 = Veridönüştürü( );
                foreach (kayıtsınıfı itepom in Data3)
                {
                    toplamatıkanalizx += itepom.toplamatıkx;
                    toplamatıkanalizsayıx += 1;
                }
                string jkl = (toplamatıkanaliz / toplamatıkanalizsayı).ToString();
                this.radChat1.AddMessage(new ChatTextMessage($"Ortalama Atık Miktarı : {jkl}", author2, DateTime.Now));

                this.radChat1.AddMessage(new ChatTextMessage($"İşleminiz Tamamlandı Menüye Dönüyorsunuz...", author2, DateTime.Now)); List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                actions.Add(new SuggestedActionDataItem("Diğer"));

                ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                this.radChat1.AddMessage(suggestionActionsMessage);
            }
            if (e.Action.Text == "Tüm Verileri Listele")
            {
                ChatProductCardDataItem k;
                List<kayıtsınıfı> Data3 = Veridönüştürü( );
                foreach (kayıtsınıfı itepom in Data3)
                {
                    ChatProductCardDataItem productCard = new ChatProductCardDataItem(Properties.Resources.istockphoto_1263327539_612x612_removebg_preview, itepom.zamanx.ToShortDateString(), itepom.kayıtbaşlıkx,
                                                                                                $"Kayıt Açıklama={itepom.kayıtaçıklamax}\nKayıt Yeri={itepom.kayıtalanıx}\nToplam Atık={itepom.toplamatıkx}\nKayıt Türü={itepom.kayıttürx}\nMetal Atık={itepom.metalatıkx}\nCam Atık={itepom.camatıkx}\nKağıt Atık={itepom.kağıtatıkx}\nPlastik Atık={itepom.plastikatıkx}", $"Verilen Puan:{itepom.kayıtdeğerlendirme}", null, null);


                    ;
                    ChatCardMessage message = new ChatCardMessage(productCard, author2, DateTime.Now);
                    this.radChat1.AddMessage(message);
                }
                this.radChat1.AddMessage(new ChatTextMessage($"İşleminiz Tamamlandı Menüye Dönüyorsunuz...", author2, DateTime.Now)); List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                actions.Add(new SuggestedActionDataItem("Diğer"));

                ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                this.radChat1.AddMessage(suggestionActionsMessage);



            }
            if (e.Action.Text == "Toplam Atık Miktarı")
            {
                List<kayıtsınıfı> Data3 = Veridönüştürü( );
                foreach (kayıtsınıfı itepom in Data3)
                {
                    toplamatıkanalizx += itepom.toplamatıkx;
                    toplamatıkanalizsayıx += 1;
                }
                string jkl = toplamatıkanaliz.ToString();
                this.radChat1.AddMessage(new ChatTextMessage($"Toplam Atık Miktarı : {jkl}", author2, DateTime.Now));

                this.radChat1.AddMessage(new ChatTextMessage($"İşleminiz Tamamlandı Menüye Dönüyorsunuz...", author2, DateTime.Now)); List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                actions.Add(new SuggestedActionDataItem("Diğer"));

                ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                this.radChat1.AddMessage(suggestionActionsMessage);
            }

            if (e.Action.Text == "Toplam Puanı Göster")
            {
                this.radChat1.AddMessage(new ChatTextMessage($"Toplam Puan Miktarı : 21223", author2, DateTime.Now));

                this.radChat1.AddMessage(new ChatTextMessage($"İşleminiz Tamamlandı Menüye Dönüyorsunuz...", author2, DateTime.Now)); List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                actions.Add(new SuggestedActionDataItem("Diğer"));

                ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                this.radChat1.AddMessage(suggestionActionsMessage);
            }
            DateTime actionzaman, actionseçilizaman;
            if (e.Action.Text == "Yıllara Göre Listele")
            {
                ChatProductCardDataItem k;
                List<kayıtsınıfı> Data3 = Veridönüştürü( );
                Data3 = Data3.OrderBy(kayıtsınıfı => kayıtsınıfı.zamanx).ToList();
                actionseçilizaman = new DateTime();
                foreach (kayıtsınıfı itepom in Data3)
                {
                    actionzaman = itepom.zamanx;
                    if (actionseçilizaman.Year != actionzaman.Year)
                    {
                        actionseçilizaman = actionzaman;
                        this.radChat1.AddMessage(new ChatTextMessage(actionseçilizaman.Year.ToString(), author2, DateTime.Now));
                    }
                    ChatProductCardDataItem productCard = new ChatProductCardDataItem(Properties.Resources.istockphoto_1263327539_612x612_removebg_preview, itepom.zamanx.ToShortDateString(), itepom.kayıtbaşlıkx,
                                                                                                $"Kayıt Açıklama={itepom.kayıtaçıklamax}\nKayıt Yeri={itepom.kayıtalanıx}\nToplam Atık={itepom.toplamatıkx}\nKayıt Türü={itepom.kayıttürx}\nMetal Atık={itepom.metalatıkx}\nCam Atık={itepom.camatıkx}\nKağıt Atık={itepom.kağıtatıkx}\nPlastik Atık={itepom.plastikatıkx}", $"Verilen Puan:{itepom.kayıtdeğerlendirme}", null, null);


                    ;
                    ChatCardMessage message = new ChatCardMessage(productCard, author2, DateTime.Now);
                    this.radChat1.AddMessage(message);
                }
                this.radChat1.AddMessage(new ChatTextMessage($"İşleminiz Tamamlandı Menüye Dönüyorsunuz...", author2, DateTime.Now)); List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                actions.Add(new SuggestedActionDataItem("Diğer"));

                ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                this.radChat1.AddMessage(suggestionActionsMessage);
            }


            if (e.Action.Text == "Seazer ve Balnature Hakkında")
            {
                this.radChat1.AddMessage(new ChatTextMessage("Bal Nature:\n2022 yılında erasmus projeleri için yapılmaya başlanmış ve 4 yıl boyunca hizmet vermesi planlanan doğayı korumyı ve insanlarda bilinç oluşturmayı amaçlayan veri işleme ve analiz etme odaklı bir projedir.\n\nProjede Emeği Geçenler:\nSalih Etka Akagündüz\nBahrican Sezer\nEnes Sarıkaya\nMustafa Turan\nKaan", author2, DateTime.Now));
                List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                actions.Add(new SuggestedActionDataItem("Hesap Ayrıntıları ve Önerileri"));
                actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                actions.Add(new SuggestedActionDataItem("Diğer")); ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                this.radChat1.AddMessage(suggestionActionsMessage);
            }
            if (e.Action.Text == "Analiz Verilerini Göster")
            {
                seçilenact = 5;
            }
            if (e.Action.Text == "Araçları Görüntüle")
            {
                seçilenact = 6;
            }
            if (e.Action.Text == "Oyun ve Ayrıntıları Listele")
            {
                seçilenact = 7;
            }
            if (e.Action.Text == "Diğer")
            {
                seçilenact = 8;
            }
            if (e.Action.Text == "Göster")
            {
                if (sıracc == 2)
                {


                    this.radChat1.AddMessage(new ChatTextMessage("Hata Mesajınız:...", author2, DateTime.Now));
                    this.radChat1.AddMessage(new ChatTextMessage(hatamesajı, author2, DateTime.Now));
                }
                if (sıracc == 4)
                {


                    this.radChat1.AddMessage(new ChatTextMessage("Öneri Mesajınız:...", author2, DateTime.Now));
                    this.radChat1.AddMessage(new ChatTextMessage(hatamesajı, author2, DateTime.Now));
                }
            }
            if (e.Action.Text == "Gösterme")
            {
                if (sıracc == 2)
                {
                    this.radChat1.AddMessage(new ChatTextMessage("Hata Mesajınızı Göstermemeyi seçtiniz...", author2, DateTime.Now));
                    this.radChat1.AddMessage(new ChatTextMessage("Oturumunuz Sonlandırılıyor...", author2, DateTime.Now));
                    List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                    actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                    actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                    actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                    actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                    actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                    actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                    actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                    actions.Add(new SuggestedActionDataItem("Diğer"));

                    ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                    this.radChat1.AddMessage(suggestionActionsMessage);
                }

                if (sıracc == 4)
                {
                    this.radChat1.AddMessage(new ChatTextMessage("Öneri Mesajınızı Göstermemeyi seçtiniz...", author2, DateTime.Now));
                    this.radChat1.AddMessage(new ChatTextMessage("Oturumunuz Sonlandırılıyor...", author2, DateTime.Now));
                    List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                    actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                    actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                    actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                    actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                    actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                    actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                    actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                    actions.Add(new SuggestedActionDataItem("Diğer"));

                    ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                    this.radChat1.AddMessage(suggestionActionsMessage);
                }
            }
            if (e.Action.Text == "Evet")
            {
                if (sıracc == 2)
                {
                    try
                    {

                        this.radChat1.AddMessage(new ChatTextMessage("Mesajınız gönderiliyor...", author2, DateTime.Now));

                        MailMessage mesaj = new MailMessage();
                        mesaj.From = new MailAddress("balnature.erasmus@outlook.com");
                        mesaj.To.Add("balnature.erasmus@gmail.com");
                        mesaj.To.Add("balnature.erasmus@outlook.com");
                        mesaj.Subject = şikayetmesaj;
                        mesaj.Body = şikayetmesajmetin;

                        SmtpClient a = new SmtpClient();
                        a.Credentials = new System.Net.NetworkCredential("balnature.erasmus@outlook.com", "S234432s");
                        a.Port = 587;
                        a.Host = "smtp-mail.outlook.com";
                        a.EnableSsl = true;
                        object userState = mesaj;
                        a.SendAsync(mesaj, (object)mesaj);
                        this.radChat1.AddMessage(new ChatTextMessage("Mesaş Gönderimi Başarılı", author2, DateTime.Now)); List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                        actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                        actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                        actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                        actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                        actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                        actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                        actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                        actions.Add(new SuggestedActionDataItem("Diğer"));

                        ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                        this.radChat1.AddMessage(suggestionActionsMessage);
                    }
                    catch (Exception ex)
                    {

                        this.radChat1.AddMessage(new ChatTextMessage("Mesajınız gönderilirken bir hata ile karşılaşıldı.Hata ayrıntılarını görmek istiyormusun?", author2, DateTime.Now));
                        List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                        actions.Add(new SuggestedActionDataItem("Göster"));
                        actions.Add(new SuggestedActionDataItem("Gösterme"));
                        ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                        this.radChat1.AddMessage(suggestionActionsMessage);
                        hatamesajı = ex.Message.ToString();
                    }
                }

            }
            if (sıracc == 4)
            {
                try
                {

                    this.radChat1.AddMessage(new ChatTextMessage("Mesajınız gönderiliyor...", author2, DateTime.Now));

                    MailMessage mesaj = new MailMessage();
                    mesaj.From = new MailAddress("balnature.erasmus@outlook.com");
                    mesaj.To.Add("balnature.erasmus@gmail.com");
                    mesaj.To.Add("balnature.erasmus@outlook.com");
                    mesaj.Subject = şikayetmesaj;
                    mesaj.Body = şikayetmesajmetin;

                    SmtpClient a = new SmtpClient();
                    a.Credentials = new System.Net.NetworkCredential("balnature.erasmus@outlook.com", "S234432s");
                    a.Port = 587;
                    a.Host = "smtp-mail.outlook.com";
                    a.EnableSsl = true;
                    object userState = mesaj;
                    a.SendAsync(mesaj, (object)mesaj);
                    this.radChat1.AddMessage(new ChatTextMessage("Mesaş Gönderimi Başarılı", author2, DateTime.Now)); List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                    actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                    actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                    actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                    actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                    actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                    actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                    actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                    actions.Add(new SuggestedActionDataItem("Diğer"));

                    ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                    this.radChat1.AddMessage(suggestionActionsMessage);
                }
                catch (Exception ex)
                {

                    this.radChat1.AddMessage(new ChatTextMessage("Mesajınız gönderilirken bir hata ile karşılaşıldı.Hata ayrıntılarını görmek istiyormusun?", author2, DateTime.Now));
                    List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                    actions.Add(new SuggestedActionDataItem("Göster"));
                    actions.Add(new SuggestedActionDataItem("Gösterme"));
                    ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                    this.radChat1.AddMessage(suggestionActionsMessage);
                    hatamesajı = ex.Message.ToString();
                }
            }


            if (e.Action.Text == "Hayır")
            {
                if (sıracc == 2)
                {
                    this.radChat1.AddMessage(new ChatTextMessage("iptal ediliyor...", author2, DateTime.Now));
                    sıracc = 0;
                    ChatTextMessage message3 = new ChatTextMessage(" Lütfen yapmak istediklerinden birini seç ..", author2, DateTime.Now);
                    this.radChat1.AddMessage(message3);


                    List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                    actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                    actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                    actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                    actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                    actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                    actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                    actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                    actions.Add(new SuggestedActionDataItem("Diğer"));

                    ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                    this.radChat1.AddMessage(suggestionActionsMessage);
                }
                if (sıracc == 4)
                {
                    this.radChat1.AddMessage(new ChatTextMessage("iptal ediliyor...", author2, DateTime.Now));
                    sıracc = 0;
                    ChatTextMessage message3 = new ChatTextMessage(" Lütfen yapmak istediklerinden birini seç ..", author2, DateTime.Now);
                    this.radChat1.AddMessage(message3);


                    List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                    actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                    actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                    actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                    actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                    actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                    actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                    actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                    actions.Add(new SuggestedActionDataItem("Diğer"));

                    ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                    this.radChat1.AddMessage(suggestionActionsMessage);
                }
            }

        }

        private void Nmm_Click(object sender, EventArgs e)
        {
            SiticoneButton b = (SiticoneButton)sender;
            List<bild> Data3 = dataa.Bildirim;


            string a = b.Name;
            string bb = b.Tag.ToString();
            string c = b.Text;
            int d = b.TabIndex;
            Form3 frm3 = new Form3(c, a, bb, d);
            frm3.ShowDialog();
            var data3Copy = new List<bild>(Data3);
            foreach (var item in data3Copy)
            {
                data3Copy.Remove(item);
                bildirimekle(item);
                
            }

            flowLayoutPanel4.Controls.Remove(b);

            pictureBox6.Visible = false;
            label8.Visible = false;
            flowLayoutPanel4.Visible = false;
            panel6.Visible = false;
            bildirimmenüsüaçıkmı = false;
        }





        void NotifyIconn()
        {
            this.Hide();
            notify_Icon.Visible = true;
            notify_Icon.Text = "BAL Nature";
            if (DateTime.Now.Hour > 13)
            {
                if (bildirimler == "Boş" || bildirimler == "Bos")
                {
                    bildirimler = "";
                    List<bild> Data3 = new List<bild>();
                    notify_Icon.BalloonTipTitle = "Tünaydın Kullanıcı";
                    string değer = DateTime.Now.ToShortTimeString();

                    DateTime tarihj = DateTime.Now;
                    //Bu projeye başlarken ne yazdığımı tek Tanrı ve ben biliyordum
                    //Şimdi bir tek o biliyor!!!
                    bild kıy = new bild();
                    kıy.Kısaaçıklama = "ilk giriş hatırlatması";
                    kıy.Tarih = DateTime.Now.ToShortDateString();
                    kıy.Konu = "Tünaydın Kullanıcı";
                    kıy.Açıklama = $"Saat {değer} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";

                    Data3.Add(kıy);
                    bildirimler = Newtonsoft.Json.JsonConvert.SerializeObject(Data3);
                    bildirimekle(kıy);
                    bildirimlistele();
                    //$"Saat {DateTime.Now.ToShortTimeString()} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";
                }
                else
                {

                    List<bild> Data3 = dataa.Bildirim;
                    notify_Icon.BalloonTipTitle = "Tünaydın Kullanıcı";
                    string değer = DateTime.Now.ToShortTimeString();

                    DateTime tarihj = DateTime.Now;
                    //Bu projeye başlarken ne yazdığımı tek Tanrı ve ben biliyordu
                    //Şimdi bir tek o biliyor!!!
                    bild kıy = new bild();
                     
                    kıy.Kısaaçıklama = "ilk giriş hatırlatması";
                    kıy.Tarih = DateTime.Now.ToShortDateString();
                    kıy.Konu = "Tünaydın Kullanıcı";
                    kıy.Açıklama = $"Saat {değer} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";
                    Data3.Add(kıy);
                    bildirimler = Newtonsoft.Json.JsonConvert.SerializeObject(Data3);
                    bildirimekle(kıy);
                    //$"Saat {DateTime.Now.ToShortTimeString()} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";

                }


            }
            else if (DateTime.Now.Hour > 20)
            {
                if (bildirimler == "Boş")
                {
                    bildirimler = "";
                    List<bild> Data3 = new List<bild>();
                    notify_Icon.BalloonTipTitle = "İyi Akşamlar Kullanıcı";
                    string değer = DateTime.Now.ToShortTimeString();

                    DateTime tarihj = DateTime.Now;
                    //Bu projeye başlarken ne yazdığımı tek Tanrı ve ben biliyordum
                    //Şimdi bir tek o biliyor!!!
                    bild kıy = new bild();
                    kıy.Kısaaçıklama = "ilk giriş hatırlatması";
                    kıy.Tarih = DateTime.Now.ToShortDateString();
                    kıy.Konu = "İyi Akşamlar Kullanıcı";
                    kıy.Açıklama = $"Saat {değer} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";

                    Data3.Add(kıy);
                    bildirimler = Newtonsoft.Json.JsonConvert.SerializeObject(Data3);
                    bildirimekle(kıy);
                    bildirimlistele();
                    //$"Saat {DateTime.Now.ToShortTimeString()} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";
                }
                else
                {

                    List<bild> Data3 = dataa.Bildirim;
                    notify_Icon.BalloonTipTitle = "İyi Akşamlar Kullanıcı";
                    string değer = DateTime.Now.ToShortTimeString();

                    DateTime tarihj = DateTime.Now;
                    //Bu projeye başlarken ne yazdığımı tek Tanrı ve ben biliyordum
                    //Şimdi bir tek o biliyor!!!
                    bild kıy = new bild();
                    kıy.Kısaaçıklama = "ilk giriş hatırlatması";
                    kıy.Tarih = DateTime.Now.ToShortDateString();
                    kıy.Konu = "İyi Akşamlar Kullanıcı";
                    kıy.Açıklama = $"Saat {değer} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";

                    Data3.Add(kıy);
                    bildirimler = Newtonsoft.Json.JsonConvert.SerializeObject(Data3);
                    bildirimekle(kıy);
                    //$"Saat {DateTime.Now.ToShortTimeString()} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";

                }
            }
            else
            {
                if (bildirimler == "Boş" || bildirimler == "Bos")
                {
                    bildirimler = "";
                    List<bild> Data3 = new List<bild>();
                    notify_Icon.BalloonTipTitle = "Günaydın Kullanıcı"; ;
                    string değer = DateTime.Now.ToShortTimeString();

                    DateTime tarihj = DateTime.Now;
                    //Bu projeye başlarken ne yazdığımı tek Tanrı ve ben biliyordum
                    //Şimdi bir tek o biliyor!!!
                    bild kıy = new bild();
                    kıy.Kısaaçıklama = "ilk giriş hatırlatması";
                    kıy.Tarih = DateTime.Now.ToShortDateString();
                    kıy.Konu = "Günaydın Kullanıcı";
                    kıy.Açıklama = $"Saat {değer} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";
                    Data3.Add(kıy);
                    bildirimler = Newtonsoft.Json.JsonConvert.SerializeObject(Data3);
                    bildirimekle(kıy);
                    bildirimlistele();
                    //$"Saat {DateTime.Now.ToShortTimeString()} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";
                }
                else
                {

                    List<bild> Data3 = dataa.Bildirim;
                    notify_Icon.BalloonTipTitle = "Günaydın Kullanıcı"; ;
                    string değer = DateTime.Now.ToShortTimeString();

                    DateTime tarihj = DateTime.Now;
                    //Bu projeye başlarken ne yazdığımı tek Tanrı ve ben biliyordum
                    //Şimdi bir tek o biliyor!!!
                   
                    bild kıy = new bild();
                    kıy.Kısaaçıklama = "ilk giriş hatırlatması";
                    kıy.Tarih = DateTime.Now.ToShortDateString();
                    kıy.Konu = "Günaydın Kullanıcı";
                    kıy.Açıklama = $"Saat {değer} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";
                    Data3.Add(kıy);
                    bildirimler = Newtonsoft.Json.JsonConvert.SerializeObject(Data3);
                    bildirimekle(kıy);
                    //$"Saat {DateTime.Now.ToShortTimeString()} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";

                }
                //List<Class2> Data3 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class2>>(bildirimler);
                //notify_Icon.BalloonTipTitle = "Günaydın Kullanıcı";
                //string değer = DateTime.Now.ToShortTimeString();

                //DateTime tarihj = DateTime.Now;
                ////Bu projeye başlarken ne yazdığımı tek Tanrı ve ben biliyordum
                ////Şimdi bir tek o biliyor!!!
                //Class2 kıy = new Class2();
                //kıy.tür = 1;
                //kıy.Tarih = DateTime.Now;
                //kıy.Başlık = "Günaydın Kullanıcı";
                //kıy.Açıklama = $"Saat {değer} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";
                //Data3.Add(kıy);
                //bildirimler = Newtonsoft.Json.JsonConvert.SerializeObject(Data3);
                //bildirimekle(bildirimler);


            }
            notify_Icon.BalloonTipText = $"Saat {DateTime.Now.ToShortTimeString()} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";
            notify_Icon.BalloonTipIcon = ToolTipIcon.Info;
            notify_Icon.ShowBalloonTip(2500);

            File.WriteAllText("C:\\ProgramData\\SEAzer\\BALNature\\info.txt", DateTime.Now.ToShortDateString());


        }
        static public int sayıı(string newName, string connString)
        {
            Int32 newProdID = 0;
            string sql =
                "select dbo.fonksiyon(@eposta)";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {
                    conn.Open();
                    newProdID = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return (int)newProdID;
        }

        #endregion
        #region yandaki kısım
        static public bool abc = false;
        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {
            indirilenlerdemi = 0;
            flowLayoutPanel15.Visible = false;
            flowLayoutPanel13.Visible = false; ;
            flowLayoutPanel14.Visible = false; ;
            panel26.Visible = false;
            panel25.Visible = false;
            siticonePanel3.Visible = false;
            panel11.Visible = false;
            siticonePanel2.Visible = false;
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;
            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;

            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            if (indirilenkısmıaçıkmı == true)
            {
                timer2.Stop();
                tıklı = 1;
                siticonePictureBox2.FillColor = Color.FromArgb(50, 60, 64);
                siticonePictureBox3.FillColor = Color.FromArgb(50, 60, 64);
                label1.ForeColor = Color.FromArgb(50, 60, 64);
                panel6.Visible = false;
                panel4.Visible = false;
                siticoneButton55.Visible = false;

                label4.Visible = false;
                chromiumWebBrowser2.Visible = true;
                siticoneButton22.Visible = false;
                siticoneButton23.Visible = false;
                siticoneButton24.Visible = false;
                siticoneButton25.Visible = false;
                siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton14.Visible = false;
                siticoneButton15.Visible = false;
                siticoneButton16.Visible = false;
                siticoneButton17.Visible = false;
                siticoneButton18.Visible = false;
                siticoneButton19.Visible = false;
                label3.Visible = true;
                siticoneButton20.Visible = false;
                siticoneButton21.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                siticoneButton12.Visible = false;
                siticoneTextBox1.Visible = false;
                siticoneComboBox1.Visible = false;
                siticonePictureBox2.Visible = true;
                label1.Visible = true;
                siticonePictureBox3.Visible = true;
                siticoneButton13.FillColor = Color.FromArgb(56, 60, 64);
                siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton6.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
                label3.Visible = true;
                label6.Visible = false;
                siticoneButton6.Visible = true;
                siticoneButton7.Visible = true;
                siticoneButton51.Visible = false;
                panel8.Visible = false;
                indirilenkısmıaçıkmı = false;
                siticoneButton54.Visible = false;

                siticoneButton53.Visible = false;
                siticoneButton2.Visible = true;
                siticoneButton3.Visible = true;
                siticoneButton4.Visible = true;
                siticoneButton5.Visible = true;
                siticoneButton9.Visible = true;
                siticoneButton13.Visible = true;
            }
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            panel6.Visible = false;
            panel4.Visible = false;

            chromiumWebBrowser2.LoadUrl("http://balnature.great-site.net/");

            chromiumWebBrowser2.AutoScrollOffset = new Point(0, 0);
            label4.Visible = false;
            chromiumWebBrowser2.Visible = true;
            siticoneButton22.Visible = false;
            siticoneButton23.Visible = false;
            siticoneButton24.Visible = false;
            siticoneButton25.Visible = false;
            siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
            siticoneButton8.Visible = false;
            siticoneButton14.Visible = false;
            siticoneButton15.Visible = false;
            siticoneButton16.Visible = false;
            siticoneButton17.Visible = false;
            siticoneButton18.Visible = false;
            siticoneButton19.Visible = false;
            label3.Visible = true;
            siticoneButton20.Visible = false;
            siticoneButton21.Visible = false;
            siticoneButton10.Visible = false;
            siticoneButton11.Visible = false;
            siticoneButton12.Visible = false;
            siticoneTextBox1.Visible = false;
            siticoneComboBox1.Visible = false;
            siticonePictureBox2.Visible = true;
            label1.Visible = true;
            siticonePictureBox3.Visible = true;
            siticoneButton13.FillColor = Color.FromArgb(56, 60, 64);
            siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton6.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
        }

        private void siticoneButton1_MouseHover(object sender, EventArgs e)
        {

        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {

            siticonePanel3.Visible = false;
            if (Oturumaçıkmıı == 1)
            {
                panel25.Visible = false;
                label15.Text = Ad + " " + Soyad;
                siticoneTabControl2.SelectedTab = tabPage7;
                siticoneComboBox2.Enabled = false;
                siticoneChip1.BorderRadius = 12;
                siticoneChip2.BorderRadius = 12;
                siticoneChip3.BorderRadius = 12;
                siticoneChip4.BorderRadius = 12;
                siticoneChip5.BorderRadius = 12;
                panel26.Visible = false;
                siticoneChip8.BorderRadius = 12;
                siticoneChip7.BorderRadius = 12;
                siticoneButton56.Visible = false;
                siticoneButton57.Visible = false;
                siticoneButton58.Visible = false;
                siticoneButton59.Visible = false;
                siticoneButton60.Visible = false;
                panel6.Visible = false;
                if (bildirimmenüsüaçıkmı == true)
                {
                    panel6.Visible = false;
                    bildirimmenüsüaçıkmı = false;
                }
                if (Hesapaçıkmı == true)
                {
                    timer1.Interval = 1;
                    timer1.Start();
                    siticoneImageButton1.Enabled = false;
                    siticoneButton43.Visible = false;
                    siticoneButton44.Visible = false;




                    siticoneButton48.Visible = false;
                    siticoneButton49.Visible = false;
                    siticoneButton50.Visible = false;
                }
                int camaaaa = 0, metalaaaa = 0, plastikaaaa = 0, kağıtaaaa = 0, toplamatıkanalizaa = 0;
                panel4.Visible = false;
                List<kayıtsınıfı> Data3aa = Veridönüştürü( );
                foreach (kayıtsınıfı itepomaa in Data3aa)
                {

                    toplamatıkanalizaa += itepomaa.toplamatıkx;
                    plastikaaaa += itepomaa.gdplastik;
                    camaaaa += itepomaa.gdcam;
                    metalaaaa += itepomaa.gdmetal;
                    kağıtaaaa += itepomaa.gdkağıt;
                }
                double sayi1aa = Convert.ToDouble((metalaaaa + plastikaaaa + camaaaa + kağıtaaaa));


                double sayi2aa = Convert.ToDouble(toplamatıkanalizaa);

                double yuzde = (sayi1aa / sayi2aa) * 100;
                int yuvarlanmisYuzde = (int)Math.Round(yuzde);



                label126.Text = yuvarlanmisYuzde.ToString();
                label4.Visible = true;
                chromiumWebBrowser2.Visible = false;
                siticoneButton1.Visible = true; siticoneComboBox2.Visible = true; siticoneComboBox1.Visible = false; siticoneTextBox1.Visible = false;
                siticonePictureBox2.Visible = false;
                label1.Visible = false;
                siticonePictureBox3.Visible = false; radRadialGauge1.Value = yuvarlanmisYuzde;
                siticoneButton8.Visible = false;
                siticoneButton10.Visible = false;
                if (yuvarlanmisYuzde < 50)
                {
                    pictureBox30.BackColor = Color.FromArgb(255, 82, 74); label124.BackColor = Color.FromArgb(255, 82, 74); label126.BackColor = Color.FromArgb(255, 82, 74);
                    radialGaugeArc1.BackColor = Color.FromArgb(255, 82, 74);
                    radialGaugeArc1.BackColor2 = Color.FromArgb(255, 82, 74); pictureBox32.BackColor = Color.FromArgb(255, 82, 74); flowLayoutPanel1.BackColor = Color.FromArgb(255, 82, 74);
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        if (control is SiticoneChip button)
                        {

                            button.BackColor = Color.FromArgb(255, 82, 74);// İstediğiniz renge göre değiştirin
                        }
                    }
                }
                else
                {
                    pictureBox30.BackColor = Color.FromArgb(119, 190, 79); label124.BackColor = Color.FromArgb(119, 190, 79); label126.BackColor = Color.FromArgb(119, 190, 79);
                    radialGaugeArc1.BackColor = Color.FromArgb(119, 190, 79); pictureBox32.BackColor = Color.FromArgb(119, 190, 79);
                    radialGaugeArc1.BackColor2 = Color.FromArgb(119, 190, 79); flowLayoutPanel1.BackColor = Color.FromArgb(119, 190, 79);
                }
                siticoneButton11.Visible = false;
                label3.Visible = false;
                siticoneButton12.Visible = false;
                siticoneButton8.Visible = true;
                siticoneButton14.Visible = false;
                siticoneButton15.Visible = false;
                siticoneButton16.Visible = false;
                siticoneButton17.Visible = false;
                siticoneButton18.Visible = false;
                siticoneButton19.Visible = false;
                siticoneButton20.Visible = false;
                siticoneButton21.Visible = false;
                siticoneButton10.Visible = true;
                siticoneButton11.Visible = true;
                siticoneButton12.Visible = true;
                siticoneButton13.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton2.FillColor = Color.FromArgb(56, 60, 64);
                siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton4.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton6.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton22.Visible = false;
                siticoneButton23.Visible = false;
                siticoneButton24.Visible = false;
                siticoneButton25.Visible = false;
                siticonePanel2.Visible = true;
            }
            else
            {
                MessageBox.Show("Bu özelliğe erişebilmeniz için oturum açmanız gerekmektedir");
            }
        }
        int sayı4 = 0;
        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            panel26.Visible = false;
            panel25.Visible = false;
            siticonePanel3.Visible = false;
            if (sayı4 == 0)
            {
                siticoneProgressIndicator1.Start();

                timer4.Interval = 10;
                timer4.Start();
                sayı4++;
            }

            siticonePanel2.Visible = false;
            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;
            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            panel6.Visible = false;
            panel4.Visible = true;

            label4.Visible = true;
            chromiumWebBrowser2.Visible = false;
            label3.Visible = false;
            siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
            siticoneButton8.Visible = false;
            siticoneButton14.Visible = false;
            siticoneButton15.Visible = false;
            siticoneButton16.Visible = false;
            siticoneButton17.Visible = false;
            siticoneButton18.Visible = false;
            siticoneButton19.Visible = false;
            siticoneButton20.Visible = false;
            siticoneButton21.Visible = false;
            siticoneButton10.Visible = false;
            siticoneButton11.Visible = false;
            siticoneButton12.Visible = false;
            siticoneTextBox1.Visible = true;
            siticoneComboBox1.Visible = true;
            siticonePictureBox2.Visible = false;
            siticoneButton22.Visible = false;
            siticoneButton23.Visible = false;
            siticoneButton24.Visible = false;
            siticoneButton25.Visible = false;
            label1.Visible = false;
            siticonePictureBox3.Visible = false;
            siticoneButton13.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton3.FillColor = Color.FromArgb(56, 60, 64);
            siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton6.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
        }
        int toplamatıkanaliz;
        int toplamatıkanalizsayı;
        int atıkk;
        int plastikaa;
        int kağıtaa;
        int camaa;
        int metalaa;
        int plastikaat;
        int kağıtaat;
        int camaat;
        int metalaat;
        int ayx1 = 0;
        int ayx2 = 0;
        int ayx3 = 0;
        int ayx4 = 0;
        int ayx5 = 0;
        int ayx6 = 0;
        int ayx7 = 0;
        int ayx8 = 0;
        int ayx9 = 0;
        int ayx10 = 0;
        int ayx11 = 0;
        int ayx12 = 0;
        int ay1 = 0;
        int ay2 = 0;
        int ay3 = 0;
        int ay4 = 0;
        int ay5 = 0;
        int ay6 = 0;
        int ay7 = 0;
        int ay8 = 0;
        int ay9 = 0;
        int ay10 = 0;
        int ay11 = 0;
        int ay12 = 0;
        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            if (Oturumaçıkmıı == 1)
            {
                panel26.Visible = false;
                panel25.Visible = false;
                siticoneButton92.Visible = true;
                //DevExpress.XtraCharts.Series k = chartControl2.Series[0];
                //DevExpress.XtraCharts.Series k2 = chartControl5.Series[0];
                //SeriesPoint o= k.Points[0];
                //SeriesPoint o2 = k2.Points[0];
                List<kayıtsınıfı> Data3 = Veridönüştürü( );
                SeriesPoint ı = chartControl2.Series[0].Points[0];
                toplamatıkanaliz = 0;
                atıkk = 0;
                if (Data3.Count == 0)
                {
                    label164.Text = "?";

                }
                else
                {
                    //  seriesPoint2.ColorSerializable = "#C0504D";
                    toplamatıkanaliz = 0;
                    toplamatıkanalizsayı = 0; plastikaat = 0;

                    camaat = 0;
                    metalaat = 0;
                    kağıtaat = 0;
                    plastikaa = 0;

                    camaa = 0;
                    metalaa = 0;
                    kağıtaa = 0;

                    ay1 = 0;
                    ay2 = 0;
                    ay3 = 0;
                    ay4 = 0;
                    ay5 = 0;
                    ay6 = 0;
                    ay7 = 0;
                    ay8 = 0;
                    ay9 = 0;
                    ay10 = 0;
                    ay11 = 0;
                    ay12 = 0;
                    ayx1 = 0;
                    ayx2 = 0;
                    ayx3 = 0;
                    ayx4 = 0;
                    ayx5 = 0;
                    ayx6 = 0;
                    ayx7 = 0;
                    ayx8 = 0;
                    ayx9 = 0;
                    ayx10 = 0;
                    ayx11 = 0;
                    ayx12 = 0;
                    //chartControl2.Series.Clear(); chartControl3.Series.Clear(); chartControl4.Series.Clear(); chartControl5.Series.Clear();
                    DevExpress.XtraCharts.Series ff = new DevExpress.XtraCharts.Series("a", ViewType.Area); DevExpress.XtraCharts.Series fy = new DevExpress.XtraCharts.Series("a", ViewType.Area); DevExpress.XtraCharts.Series fyz = new DevExpress.XtraCharts.Series("a", ViewType.Area);
                    DevExpress.XtraCharts.Series fyz1 = new DevExpress.XtraCharts.Series("a", ViewType.Area);
                    DevExpress.XtraCharts.Series fyz2 = new DevExpress.XtraCharts.Series("a", ViewType.Area);
                    DevExpress.XtraCharts.Series fyz3 = new DevExpress.XtraCharts.Series("a", ViewType.Area); DevExpress.XtraCharts.Series fff = chartControl2.Series[0]; chartControl8.Series[0].Points.Clear();
                    chartControl1.Series[0].Points.Clear(); chartControl7.Series[0].Points.Clear(); chartControl12.Series[0].Points.Clear();
                    chartControl2.Series[0].Points.Clear(); chartControl3.Series[0].Points.Clear();
                    chartControl11.Series[0].Points.Clear(); chartControl9.Series[0].Points.Clear();
                   
                    chartControl10.Series[0].Points.Clear(); chartControl4.Series[0].Points.Clear(); chartControl5.Series[0].Points.Clear(); chartControl8.Series[0].Points.Clear();
                    ; DevExpress.XtraCharts.Series ffff = chartControl3.Series[0];
                    ; DevExpress.XtraCharts.Series fffff = chartControl5.Series[0];
                    ; DevExpress.XtraCharts.Series ffffff = chartControl4.Series[0];
                    DevExpress.XtraCharts.Series xxx = chartControl1.Series[0];
                    DevExpress.XtraCharts.Series xxxy = chartControl8.Series[0];
                    DevExpress.XtraCharts.Series xxxyx = chartControl9.Series[0];
                    DevExpress.XtraCharts.Series xxxyy = chartControl11.Series[0];
                    DevExpress.XtraCharts.Series xxxyxy = chartControl10.Series[0];
                    chartControl6.Series.Clear(); chartControl1.Series.Clear(); chartControl7.Series.Clear(); chartControl8.Series.Clear(); chartControl12.Series.Clear(); flowLayoutPanel7.Controls.Clear();
                    ; chartControl2.Series.Clear(); chartControl3.Series.Clear(); chartControl9.Series.Clear(); chartControl4.Series.Clear(); chartControl5.Series.Clear(); chartControl11.Series.Clear(); chartControl10.Series.Clear();
                    List<DateTime> Liist = new List<DateTime>();
                    foreach (kayıtsınıfı itepom in Data3)
                    {
                        SiticoneButton oğ = new SiticoneButton();
                        oğ.BorderRadius = 22;
                        oğ.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
                        oğ.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
                        oğ.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
                        oğ.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
                        oğ.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        oğ.ForeColor = System.Drawing.Color.GreenYellow;
                        oğ.Location = new System.Drawing.Point(3, 3);
                        oğ.Name = "siticoneButton91";
                        oğ.Size = new System.Drawing.Size(flowLayoutPanel7.Width - 19, 86);
                        oğ.TabIndex = 0;
                        oğ.Text = itepom.zamanx.ToShortDateString();
                        oğ.Tag = itepom;
                        oğ.Click += Oğ_Click;
                        flowLayoutPanel7.Controls.Add(oğ);
                        plastikaat += itepom.plastikatıkx;
                        camaat += itepom.camatıkx;
                        metalaat += itepom.metalatıkx;
                        kağıtaat += itepom.kağıtatıkx;

                        plastikaa += itepom.gdplastik;
                        camaa += itepom.gdcam;
                        metalaa += itepom.gdmetal;
                        kağıtaa += itepom.gdkağıt;
                        Liist.Add(itepom.zamanx);
                        DateTime aa = itepom.zamanx;
                        string g = aa.ToShortDateString();
                        toplamatıkanaliz += itepom.toplamatıkx;
                        toplamatıkanalizsayı += 1;
                        DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint($"{g}", new object[] {
             ((object)((itepom.toplamatıkx)))});

                        ff.Points.Add(seriesPoint2);

                        DevExpress.XtraCharts.SeriesPoint seriesPoint2y = new DevExpress.XtraCharts.SeriesPoint($"{g}", new object[] {
             ((object)((itepom.toplamatıkx)))});
                        fy.Points.Add(seriesPoint2y);


                        label228.Text = Ad + " " + Soyad;
                        string ilkHarf = Ad.Substring(0, 1).ToUpper();
                        string ilkHarf2 = Soyad.Substring(0, 1).ToUpper();
                        label227.Text = ilkHarf + ilkHarf2;
                        label236.Text = Guidid.ToString();
                        DevExpress.XtraCharts.SeriesPoint seriesPoint2yz = new DevExpress.XtraCharts.SeriesPoint($"{g}", new object[] {
             ((object)((itepom.gdplastik)))});
                        fyz.Points.Add(seriesPoint2yz);

                        DevExpress.XtraCharts.SeriesPoint seriesPoint2yz1 = new DevExpress.XtraCharts.SeriesPoint($"{g}", new object[] {
             ((object)((itepom.gdcam)))});
                        fyz1.Points.Add(seriesPoint2yz1);

                        DevExpress.XtraCharts.SeriesPoint seriesPoint2yz2 = new DevExpress.XtraCharts.SeriesPoint($"{g}", new object[] {
             ((object)((itepom.gdkağıt)))});
                        fyz2.Points.Add(seriesPoint2yz2);


                        DevExpress.XtraCharts.SeriesPoint seriesPoint2yz3 = new DevExpress.XtraCharts.SeriesPoint($"{g}", new object[] {
             ((object)((itepom.gdmetal)))});
                        fyz3.Points.Add(seriesPoint2yz3);
                        seriesPoint2.ColorSerializable = "#C0504D";
                        seriesPoint2y.ColorSerializable = "#C0504D";
                        if (siticoneComboBox15.SelectedIndex == 0)
                        {


                            if (itepom.zamanx.Year == 2023)
                            {


                                if (itepom.zamanx.Month == 1)
                                {
                                    ay1 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 2)
                                {
                                    ay2 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 3)
                                {
                                    ay3 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 4)
                                {
                                    ay4 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 5)
                                {
                                    ay5 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 6)
                                {
                                    ay6 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 7)
                                {
                                    ay7 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 8)
                                {
                                    ay8 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 9)
                                {
                                    ay9 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 10)
                                {
                                    ay10 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 11)
                                {
                                    ay11 += itepom.toplamatıkx;

                                }
                                else if (itepom.zamanx.Month == 12)
                                {
                                    ay12 += itepom.toplamatıkx;

                                }
                            }
                        }
                        if (siticoneComboBox15.SelectedIndex == 1)
                        {


                            if (itepom.zamanx.Year == 2022)
                            {


                                if (itepom.zamanx.Month == 1)
                                {
                                    ay1 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 2)
                                {
                                    ay2 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 3)
                                {
                                    ay3 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 4)
                                {
                                    ay4 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 5)
                                {
                                    ay5 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 6)
                                {
                                    ay6 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 7)
                                {
                                    ay7 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 8)
                                {
                                    ay8 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 9)
                                {
                                    ay9 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 10)
                                {
                                    ay10 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 11)
                                {
                                    ay11 += itepom.toplamatıkx;

                                }
                                else if (itepom.zamanx.Month == 12)
                                {
                                    ay12 += itepom.toplamatıkx;

                                }
                            }
                        }
                        if (siticoneComboBox15.SelectedIndex == 2)
                        {


                            if (itepom.zamanx.Year == 2021)
                            {


                                if (itepom.zamanx.Month == 1)
                                {
                                    ay1 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 2)
                                {
                                    ay2 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 3)
                                {
                                    ay3 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 4)
                                {
                                    ay4 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 5)
                                {
                                    ay5 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 6)
                                {
                                    ay6 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 7)
                                {
                                    ay7 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 8)
                                {
                                    ay8 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 9)
                                {
                                    ay9 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 10)
                                {
                                    ay10 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 11)
                                {
                                    ay11 += itepom.toplamatıkx;

                                }
                                else if (itepom.zamanx.Month == 12)
                                {
                                    ay12 += itepom.toplamatıkx;

                                }
                            }
                        }
                        if (siticoneComboBox15.SelectedIndex == 3)
                        {


                            if (itepom.zamanx.Year == 2020)
                            {


                                if (itepom.zamanx.Month == 1)
                                {
                                    ay1 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 2)
                                {
                                    ay2 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 3)
                                {
                                    ay3 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 4)
                                {
                                    ay4 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 5)
                                {
                                    ay5 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 6)
                                {
                                    ay6 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 7)
                                {
                                    ay7 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 8)
                                {
                                    ay8 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 9)
                                {
                                    ay9 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 10)
                                {
                                    ay10 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 11)
                                {
                                    ay11 += itepom.toplamatıkx;

                                }
                                else if (itepom.zamanx.Month == 12)
                                {
                                    ay12 += itepom.toplamatıkx;

                                }
                            }
                        }
                        if (siticoneComboBox15.SelectedIndex == 4)
                        {


                            if (itepom.zamanx.Year == 2019)
                            {


                                if (itepom.zamanx.Month == 1)
                                {
                                    ay1 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 2)
                                {
                                    ay2 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 3)
                                {
                                    ay3 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 4)
                                {
                                    ay4 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 5)
                                {
                                    ay5 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 6)
                                {
                                    ay6 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 7)
                                {
                                    ay7 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 8)
                                {
                                    ay8 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 9)
                                {
                                    ay9 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 10)
                                {
                                    ay10 += itepom.toplamatıkx;
                                }
                                else if (itepom.zamanx.Month == 11)
                                {
                                    ay11 += itepom.toplamatıkx;

                                }
                                else if (itepom.zamanx.Month == 12)
                                {
                                    ay12 += itepom.toplamatıkx;

                                }
                            }
                        }





                        if (siticoneComboBox15.SelectedIndex == 0)
                        {


                            if (itepom.zamanx.Year == 2023)
                            {


                                if (itepom.zamanx.Month == 1)
                                {
                                    ayx1 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 2)
                                {
                                    ayx2 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 3)
                                {
                                    ayx3 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 4)
                                {
                                    ayx4 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 5)
                                {
                                    ayx5 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 6)
                                {
                                    ayx6 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 7)
                                {
                                    ayx7 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 8)
                                {
                                    ayx8 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 9)
                                {
                                    ayx9 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 10)
                                {
                                    ayx10 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 11)
                                {
                                    ayx11 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;

                                }
                                else if (itepom.zamanx.Month == 12)
                                {
                                    ayx12 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;

                                }
                            }
                        }
                        if (siticoneComboBox15.SelectedIndex == 1)
                        {


                            if (itepom.zamanx.Year == 2022)
                            {


                                if (itepom.zamanx.Month == 1)
                                {
                                    ayx1 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 2)
                                {
                                    ayx2 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 3)
                                {
                                    ayx3 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 4)
                                {
                                    ayx4 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 5)
                                {
                                    ayx5 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 6)
                                {
                                    ayx6 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 7)
                                {
                                    ayx7 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 8)
                                {
                                    ayx8 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 9)
                                {
                                    ayx9 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 10)
                                {
                                    ayx10 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 11)
                                {
                                    ayx11 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;

                                }
                                else if (itepom.zamanx.Month == 12)
                                {
                                    ayx12 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;

                                }
                            }
                        }
                        if (siticoneComboBox15.SelectedIndex == 2)
                        {


                            if (itepom.zamanx.Year == 2021)
                            {


                                if (itepom.zamanx.Month == 1)
                                {
                                    ayx1 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 2)
                                {
                                    ayx2 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 3)
                                {
                                    ayx3 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 4)
                                {
                                    ayx4 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 5)
                                {
                                    ayx5 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 6)
                                {
                                    ayx6 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 7)
                                {
                                    ayx7 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 8)
                                {
                                    ayx8 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 9)
                                {
                                    ayx9 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 10)
                                {
                                    ayx10 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 11)
                                {
                                    ayx11 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;

                                }
                                else if (itepom.zamanx.Month == 12)
                                {
                                    ayx12 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;

                                }
                            }
                        }
                        if (siticoneComboBox15.SelectedIndex == 3)
                        {


                            if (itepom.zamanx.Year == 2020)
                            {


                                if (itepom.zamanx.Month == 1)
                                {
                                    ayx1 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 2)
                                {
                                    ayx2 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 3)
                                {
                                    ayx3 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 4)
                                {
                                    ayx4 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 5)
                                {
                                    ayx5 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 6)
                                {
                                    ayx6 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 7)
                                {
                                    ayx7 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 8)
                                {
                                    ayx8 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 9)
                                {
                                    ayx9 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 10)
                                {
                                    ayx10 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 11)
                                {
                                    ayx11 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;

                                }
                                else if (itepom.zamanx.Month == 12)
                                {
                                    ayx12 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;

                                }
                            }
                        }
                        if (siticoneComboBox15.SelectedIndex == 4)
                        {


                            if (itepom.zamanx.Year == 2019)
                            {


                                if (itepom.zamanx.Month == 1)
                                {
                                    ayx1 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 2)
                                {
                                    ayx2 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 3)
                                {
                                    ayx3 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 4)
                                {
                                    ayx4 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 5)
                                {
                                    ayx5 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 6)
                                {
                                    ayx6 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 7)
                                {
                                    ayx7 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 8)
                                {
                                    ayx8 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 9)
                                {
                                    ayx9 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 10)
                                {
                                    ayx10 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;
                                }
                                else if (itepom.zamanx.Month == 11)
                                {
                                    ayx11 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;

                                }
                                else if (itepom.zamanx.Month == 12)
                                {
                                    ayx12 += itepom.gdcam + itepom.gdkağıt + itepom.gdmetal + itepom.gdplastik;

                                }
                            }
                        }
                    }


                    DevExpress.XtraCharts.SeriesPoint seriesPointxxxyz = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                    xxxyy.Points.Add(seriesPointxxxyz);
                    seriesPointxxxyz.ColorSerializable = "#20CB48";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx1yz = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});
                    xxxyy.Points.Add(seriesPointxx1yz);
                    seriesPointxx1yz.ColorSerializable = "#365b81";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx2yz = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((kağıtaa)))});
                    xxxyy.Points.Add(seriesPointxx2yz);
                    seriesPointxx2yz.ColorSerializable = "#bc1000";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx3yz = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((metalaa)))});
                    xxxyy.Points.Add(seriesPointxx3yz);
                    seriesPointxx3yz.ColorSerializable = " #d6d600";

                    chartControl11.Series.Add(xxxyy);













                    DevExpress.XtraCharts.SeriesPoint seriesPointxxxy1z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx1)))});
                    xxxyxy.Points.Add(seriesPointxxxy1z);
                    seriesPointxxxy1z.ColorSerializable = "#820263";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx1y2z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx2)))});
                    xxxyxy.Points.Add(seriesPointxx1y2z);
                    seriesPointxx1y2z.ColorSerializable = "#e53d00";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx2y3z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx3)))});
                    xxxyxy.Points.Add(seriesPointxx2y3z);
                    seriesPointxx2y3z.ColorSerializable = "#07a0c3";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx3y4z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx4)))});
                    xxxyxy.Points.Add(seriesPointxx3y4z);
                    seriesPointxx3y4z.ColorSerializable = " #4abc95";
                    DevExpress.XtraCharts.SeriesPoint seriesPointxxxy5z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx5)))});
                    xxxyxy.Points.Add(seriesPointxxxy5z);
                    seriesPointxxxy5z.ColorSerializable = "#f05365";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx1y6z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx6)))});
                    xxxyxy.Points.Add(seriesPointxx1y6z);
                    seriesPointxx1y6z.ColorSerializable = "#d83e38";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx2y7z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx7)))});
                    xxxyxy.Points.Add(seriesPointxx2y7z);
                    seriesPointxx2y7z.ColorSerializable = "#fdea3e";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx3y8z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx8)))});
                    xxxyxy.Points.Add(seriesPointxx3y8z);
                    seriesPointxx3y8z.ColorSerializable = " #63bb35";
                    DevExpress.XtraCharts.SeriesPoint seriesPointxxxy9z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx9)))});
                    xxxyxy.Points.Add(seriesPointxxxy9z);
                    seriesPointxxxy9z.ColorSerializable = "#233d6b";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx1y10z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx10)))});
                    xxxyxy.Points.Add(seriesPointxx1y10z);
                    seriesPointxx1y10z.ColorSerializable = "#edb68c";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx2y11z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx11)))});
                    xxxyxy.Points.Add(seriesPointxx2y11z);
                    seriesPointxx2y11z.ColorSerializable = "#928d93";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx3y12z = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ayx12)))});
                    xxxyxy.Points.Add(seriesPointxx3y12z);
                    seriesPointxx3y12z.ColorSerializable = " #8a59cd";

                    chartControl10.Series.Add(xxxyxy);























                    DevExpress.XtraCharts.SeriesPoint seriesPointxxxy1 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay1)))});
                    xxxyx.Points.Add(seriesPointxxxy1);
                    seriesPointxxxy1.ColorSerializable = "#820263";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx1y2 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay2)))});
                    xxxyx.Points.Add(seriesPointxx1y2);
                    seriesPointxx1y2.ColorSerializable = "#e53d00";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx2y3 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay3)))});
                    xxxyx.Points.Add(seriesPointxx2y3);
                    seriesPointxx2y3.ColorSerializable = "#07a0c3";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx3y4 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay4)))});
                    xxxyx.Points.Add(seriesPointxx3y4);
                    seriesPointxx3y4.ColorSerializable = " #4abc95";
                    DevExpress.XtraCharts.SeriesPoint seriesPointxxxy5 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay5)))});
                    xxxyx.Points.Add(seriesPointxxxy5);
                    seriesPointxxxy5.ColorSerializable = "#f05365";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx1y6 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay6)))});
                    xxxyx.Points.Add(seriesPointxx1y6);
                    seriesPointxx1y6.ColorSerializable = "#d83e38";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx2y7 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay7)))});
                    xxxyx.Points.Add(seriesPointxx2y7);
                    seriesPointxx2y7.ColorSerializable = "#fdea3e";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx3y8 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay8)))});
                    xxxyx.Points.Add(seriesPointxx3y8);
                    seriesPointxx3y8.ColorSerializable = " #63bb35";
                    DevExpress.XtraCharts.SeriesPoint seriesPointxxxy9 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay9)))});
                    xxxyx.Points.Add(seriesPointxxxy9);
                    seriesPointxxxy9.ColorSerializable = "#233d6b";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx1y10 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay10)))});
                    xxxyx.Points.Add(seriesPointxx1y10);
                    seriesPointxx1y10.ColorSerializable = "#edb68c";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx2y11 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay11)))});
                    xxxyx.Points.Add(seriesPointxx2y11);
                    seriesPointxx2y11.ColorSerializable = "#928d93";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx3y12 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay12)))});
                    xxxyx.Points.Add(seriesPointxx3y12);
                    seriesPointxx3y12.ColorSerializable = " #8a59cd";

                    chartControl9.Series.Add(xxxyx);






                    DevExpress.XtraCharts.SeriesPoint seriesPointxxxy = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaat)))});
                    xxxy.Points.Add(seriesPointxxxy);
                    seriesPointxxxy.ColorSerializable = "#20CB48";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx1y = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaat)))});
                    xxxy.Points.Add(seriesPointxx1y);
                    seriesPointxx1y.ColorSerializable = "#365b81";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx2y = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((kağıtaat)))});
                    xxxy.Points.Add(seriesPointxx2y);
                    seriesPointxx2y.ColorSerializable = "#bc1000";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx3y = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((metalaat)))});
                    xxxy.Points.Add(seriesPointxx3y);
                    seriesPointxx3y.ColorSerializable = " #d6d600";

                    chartControl8.Series.Add(xxxy);










                    label182.Text = toplamatıkanaliz.ToString() + "(kg)";
                    chartControl7.Series.Add(fy);
                    XYDiagram diag2 = (XYDiagram)chartControl7.Diagram;

                    diag2.AxisX.Label.TextPattern = "{A:MMMM dd}";
                    label164.Text = label177.Text = (toplamatıkanaliz / toplamatıkanalizsayı).ToString();
                    label176.Text = toplamatıkanaliz.ToString();


                    chartControl6.Series.Add(ff);
                    XYDiagram diag = (XYDiagram)chartControl6.Diagram;

                    diag.AxisX.Label.TextPattern = "{A:MMMM dd}";
                    label164.Text = label177.Text = (toplamatıkanaliz / toplamatıkanalizsayı).ToString();
                    label176.Text = toplamatıkanaliz.ToString();


                    chartControl12.Series.Add(fyz);
                    chartControl12.Series.Add(fyz1);
                    chartControl12.Series.Add(fyz2);
                    chartControl12.Series.Add(fyz3);
                    XYDiagram diag3 = (XYDiagram)chartControl12.Diagram;

                    diag.AxisX.Label.TextPattern = "{A:MMMM dd}";












                    DevExpress.XtraCharts.SeriesPoint seriesPointxxx = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                    xxx.Points.Add(seriesPointxxx);
                    seriesPointxxx.ColorSerializable = "#20CB48";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx1 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});
                    xxx.Points.Add(seriesPointxx1);
                    seriesPointxx1.ColorSerializable = "#365b81";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx2 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((kağıtaa)))});
                    xxx.Points.Add(seriesPointxx2);
                    seriesPointxx2.ColorSerializable = "#bc1000";

                    DevExpress.XtraCharts.SeriesPoint seriesPointxx3 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((metalaa)))});
                    xxx.Points.Add(seriesPointxx3);
                    seriesPointxx3.ColorSerializable = " #d6d600";
                    label200.Text = (metalaa + plastikaa + camaa + kağıtaa).ToString();
                    chartControl1.Series.Add(xxx);











                    int gecici;
                    int[] sayilar = new int[4] { plastikaa, metalaa, camaa, kağıtaa };
                    for (int i = 0; i < sayilar.Length - 1; i++)
                    {
                        for (int j = i; j < sayilar.Length; j++)
                        {
                            // >(büyük) işareti <(küçük ) olarak değiştirilirse büyükten küçüğe sıralanır
                            if (sayilar[i] < sayilar[j])
                            {
                                gecici = sayilar[j];
                                sayilar[j] = sayilar[i];
                                sayilar[i] = gecici;
                            }

                        }

                    }
                    if (sayilar[0] == metalaa)
                    {
                        label172.Text = "Metal";
                        DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                        fffff.Points.Add(seriesPointe);
                        seriesPointe.ColorSerializable = "#C0504D";
                        DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                        fffff.Points.Add(seriesPointf);
                        seriesPointf.ColorSerializable = "#585554";
                        chartControl2.Series.Add(fffff);
                        if (sayilar[1] == camaa)
                        {
                            label171.Text = "Cam";
                            DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                            ffff.Points.Add(seriesPointc);
                            seriesPointc.ColorSerializable = "#20CB48";
                            DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                            ffff.Points.Add(seriesPointd);
                            seriesPointd.ColorSerializable = "#585554";
                            chartControl3.Series.Add(ffff);


                            if (sayilar[2] == kağıtaa)
                            {
                                label169.Text = "Kağıt";
                                label170.Text = "Plastik";
                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffffff);



                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fff);

                            }
                            else if (sayilar[2] == plastikaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fff);



                                label169.Text = "Plastik";
                                label170.Text = "Kağıt";


                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffffff);

                            }
                        }
                        else if (sayilar[1] == kağıtaa)
                        {
                            label171.Text = "Kağıt";
                            DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                            ffffff.Points.Add(seriesPointg);
                            seriesPointg.ColorSerializable = "#2059CB";
                            DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                            ffffff.Points.Add(seriesPointh);
                            seriesPointh.ColorSerializable = "#585554";
                            chartControl3.Series.Add(ffffff);

                            if (sayilar[2] == camaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffff);


                                label169.Text = "Cam";
                                label170.Text = "Plastik";




                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fff);


                            }
                            else if (sayilar[2] == plastikaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fff);


                                label169.Text = "Plastik";
                                label170.Text = "Cam";



                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffff);
                            }
                        }
                        else if (sayilar[1] == plastikaa)
                        {
                            label171.Text = "Plastik";
                            DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                            seriesPointa.ColorSerializable = "#F23C18";
                            fff.Points.Add(seriesPointa);

                            DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                            fff.Points.Add(seriesPointb);
                            seriesPointb.ColorSerializable = "#585554";
                            chartControl3.Series.Add(fff);
                            if (sayilar[2] == camaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffff);





                                label169.Text = "Cam";
                                label170.Text = "Kağıt";


                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffffff);

                            }
                            else if (sayilar[2] == kağıtaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffffff);


                                label169.Text = "Kağıt";
                                label170.Text = "Cam";


                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffff);


                            }
                        }
                    }
                    else if (sayilar[0] == camaa)
                    {
                        label172.Text = "Cam";
                        DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                        ffff.Points.Add(seriesPointc);
                        seriesPointc.ColorSerializable = "#20CB48";
                        DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                        ffff.Points.Add(seriesPointd);
                        seriesPointd.ColorSerializable = "#585554";
                        chartControl2.Series.Add(ffff);


                        if (sayilar[1] == metalaa)
                        {
                            label171.Text = "Metal";
                            DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                            fffff.Points.Add(seriesPointe);
                            seriesPointe.ColorSerializable = "#C0504D";
                            DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                            fffff.Points.Add(seriesPointf);
                            seriesPointf.ColorSerializable = "#585554";
                            chartControl3.Series.Add(fffff);
                            if (sayilar[2] == kağıtaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffffff);


                                label169.Text = "Kağıt";
                                label170.Text = "Plastik";

                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fff);

                            }
                            else if (sayilar[2] == plastikaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fff);

                                label169.Text = "Plastik";
                                label170.Text = "Kağıt";



                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffffff);

                            }
                        }
                        else if (sayilar[1] == kağıtaa)
                        {
                            label171.Text = "Kağıt";
                            DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                            ffffff.Points.Add(seriesPointg);
                            seriesPointg.ColorSerializable = "#2059CB";
                            DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                            ffffff.Points.Add(seriesPointh);
                            seriesPointh.ColorSerializable = "#585554";
                            chartControl3.Series.Add(ffffff);

                            if (sayilar[2] == metalaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fffff);

                                label169.Text = "Metal";
                                label170.Text = "Plastik";


                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fff);
                            }
                            else if (sayilar[2] == plastikaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fff);


                                label169.Text = "Plastik";
                                label170.Text = "Metal";




                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fffff);
                            }
                        }
                        else if (sayilar[1] == plastikaa)
                        {
                            label171.Text = "Plastik";
                            DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                            seriesPointa.ColorSerializable = "#F23C18";
                            fff.Points.Add(seriesPointa);

                            DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                            fff.Points.Add(seriesPointb);
                            seriesPointb.ColorSerializable = "#585554";
                            chartControl3.Series.Add(fff);
                            if (sayilar[2] == metalaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fffff);

                                label169.Text = "Metal";
                                label170.Text = "Kağıt";



                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffffff);

                            }
                            else if (sayilar[2] == kağıtaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffffff);



                                label169.Text = "Kağıt";
                                label170.Text = "Metal";


                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fffff);
                            }
                        }
                    }
                    else if (sayilar[0] == kağıtaa)
                    {
                        label172.Text = "Kağıt";
                        DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                        ffffff.Points.Add(seriesPointg);
                        seriesPointg.ColorSerializable = "#2059CB";
                        DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                        ffffff.Points.Add(seriesPointh);
                        seriesPointh.ColorSerializable = "#585554";
                        chartControl2.Series.Add(ffffff);

                        if (sayilar[1] == metalaa)
                        {
                            label171.Text = "Metal";
                            DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                            fffff.Points.Add(seriesPointe);
                            seriesPointe.ColorSerializable = "#C0504D";
                            DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                            fffff.Points.Add(seriesPointf);
                            seriesPointf.ColorSerializable = "#585554";
                            chartControl3.Series.Add(fffff);
                            if (sayilar[2] == camaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffff);




                                label169.Text = "Cam";
                                label170.Text = "Plastik";



                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fff);
                            }
                            else if (sayilar[2] == plastikaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fff);




                                label169.Text = "Plastik";
                                label170.Text = "Cam";



                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffff);
                            }
                        }
                        else if (sayilar[1] == camaa)
                        {
                            label171.Text = "Cam";
                            DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                            ffff.Points.Add(seriesPointc);
                            seriesPointc.ColorSerializable = "#20CB48";
                            DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                            ffff.Points.Add(seriesPointd);
                            seriesPointd.ColorSerializable = "#585554";
                            chartControl3.Series.Add(ffff);


                            if (sayilar[2] == metalaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fffff);




                                label169.Text = "Metal";
                                label170.Text = "Plastik";



                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fff);

                            }
                            else if (sayilar[2] == plastikaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                                seriesPointa.ColorSerializable = "#F23C18";
                                fff.Points.Add(seriesPointa);

                                DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                                fff.Points.Add(seriesPointb);
                                seriesPointb.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fff);



                                label169.Text = "Plastik";
                                label170.Text = "Metal";




                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fffff);
                            }
                        }
                        else if (sayilar[1] == plastikaa)
                        {
                            label171.Text = "Plastik";
                            DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                            seriesPointa.ColorSerializable = "#F23C18";
                            fff.Points.Add(seriesPointa);

                            DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                            fff.Points.Add(seriesPointb);
                            seriesPointb.ColorSerializable = "#585554";
                            chartControl3.Series.Add(fff);
                            if (sayilar[2] == metalaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fffff);




                                label169.Text = "Metal";
                                label170.Text = "Cam";




                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffff);
                            }
                            else if (sayilar[2] == camaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffff);




                                label169.Text = "Cam";
                                label170.Text = "Metal";


                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fffff);



                            }
                        }
                    }
                    else if (sayilar[0] == plastikaa)
                    {
                        label172.Text = "Plastik";
                        DevExpress.XtraCharts.SeriesPoint seriesPointa = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((plastikaa)))});

                        seriesPointa.ColorSerializable = "#F23C18";
                        fff.Points.Add(seriesPointa);

                        DevExpress.XtraCharts.SeriesPoint seriesPointb = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-plastikaa)))});
                        fff.Points.Add(seriesPointb);
                        seriesPointb.ColorSerializable = "#585554";
                        chartControl2.Series.Add(fff);
                        if (sayilar[1] == metalaa)
                        {
                            label171.Text = "Metal";
                            DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                            fffff.Points.Add(seriesPointe);
                            seriesPointe.ColorSerializable = "#C0504D";
                            DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                            fffff.Points.Add(seriesPointf);
                            seriesPointf.ColorSerializable = "#585554";
                            chartControl3.Series.Add(fffff);
                            if (sayilar[2] == camaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffff);



                                label169.Text = "Cam";
                                label170.Text = "Kağıt";




                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffffff);
                            }
                            else if (sayilar[2] == kağıtaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffffff);




                                label169.Text = "Kağıt";
                                label170.Text = "Cam";



                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffff);

                            }
                        }
                        else if (sayilar[1] == camaa)
                        {
                            label171.Text = "Cam";
                            DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                            ffff.Points.Add(seriesPointc);
                            seriesPointc.ColorSerializable = "#20CB48";
                            DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                            ffff.Points.Add(seriesPointd);
                            seriesPointd.ColorSerializable = "#585554";
                            chartControl3.Series.Add(ffff);


                            if (sayilar[2] == metalaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fffff);

                                label169.Text = "Metal";
                                label170.Text = "Kağıt";






                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffffff);
                            }
                            else if (sayilar[2] == kağıt)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                                ffffff.Points.Add(seriesPointg);
                                seriesPointg.ColorSerializable = "#2059CB";
                                DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                                ffffff.Points.Add(seriesPointh);
                                seriesPointh.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffffff);



                                label169.Text = "Kağıt";
                                label170.Text = "Metal";




                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fffff);
                            }
                        }
                        else if (sayilar[1] == kağıt)
                        {
                            label171.Text = "Kağıt";
                            DevExpress.XtraCharts.SeriesPoint seriesPointg = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((kağıtaa)))});
                            ffffff.Points.Add(seriesPointg);
                            seriesPointg.ColorSerializable = "#2059CB";
                            DevExpress.XtraCharts.SeriesPoint seriesPointh = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-kağıtaa)))});
                            ffffff.Points.Add(seriesPointh);
                            seriesPointh.ColorSerializable = "#585554";
                            chartControl3.Series.Add(ffffff);

                            if (sayilar[2] == metalaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl5.Series.Add(fffff);


                                label169.Text = "Metal";
                                label170.Text = "Cam";






                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl4.Series.Add(ffff);
                            }
                            else if (sayilar[2] == camaa)
                            {
                                DevExpress.XtraCharts.SeriesPoint seriesPointc = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((camaa)))});
                                ffff.Points.Add(seriesPointc);
                                seriesPointc.ColorSerializable = "#20CB48";
                                DevExpress.XtraCharts.SeriesPoint seriesPointd = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((toplamatıkanaliz-camaa)))});
                                ffff.Points.Add(seriesPointd);
                                seriesPointd.ColorSerializable = "#585554";
                                chartControl5.Series.Add(ffff);


                                label169.Text = "Cam";
                                label170.Text = "Metal";


                                DevExpress.XtraCharts.SeriesPoint seriesPointe = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((metalaa)))});
                                fffff.Points.Add(seriesPointe);
                                seriesPointe.ColorSerializable = "#C0504D";
                                DevExpress.XtraCharts.SeriesPoint seriesPointf = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
              ((object)((toplamatıkanaliz-metalaa)))});
                                fffff.Points.Add(seriesPointf);
                                seriesPointf.ColorSerializable = "#585554";
                                chartControl4.Series.Add(fffff);

                            }
                        }
                    }



























                }



                siticonePanel3.Visible = true;
                siticonePanel2.Visible = false;
                if (bildirimmenüsüaçıkmı == true)
                {
                    panel6.Visible = false;
                    bildirimmenüsüaçıkmı = false;
                }
                if (Hesapaçıkmı == true)
                {
                    timer1.Interval = 1;
                    timer1.Start();
                    siticoneImageButton1.Enabled = false;
                    siticoneButton43.Visible = false;
                    siticoneButton44.Visible = false;




                    siticoneButton48.Visible = false;
                    siticoneButton49.Visible = false;
                    siticoneButton50.Visible = false;
                }
                panel6.Visible = false;
                panel4.Visible = false;

                label4.Visible = true;
                chromiumWebBrowser2.Visible = false;
                label3.Visible = false;
                siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                siticoneButton12.Visible = false;
                siticoneTextBox1.Visible = false;
                siticoneComboBox1.Visible = false;
                siticonePictureBox2.Visible = false;
                label1.Visible = false;
                siticonePictureBox3.Visible = false;
                siticoneButton22.Visible = false;
                siticoneButton23.Visible = false;
                siticoneButton24.Visible = false;
                siticoneButton25.Visible = false;
                siticoneButton14.Visible = true;
                siticoneButton15.Visible = true;
                siticoneButton16.Visible = true;
                siticoneButton17.Visible = true;
                siticoneButton18.Visible = true;
                siticoneButton19.Visible = true;
                siticoneButton20.Visible = true;
                siticoneButton21.Visible = true;
                siticoneButton13.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton4.FillColor = Color.FromArgb(56, 60, 64);
                siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton6.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton7.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
            }
            else
            {
                MessageBox.Show("Bu özelliğe erişebilmeniz için oturum açmanız gerekmektedir");
            }
        }

        private void Oğ_Click(object sender, EventArgs e)
        {
            siticoneButton92.Visible = false;
            SiticoneButton oü = (SiticoneButton)sender;
            kayıtsınıfı ğpü = (kayıtsınıfı)oü.Tag;
            radCalendar3.SelectedDate = ğpü.zamanx;
            radRadialGauge20.Value = ğpü.toplamatıkoranx;
            radRadialGauge19.Value = ğpü.geridönüştürülenatığıntoplamatığaoranıx;
            radRadialGauge25.Value = ğpü.metalatıkoranx;
            radRadialGauge21.Value = ğpü.camatıkoranx;
            radRadialGauge22.Value = ğpü.kağıtatıkoranx;
            radRadialGauge23.Value = ğpü.plastikatıkoranx;
            radRadialGauge24.Value = ğpü.evselatıkorax;
            radRadialGauge26.Value = ğpü.gdplastikoran;
            radRadialGauge27.Value = ğpü.gdmetaloran;
            radRadialGauge28.Value = ğpü.gdcamoran;
            radRadialGauge29.Value = ğpü.gdkağıtoran;
            radRating2.Value = ğpü.kayıtdeğerlendirme;
            label206.Text = ğpü.kayıtbaşlıkx;
            label222.Text = $"Toplam ağırlık\n{ğpü.metalatıkx} kg";
            label224.Text = $"Toplam ağırlık\n{ğpü.camatıkx} kg";
            label225.Text = $"Toplam ağırlık\n{ğpü.kağıtatıkx} kg";
            label226.Text = $"Toplam ağırlık\n{ğpü.plastikatıkx} kg";
            int yüğ = ğpü.toplamatıkx - (ğpü.metalatıkx + ğpü.camatıkx + ğpü.kağıtatıkx + ğpü.plastikatıkx);
            label223.Text = $"Toplam ağırlık\n{yüğ} kg";
            label220.Text = $"Toplam ağırlık\n{ğpü.gdplastik} kg";
            label218.Text = $"Toplam ağırlık\n{ğpü.gdmetal} kg";
            label219.Text = $"Toplam ağırlık\n{ğpü.gdcam} kg";
            label221.Text = $"Toplam ağırlık\n{ğpü.gdkağıt} kg";

        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            panel26.Visible = false;
            panel25.Visible = true;
            siticonePanel3.Visible = false;
            siticonePanel2.Visible = false;
            panel11.Visible = false;
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;

            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;
            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            panel6.Visible = false;
            panel4.Visible = false;

            label4.Visible = true;
            chromiumWebBrowser2.Visible = false;
            siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
            siticoneButton8.Visible = false;
            siticoneButton14.Visible = false;
            siticoneButton15.Visible = false;
            siticoneButton16.Visible = false;
            siticoneButton17.Visible = false;
            siticoneButton18.Visible = false;
            siticoneButton19.Visible = false;
            label3.Visible = false;
            siticoneButton20.Visible = false;
            siticoneButton21.Visible = false;
            siticoneButton10.Visible = false;
            siticoneButton11.Visible = false;
            siticoneButton12.Visible = false;
            siticoneTextBox1.Visible = false;
            siticoneComboBox1.Visible = false;
            siticonePictureBox2.Visible = false;
            label1.Visible = false;
            siticonePictureBox3.Visible = false;
            siticoneButton22.Visible = true;
            siticoneButton23.Visible = true;
            siticoneButton24.Visible = true;
            siticoneButton25.Visible = true;
            siticoneButton13.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton5.FillColor = Color.FromArgb(56, 60, 64);
            siticoneButton6.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton7.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
        }
        //yapılacak
        void bildirimlistele()

        {
            
            int av = dataa.Bildirim.Count;
            int uyu = 0;
           
            flowLayoutPanel4.Controls.Clear();
            foreach (bild item in dataa.Bildirim)
            {
                SiticoneButton nmm = new SiticoneButton();
                nmm.Animated = true;
                nmm.AnimatedGIF = true;
                nmm.BorderRadius = 5;
                nmm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
                nmm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
                nmm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
                nmm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
                nmm.FillColor = System.Drawing.Color.DarkGreen;
                nmm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                nmm.ForeColor = System.Drawing.Color.White;
                nmm.Location = new System.Drawing.Point(3, 3);
                nmm.Name = item.Açıklama;
                int yyğ = flowLayoutPanel4.Width - 29; int yyğ2 = flowLayoutPanel4.Height / 5;
                nmm.Size = new System.Drawing.Size(yyğ, yyğ2);
                nmm.TabIndex = 1;
                nmm.Text = item.Konu;
                nmm.Tag = item.Tarih;
                flowLayoutPanel4.Controls.Add(nmm);
                uyu += 1;
                nmm.Click += Nmm_Click;
                //this.Scale(new SizeF(1, 1));
                //this.Width = SimdikiWidth;
                //this.Height= SimdikiHeight;
                //this.Location = new Point(0, 0);
                //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                //Rectangle ClienCozunurluk = new Rectangle();
                //ClienCozunurluk = Screen.GetBounds(ClienCozunurluk);
                //float OranWidth = ((float)ClienCozunurluk.Width / (float)SimdikiWidth);
                //float OranHeight = ((float)ClienCozunurluk.Height / (float)SimdikiHeight);
                // this.Scale(new SizeF(OranWidth, OranHeight)); 
            }

        }
        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            panel26.Visible = true;
            panel25.Visible = false;
            siticonePanel3.Visible = false;
            panel11.Visible = false;
            siticonePanel2.Visible = false;
            panel11.Visible = false;
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            panel6.Visible = false;
            panel4.Visible = false;

            label4.Visible = true;
            chromiumWebBrowser2.Visible = false;
            label3.Visible = false;
            siticoneButton13.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton6.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton7.FillColor = Color.FromArgb(56, 60, 64); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            panel26.Visible = false;
            panel25.Visible = false;
            siticonePanel3.Visible = false;
            siticonePanel2.Visible = false;
            panel11.Visible = true;

            siticoneComboBox1.Visible = false;
            siticoneComboBox2.Visible = false;
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            siticoneButton56.Visible = true;
            siticoneButton57.Visible = true;
            siticoneButton58.Visible = true;
            siticoneButton59.Visible = true;
            siticoneButton60.Visible = true;
            panel6.Visible = false;
            panel4.Visible = false;

            label4.Visible = true;
            chromiumWebBrowser2.Visible = false;
            siticoneButton22.Visible = false;
            siticoneButton23.Visible = false;
            siticoneButton24.Visible = false;
            siticoneButton25.Visible = false;
            siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
            siticoneButton8.Visible = false;
            siticoneButton14.Visible = false;
            siticoneButton15.Visible = false;
            siticoneButton16.Visible = false;
            siticoneButton17.Visible = false;
            label3.Visible = false;
            siticoneButton18.Visible = false;
            siticoneButton19.Visible = false;
            siticoneButton20.Visible = false;
            siticoneButton21.Visible = false;
            siticoneButton10.Visible = false;
            siticoneButton11.Visible = false;
            siticoneButton12.Visible = false;
            siticoneTextBox1.Visible = false;
            siticoneComboBox1.Visible = false;
            siticonePictureBox2.Visible = false;
            label1.Visible = false;
            siticonePictureBox3.Visible = false;
            panel6.Visible = false;
            panel4.Visible = false;

            label4.Visible = true;
            chromiumWebBrowser2.Visible = false;
            siticoneButton13.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
            label3.Visible = false;
            siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton6.FillColor = Color.FromArgb(56, 60, 64);
            siticoneButton7.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
        }

        private void siticoneButton9_Click(object sender, EventArgs e)
        {
            siticonePanel18.Visible = false;
            panel26.Visible = false;
            panel25.Visible = false;
            siticonePanel3.Visible = false;
            siticonePanel2.Visible = false;
            panel11.Visible = false;
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;

            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;
            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            panel6.Visible = false;
            panel4.Visible = false;
            panel11.Visible = false;
            label4.Visible = true;
            chromiumWebBrowser2.Visible = false;
            siticoneButton22.Visible = false;
            siticoneButton23.Visible = false;
            siticoneButton24.Visible = false;
            siticoneButton25.Visible = false;
            siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
            siticoneButton8.Visible = false;
            siticoneButton14.Visible = false;
            siticoneButton15.Visible = false;
            siticoneButton16.Visible = false;
            siticoneButton17.Visible = false;
            label3.Visible = false;
            siticoneButton18.Visible = false;
            siticoneButton19.Visible = false;
            siticoneButton20.Visible = false;
            siticoneButton21.Visible = false;
            siticoneButton10.Visible = false;
            siticoneButton11.Visible = false;
            siticoneButton12.Visible = false;
            siticoneTextBox1.Visible = true;
            siticoneComboBox1.Visible = true;
            siticonePictureBox2.Visible = false;
            label1.Visible = false;
            siticonePictureBox3.Visible = false;
            siticoneButton13.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);

            siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton6.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton9.FillColor = Color.FromArgb(56, 60, 64);
        }

        private void siticoneButton13_Click(object sender, EventArgs e)
        {
            panel26.Visible = false;
            panel25.Visible = false;
            siticonePanel3.Visible = false;
            label1.Text = "Bal Nature";
            panel11.Visible = false;
            siticonePanel2.Visible = false;
            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;
            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            panel6.Visible = false;
            panel4.Visible = false;

            label4.Visible = false;
            chromiumWebBrowser2.Visible = true;
            siticoneButton22.Visible = false;
            siticoneButton23.Visible = false;
            siticoneButton24.Visible = false;
            siticoneButton25.Visible = false;
            siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
            siticoneButton8.Visible = false;
            siticoneButton14.Visible = false;
            siticoneButton15.Visible = false;
            siticoneButton16.Visible = false;
            siticoneButton17.Visible = false;
            siticoneButton18.Visible = false;
            siticoneButton19.Visible = false;
            label3.Visible = true;
            siticoneButton20.Visible = false;
            siticoneButton21.Visible = false;
            siticoneButton10.Visible = false;
            siticoneButton11.Visible = false;
            siticoneButton12.Visible = false;
            siticoneTextBox1.Visible = false;
            siticoneComboBox1.Visible = false;
            siticonePictureBox2.Visible = true;
            label1.Visible = true;
            siticonePictureBox3.Visible = true;
            siticoneButton13.FillColor = Color.FromArgb(56, 60, 64);
            siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton6.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
        }
        #endregion
        #region üst kısmın diğer işlemleri
        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Green;
            label2.Text = "FOR Future";
            label49.ForeColor = Color.Green;
            label49.Text = "FOR Future";
        }
        public static Image GenerateProfilePhoto(string name)
        {
            // Create a new bitmap
            var bitmap = new Bitmap(105, 105);

            // Create a graphics object from the bitmap
            var g = Graphics.FromImage(bitmap);

            // Set the smoothing mode to antialiasing
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a new solid brush for the background color
            var brush = new SolidBrush(Color.FromArgb(100, 180, 220));

            // Create a rounded rectangle for the bitmap
            var rect = new Rectangle(0, 0, 100, 100);

            // Draw the rounded rectangle
            g.FillEllipse(brush, rect);

            // Set the text alignment to center
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            // Create a new solid brush for the text color
            var brushText = new SolidBrush(Color.White);

            // Get the first letter of the name
            var firstLetter = name.Substring(0, 1).ToUpper();

            // Measure the size of the text
            SizeF textSize = g.MeasureString(firstLetter, new Font("Arial", 20));

            // Calculate the position to center the text
            float x = (bitmap.Width - textSize.Width) / 2;
            float y = (bitmap.Height - textSize.Height) / 2;

            // Draw the first letter in the center of the bitmap
            g.DrawString(firstLetter, new Font("Arial", 30), brushText, x-8, y-8);

            

            // Return the generated image
            return bitmap;

        }
        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
            label2.Text = "BAL Nature";
            label49.ForeColor = Color.White;
            label49.Text = "BAL Nature";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            indirilenlerdemi = 0;
            flowLayoutPanel15.Visible = false;
            flowLayoutPanel13.Visible = false; ;
            flowLayoutPanel14.Visible = false; ;
            panel26.Visible = false;
            panel25.Visible = false;
            siticonePanel3.Visible = false;
            panel11.Visible = false;
            siticonePanel2.Visible = false;
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;
            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;

            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            if (indirilenkısmıaçıkmı == true)
            {
                timer2.Stop();
                tıklı = 1;
                siticonePictureBox2.FillColor = Color.FromArgb(50, 60, 64);
                siticonePictureBox3.FillColor = Color.FromArgb(50, 60, 64);
                label1.ForeColor = Color.FromArgb(50, 60, 64);
                panel6.Visible = false;
                panel4.Visible = false;
                siticoneButton55.Visible = false;

                label4.Visible = false;
                chromiumWebBrowser2.Visible = true;
                siticoneButton22.Visible = false;
                siticoneButton23.Visible = false;
                siticoneButton24.Visible = false;
                siticoneButton25.Visible = false;
                siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton14.Visible = false;
                siticoneButton15.Visible = false;
                siticoneButton16.Visible = false;
                siticoneButton17.Visible = false;
                siticoneButton18.Visible = false;
                siticoneButton19.Visible = false;
                label3.Visible = true;
                siticoneButton20.Visible = false;
                siticoneButton21.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                siticoneButton12.Visible = false;
                siticoneTextBox1.Visible = false;
                siticoneComboBox1.Visible = false;
                siticonePictureBox2.Visible = true;
                label1.Visible = true;
                siticonePictureBox3.Visible = true;
                siticoneButton13.FillColor = Color.FromArgb(56, 60, 64);
                siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton6.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
                label3.Visible = true;
                label6.Visible = false;
                siticoneButton6.Visible = true;
                siticoneButton7.Visible = true;
                siticoneButton51.Visible = false;
                panel8.Visible = false;
                indirilenkısmıaçıkmı = false;
                siticoneButton54.Visible = false;

                siticoneButton53.Visible = false;
                siticoneButton2.Visible = true;
                siticoneButton3.Visible = true;
                siticoneButton4.Visible = true;
                siticoneButton5.Visible = true;
                siticoneButton9.Visible = true;
                siticoneButton13.Visible = true;
            }
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            panel6.Visible = false;
            panel4.Visible = false;

            chromiumWebBrowser2.LoadUrl("http://balnature.great-site.net/");

            chromiumWebBrowser2.AutoScrollOffset = new Point(0, 0);
            label4.Visible = false;
            chromiumWebBrowser2.Visible = true;
            siticoneButton22.Visible = false;
            siticoneButton23.Visible = false;
            siticoneButton24.Visible = false;
            siticoneButton25.Visible = false;
            siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
            siticoneButton8.Visible = false;
            siticoneButton14.Visible = false;
            siticoneButton15.Visible = false;
            siticoneButton16.Visible = false;
            siticoneButton17.Visible = false;
            siticoneButton18.Visible = false;
            siticoneButton19.Visible = false;
            label3.Visible = true;
            siticoneButton20.Visible = false;
            siticoneButton21.Visible = false;
            siticoneButton10.Visible = false;
            siticoneButton11.Visible = false;
            siticoneButton12.Visible = false;
            siticoneTextBox1.Visible = false;
            siticoneComboBox1.Visible = false;
            siticonePictureBox2.Visible = true;
            label1.Visible = true;
            siticonePictureBox3.Visible = true;
            siticoneButton13.FillColor = Color.FromArgb(56, 60, 64);
            siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton6.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
        }

        private void siticoneButton26_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneButton27_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        bool Kullanıcbutonuıaçıkmıkapalımı = false;
        private void siticoneImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton31_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton30_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton39_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton32_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton37_Click(object sender, EventArgs e)
        {

        }
        bool bildirimmenüsüaçıkmı = false;
        bool paneladı = false;//false bildirim true mesaj
        private void siticoneImageButton4_Click(object sender, EventArgs e)
        {
            radChat1.Visible = false;
            label44.Visible = false;
            linkLabel13.Visible = false;
            tableLayoutPanel42.Visible = false;
            paneladı = false;
            if (bildirimmenüsüaçıkmı == false)
            {
                pictureBox6.Image = BAL_Nature.Properties.Resources.notifications_active_FILL0_wght400_GRAD0_opsz48;
                label8.Text = "Bildirim";

                pictureBox6.Visible = true;
                label8.Visible = true;
                flowLayoutPanel4.Visible = true;
                panel6.Visible = true;
                bildirimmenüsüaçıkmı = true;
            }
            else
            {
                pictureBox6.Visible = false;
                label8.Visible = false;
                flowLayoutPanel4.Visible = false;
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string inecekurl;
        string inecekoyun = "Bottle";
        void panel27_Göster(string oyunadı, string oyunkısaaçıklama, Bitmap anaresim, Bitmap resim1, Bitmap resim2, Bitmap resim3, string geliştiren, string yayımlayıcı, string uygulamaboyutu, DateTime çıkışyılı, string oyuntürü, string minişsis, string minişlemci, string minram, string mingrsfikleri, string minmimari, string maxişsis, string maxişlemci, string maxram, string maxgrsfikleri, string maxmimari, string url, string oyunad, int indi)
        {
            if (indi == 0)
            {
                if (indiriliyor == 1)
                {
                    if (oyunadı == label362.Text)
                    {
                        siticoneButton109.Text = "İndiriliyor";
                    }
                    else
                    {
                        siticoneButton109.Text = "Al";
                    }
                }
                else
                {

                    siticoneButton109.Text = "Al";
                }

            }
            else
            {
                siticoneButton109.Text = "Oyna";

            }
            label304.Text = oyunadı;
            label305.Text = oyunkısaaçıklama;
            inecekurl = url;
            inecekoyun = oyunad;
            panel27.Visible = true;
            siticonePictureBox252.Image = siticonePictureBox253.Image = anaresim;
            siticonePictureBox254.Image = resim1;
            siticonePictureBox255.Image = resim2;
            siticonePictureBox251.Image = resim3;
            label312.Text = geliştiren;
            label313.Text = yayımlayıcı;
            label314.Text = uygulamaboyutu;
            label317.Text = çıkışyılı.ToShortDateString();
            label319.Text = oyuntürü;
            label346.Text = minişsis;
            label347.Text = minişlemci;
            label348.Text = minram;
            label349.Text = mingrsfikleri;
            label350.Text = minmimari;
            label351.Text = maxişsis;
            label352.Text = maxişlemci;
            label353.Text = maxram;
            label354.Text = maxgrsfikleri;
            label355.Text = maxmimari;

        }
        private void siticoneImageButton3_Click(object sender, EventArgs e)
        {
            paneladı = true;
            if (bildirimmenüsüaçıkmı == false)
            {
                tableLayoutPanel42.Visible = true;
                radChat1.Visible = true;
                label44.Visible = false;
                linkLabel13.Visible = false;
                pictureBox6.Visible = true;
                label8.Visible = true;
                pictureBox6.Image = BAL_Nature.Properties.Resources.forum_FILL0_wght400_GRAD0_opsz48;
                label8.Text = "  Forum";
                flowLayoutPanel4.Visible = false;
                panel6.Visible = true;
                bildirimmenüsüaçıkmı = true;
            }
            else
            {
                pictureBox6.Visible = false;
                label8.Visible = false;
                flowLayoutPanel4.Visible = false;
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
        }
        #endregion
        #region indirilen kısmı
        bool indirilenkısmıaçıkmı = false;

        void yanpaneleoyunekle(Bitmap resimyan, string isim, string Oyunad)
        {


            SiticoneGradientPanel asd = new SiticoneGradientPanel();
            System.Windows.Forms.Label fgh = new System.Windows.Forms.Label();
            SiticoneButton dfg1 = new SiticoneButton();
            SiticoneButton dfg = new SiticoneButton();
            SiticonePictureBox sdf = new SiticonePictureBox();
            sdf.BackColor = System.Drawing.Color.Transparent;
            sdf.BorderRadius = 8;
            sdf.Image = resimyan;
            sdf.ImageRotate = 0F;
            sdf.Location = siticonePictureBox280.Location;
            sdf.Name = "siticonePictureBox280";
            sdf.Size = siticonePictureBox280.Size;
            sdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            sdf.TabIndex = 0;
            sdf.TabStop = false;
            sdf.MouseEnter += Fgh_MouseEnter; ; ;
            sdf.MouseLeave += Fgh_MouseLeave; ;
            sdf.Click += Sdf_Click;
            sdf.Tag = isim;
            dfg.BackColor = System.Drawing.Color.Transparent;
            dfg.BorderRadius = 18;
            dfg.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            dfg.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            dfg.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            dfg.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            dfg.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dfg.Font = new System.Drawing.Font("Segoe UI", 9F);
            dfg.ForeColor = System.Drawing.Color.White;
            dfg.Image = global::BAL_Nature.Properties.Resources.more;
            dfg.ImageOffset = new System.Drawing.Point(1, 0);
            dfg.Location = siticoneButton116.Location;
            dfg.Name = "siticoneButton116";
            dfg.Size = siticoneButton116.Size;
            dfg.TabIndex = 3;
            dfg.Visible = false;
            dfg.Tag = isim;
            dfg.Click += Sdf_Click;


            dfg1.BackColor = System.Drawing.Color.Transparent;
            dfg1.BorderRadius = 18;

            dfg1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dfg1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dfg1.ForeColor = System.Drawing.Color.White;
            dfg1.Image = global::BAL_Nature.Properties.Resources.play;
            dfg1.ImageOffset = new System.Drawing.Point(1, 0);
            dfg1.Location = siticoneButton52.Location;
            dfg1.Name = "siticoneButton52";
            dfg1.Size = siticoneButton52.Size;
            dfg1.TabIndex = 3;
            dfg1.Visible = false;
            dfg1.Enabled = true;
            dfg1.MouseEnter += Fgh_MouseEnter; ; ;
            dfg1.MouseLeave += Fgh_MouseLeave; ;
            dfg1.Tag = isim;
            dfg1.Click += Sdf_Click;

            fgh.BackColor = System.Drawing.Color.Transparent;
            fgh.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fgh.ForeColor = System.Drawing.Color.White;
            fgh.Location = label12.Location;
            fgh.Name = "label12";
            fgh.Size = label12.Size;
            fgh.TabIndex = 2;
            fgh.Text = Oyunad; fgh.Tag = isim;
            fgh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            fgh.MouseEnter += Fgh_MouseEnter;



            fgh.MouseLeave += Fgh_MouseLeave;



            asd.Tag = isim;
            asd.Controls.Add(sdf);
            asd.Controls.Add(dfg);
            asd.Controls.Add(dfg1);
            asd.Controls.Add(fgh);
            asd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(31)))));
            asd.Location = siticoneGradientPanel1.Location;
            asd.Margin = new System.Windows.Forms.Padding(3, 3, 3, 34);
            asd.Name = isim;
            asd.Size = siticoneGradientPanel1.Size;
            asd.TabIndex = 1;
            asd.MouseEnter += Fgh_MouseEnter; ;
            asd.MouseLeave += Fgh_MouseLeave; ;
            fgh.Click += Sdf_Click;
            flowLayoutPanel15.Controls.Add(asd);
        }

        private void Sdf_Click(object sender, EventArgs e)
        {

            if (sender is SiticoneGradientPanel)
            {
                SiticoneGradientPanel ghj = (SiticoneGradientPanel)sender;

                foreach (Control control in ghj.Controls)
                {
                    if (control is SiticoneButton) // Kontrol öğesi bir Button ise
                    {
                        if (control.Tag == "Bottle")
                        {
                            Process.Start("C:\\ProgramData\\SEAzer\\BALNature\\Bottle\\Bottle.exe");
                        }
                        if (control.Tag == "Isik")
                        {
                            Process.Start("C:\\ProgramData\\SEAzer\\BALNature\\Isik\\isik.exe");
                        }
                    }





                }
            }
            else
            {
                Control sender2 = (Control)sender;
                SiticoneGradientPanel parentControl = (SiticoneGradientPanel)sender2.Parent;
                foreach (Control control in parentControl.Controls)
                {
                    if (control is SiticoneButton) // Kontrol öğesi bir Button ise
                    {
                        if (control.Tag == "Bottle")
                        {
                            Process.Start("C:\\ProgramData\\SEAzer\\BALNature\\Bottle\\Bottle.exe");
                        }
                        if (control.Tag == "Isik")
                        {
                            Process.Start("C:\\ProgramData\\SEAzer\\BALNature\\Isik\\isik.exe");
                        }
                    }





                }
            }



        }

        private void Dfg1_MouseLeave(object sender, EventArgs e)
        {
            //SiticoneButton klş = (SiticoneButton)sender;
            //int R = 0, G = 0, B = 0;
            //if (klş.Tag == "Bottle")
            //{
            //    R = 22;
            //    G = 26;
            //    B = 31;
            //}
            //if (klş.Tag == "Isik")
            //{
            //    R = 33;
            //    G = 44;
            //    B = 22;
            //}

            //foreach (Control item in flowLayoutPanel15.Controls)
            //{
            //    if (sayıpaneldeneme == 0)
            //    {
            //        sayıpaneldeneme = 1;
            //        if (item.Controls[2].Name == klş.Name)
            //        {
            //            flowLayoutPanel15.Controls.Remove(item);
            //            SiticoneGradientPanel klşş = (SiticoneGradientPanel)item;
            //            klşş.Controls[1].Visible = false;
            //            klşş.Controls[2].Visible = false; klşş.FillColor = Color.FromArgb(R, G, B); flowLayoutPanel15.Controls.Add(klşş);
            //            sayıpaneldeneme = 1;
            //        }
            //    }
            //}
        }

        private void Dfg1_MouseEnter(object sender, EventArgs e)
        {
            dendemee1((Control)sender);

        }

        private void Fgh_MouseLeave(object sender, EventArgs e)
        {
            dendemee2((Control)sender);
        }

        private void Fgh_MouseEnter(object sender, EventArgs e)
        {
            dendemee1((Control)sender);
        }
        void parentt(SiticoneGradientPanel qq)
        {
            SiticoneGradientPanel panel = qq;
            panel.FillColor = Color.Green;
            foreach (Control control in panel.Controls)
            {
                if (control is SiticoneButton) // Kontrol öğesi bir Button ise
                {
                    control.Visible = true;
                }





            }
        }
        void parentt2(SiticoneGradientPanel qq)
        {
            SiticoneGradientPanel panel = qq;
            panel.FillColor = Color.Transparent;
            foreach (Control control in panel.Controls)
            {
                if (control is SiticoneButton) // Kontrol öğesi bir Button ise
                {
                    control.Visible = false;
                }





            }
        }
        void dendemee1(Control controls)
        {
            if (controls is SiticoneGradientPanel) // Kontrol öğesi bir Button ise
            {
                // Button'a özgü işlemler yapabilirsiniz
                parentt((SiticoneGradientPanel)controls);

            }
            if (controls is System.Windows.Forms.Label) // Kontrol öğesi bir Button ise
            {
                SiticoneGradientPanel parentControl = (SiticoneGradientPanel)controls.Parent;
                parentt(parentControl);
            }
            if (controls is SiticonePictureBox) // Kontrol öğesi bir Button ise
            {
                SiticoneGradientPanel parentControl = (SiticoneGradientPanel)controls.Parent;
                parentt(parentControl);
            }
            if (controls is SiticoneButton) // Kontrol öğesi bir Button ise
            {
                SiticoneGradientPanel parentControl = (SiticoneGradientPanel)controls.Parent;
                parentt(parentControl);
                bool p = controls.Enabled;
            }



            //if (sayıpaneldeneme == 1)
            //{
            //    sayıpaneldeneme = 0;
            //    SiticoneGradientPanel klş = (SiticoneGradientPanel)sender;
            //    foreach (Control item in flowLayoutPanel15.Controls)
            //    {
            //        if (item.Name == klş.Name)
            //        {
            //            flowLayoutPanel15.Controls.Remove(item);
            //            SiticoneGradientPanel klşş = (SiticoneGradientPanel)item;
            //            klşş.FillColor = Color.FromArgb(72, 9, 9);
            //            klşş.Controls[1].Visible = true;
            //            klşş.Controls[2].Visible = true; flowLayoutPanel15.Controls.Add(klşş);
            //        }
            //    }
            //}

        }
        void dendemee2(Control controls)
        {
            if (controls is SiticoneGradientPanel) // Kontrol öğesi bir Button ise
            {
                // Button'a özgü işlemler yapabilirsiniz
                parentt2((SiticoneGradientPanel)controls);

            }
            if (controls is System.Windows.Forms.Label) // Kontrol öğesi bir Button ise
            {
                SiticoneGradientPanel parentControl = (SiticoneGradientPanel)controls.Parent;
                parentt2(parentControl);
            }
            if (controls is SiticonePictureBox) // Kontrol öğesi bir Button ise
            {
                SiticoneGradientPanel parentControl = (SiticoneGradientPanel)controls.Parent;
                parentt2(parentControl);
            }
            if (controls is SiticoneButton) // Kontrol öğesi bir Button ise
            {
                SiticoneGradientPanel parentControl = (SiticoneGradientPanel)controls.Parent;
                parentt2(parentControl);
            }


        }
        private void Asd_MouseLeave(object sender, EventArgs e)
        {
            //if (sayıpaneldeneme == 0)
            //{
            //    sayıpaneldeneme = 1;
            //    System.Windows.Forms.Label klş = (System.Windows.Forms.Label)sender; int R = 0, G = 0, B = 0;
            //    if (klş.Tag == "Bottle")
            //    {
            //        R = 22;
            //        G = 26;
            //        B = 31;
            //    }
            //    if (klş.Tag == "Isik")
            //    {
            //        R = 33;
            //        G = 44;
            //        B = 22;
            //    }
            //    foreach (Control item in flowLayoutPanel15.Controls)
            //    {
            //        if (item.Controls[3].Text == klş.Text)
            //        {
            //            flowLayoutPanel15.Controls.Remove(item);
            //            SiticoneGradientPanel klşş = (SiticoneGradientPanel)item;
            //            klşş.Controls[1].Visible = false;
            //            klşş.Controls[2].Visible = false; klşş.FillColor = Color.FromArgb(R, G, B); flowLayoutPanel15.Controls.Add(klşş);

            //        }
            //    }
            //}
        }

        private void Asd_MouseEnter(object sender, EventArgs e)
        {

            dendemee1((Control)sender);
        }






        public void enüstoyun()
        {
            siticonePictureBox4.Image = BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_15_saat_00_25_34;
            tıklı = 1;
            siticoneProgressBar1.Value = 0;
            siticoneProgressBar2.Value = 0;
            siticoneProgressBar3.Value = 0;
            siticoneProgressBar4.Value = 0;
            siticoneProgressBar5.Value = 0;
            siticoneProgressBar6.Value = 0;
            timer2.Start();
            siticoneProgressBar1.FillColor = Color.DarkGray;
            siticoneProgressBar2.FillColor = Color.Gray;
            siticoneProgressBar3.FillColor = Color.Gray;
            siticoneProgressBar4.FillColor = Color.Gray;
            siticoneProgressBar5.FillColor = Color.Gray;
            siticoneProgressBar6.FillColor = Color.Gray;
            siticoneButton112.Visible = true; siticoneButton117.Visible = false;
        }
        private void siticoneImageButton5_Click(object sender, EventArgs e)
        {
            siticonePanel18.Visible = false;
            indirilenlerdemi = 0;
            panel4.Visible = false;
            enüstoyun();
            panel27.Visible = false;
            siticoneButton117.Visible = false;
            flowLayoutPanel15.Controls.Clear();
            flowLayoutPanel15.Visible = false;
            flowLayoutPanel13.Visible = false; ;
            flowLayoutPanel14.Visible = false; ;
            panel6.Visible = false;
            bildirimmenüsüaçıkmı = false;
            // panel27.Visible = false;
            panel26.Visible = false;
            siticonePanel3.Visible = false;
            siticonePanel2.Visible = false;
            label123.Visible = false;
            siticonePanel1.Visible = false;
            panel1.Visible = true;
            panel11.Visible = false;
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;

            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;
            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            siticoneProgressBar1.Value = 0;
            siticoneProgressBar2.Value = 0;
            siticoneProgressBar3.Value = 0;
            siticoneProgressBar4.Value = 0;
            siticoneProgressBar5.Value = 0;
            siticoneProgressBar6.Value = 0;
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            if (indirilenkısmıaçıkmı == false)
            {
                if (Directory.Exists("C:\\ProgramData\\SEAzer\\BALNature\\Bottle"))
                {
                    yanpaneleoyunekle(BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_18_saat_00_20_36, "Bottle", "Bottle and Advantures");

                }
                if (Directory.Exists("C:\\ProgramData\\SEAzer\\BALNature\\Isik"))
                {
                    yanpaneleoyunekle(BAL_Nature.Properties.Resources.y, "Isik", "Good Worker Boid");

                }
                else
                {

                }

                flowLayoutPanel15.Visible = true;
                panel25.Visible = false;
                timer2.Start();
                panel11.Visible = false;
                tıklı = 1;
                siticonePictureBox2.FillColor = Color.Silver;
                siticoneButton55.Visible = true;
                siticonePictureBox3.FillColor = Color.Silver;
                label1.ForeColor = Color.Silver;
                siticoneButton6.Visible = false;
                siticoneButton7.Visible = false;
                siticoneButton51.Visible = true;
                panel8.Visible = true;
                siticoneButton54.Visible = true;

                siticoneButton53.Visible = true;
                siticoneButton2.Visible = false;
                siticoneButton3.Visible = false;
                siticoneButton4.Visible = false;
                siticoneButton5.Visible = false;
                siticoneButton9.Visible = false;
                siticoneButton13.Visible = false;
                indirilenkısmıaçıkmı = true;
                chromiumWebBrowser2.Visible = false;


                siticoneButton22.Visible = false;
                siticoneButton23.Visible = false;
                siticoneButton24.Visible = false;
                siticoneButton25.Visible = false;
                siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton14.Visible = false;
                siticoneButton15.Visible = false;
                siticoneButton16.Visible = false;
                siticoneButton17.Visible = false;
                siticoneButton18.Visible = false;
                siticoneButton19.Visible = false;
                label3.Visible = false;

                label6.Visible = true;
                siticoneButton20.Visible = false;
                siticoneButton21.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                siticoneButton12.Visible = false;
                siticoneTextBox1.Visible = false;
                siticoneComboBox1.Visible = false;
                siticonePictureBox2.Visible = true;
                label1.Visible = true;
                siticonePictureBox3.Visible = true;
            }
            else
            {
                timer2.Stop();
                tıklı = 1;
                chromiumWebBrowser2.Visible = true;
                siticonePictureBox2.FillColor = Color.FromArgb(50, 60, 64);
                siticonePictureBox3.FillColor = Color.FromArgb(50, 60, 64);
                label1.ForeColor = Color.FromArgb(50, 60, 64);
                panel11.Visible = false;
                panel6.Visible = false;
                panel4.Visible = false;
                siticoneButton55.Visible = false;

                label4.Visible = false;
                chromiumWebBrowser2.Visible = true;
                siticoneButton22.Visible = false;
                siticoneButton23.Visible = false;
                siticoneButton24.Visible = false;
                siticoneButton25.Visible = false;
                siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton14.Visible = false;
                siticoneButton15.Visible = false;
                siticoneButton16.Visible = false;
                siticoneButton17.Visible = false;
                siticoneButton18.Visible = false;
                siticoneButton19.Visible = false;
                label3.Visible = true;
                siticoneButton20.Visible = false;
                siticoneButton21.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                siticoneButton12.Visible = false;
                siticoneTextBox1.Visible = false;
                siticoneComboBox1.Visible = false;
                siticonePictureBox2.Visible = true;
                label1.Visible = true;
                siticonePictureBox3.Visible = true;
                siticoneButton13.FillColor = Color.FromArgb(56, 60, 64);
                siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton6.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
                label3.Visible = true;
                label6.Visible = false;
                siticoneButton6.Visible = true;
                siticoneButton7.Visible = true;
                siticoneButton51.Visible = false;
                panel8.Visible = false;
                indirilenkısmıaçıkmı = false;
                siticoneButton54.Visible = false;

                siticoneButton53.Visible = false;
                siticoneButton2.Visible = true;
                siticoneButton3.Visible = true;
                siticoneButton4.Visible = true;
                siticoneButton5.Visible = true;
                siticoneButton9.Visible = true;
                siticoneButton13.Visible = true;
            }

        }

        private void siticonePictureBox3_Click(object sender, EventArgs e)
        {

        }
        bool panelaçıkmı = false;
        bool Hesapaçıkmı = false;
        bool oturumaçıkmı = false;
        private void siticoneImageButton1_Click_1(object sender, EventArgs e)
        {
            if (panelaçıkmı == true)
            {
                indirilenlerdemi = 0;
                flowLayoutPanel15.Visible = false;
                label117.Visible = false;
                label118.Visible = false;
                panelaçıkmı = false;
                panel1.Visible = true;
                siticonePanel1.Visible = false;
                siticoneButton56.Visible = false;
                siticoneButton57.Visible = false;
                chromiumWebBrowser2.Visible = true;
                siticonePictureBox2.FillColor = Color.FromArgb(50, 60, 64);
                siticonePictureBox3.FillColor = Color.FromArgb(50, 60, 64);
                label1.ForeColor = Color.FromArgb(50, 60, 64);
                label123.Visible = false;
                label3.Visible = true;
                panel11.Visible = false;
                panel6.Visible = false;
                panel4.Visible = false;
                siticoneButton55.Visible = false;

                label4.Visible = false;
                chromiumWebBrowser2.Visible = true;
                siticoneButton22.Visible = false;
                siticoneButton23.Visible = false;
                siticoneButton24.Visible = false;
                siticoneButton25.Visible = false;
                siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton14.Visible = false;
                siticoneButton15.Visible = false;
                siticoneButton16.Visible = false;
                siticoneButton17.Visible = false;
                siticoneButton18.Visible = false;
                siticoneButton19.Visible = false;
                label3.Visible = true;
                siticoneButton20.Visible = false;
                siticoneButton21.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                siticoneButton12.Visible = false;
                siticoneTextBox1.Visible = false;
                siticoneComboBox1.Visible = false;
                siticonePictureBox2.Visible = true;
                label1.Visible = true;
                siticonePictureBox3.Visible = true;
                siticoneButton13.FillColor = Color.FromArgb(56, 60, 64);
                siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton6.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
                label3.Visible = true;
                label6.Visible = false;
                siticoneButton6.Visible = true;
                siticoneButton7.Visible = true;
                siticoneButton51.Visible = false;
                panel8.Visible = false;
                indirilenkısmıaçıkmı = false;
                siticoneButton54.Visible = false;

                siticoneButton53.Visible = false;
                siticoneButton2.Visible = true;
                siticoneButton3.Visible = true;
                siticoneButton4.Visible = true;
                siticoneButton5.Visible = true;
                siticoneButton9.Visible = true;
                siticoneButton13.Visible = true;
                siticoneButton58.Visible = false;
                siticoneButton59.Visible = false;
                siticoneButton60.Visible = false;
                if (bildirimmenüsüaçıkmı == true)
                {
                    panel6.Visible = false;
                    bildirimmenüsüaçıkmı = false;
                }
                if (Hesapaçıkmı == true)
                {
                    timer1.Interval = 1;
                    timer1.Start();
                    siticoneImageButton1.Enabled = false;
                    siticoneButton43.Visible = false;
                    siticoneButton44.Visible = false;




                    siticoneButton48.Visible = false;
                    siticoneButton49.Visible = false;
                    siticoneButton50.Visible = false;
                }
                panel6.Visible = false;
                panel4.Visible = false;

                label4.Visible = false;
                chromiumWebBrowser2.Visible = true;
                siticoneButton22.Visible = false;
                siticoneButton23.Visible = false;
                siticoneButton24.Visible = false;
                siticoneButton25.Visible = false;
                siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton14.Visible = false;
                siticoneButton15.Visible = false;
                siticoneButton16.Visible = false;
                siticoneButton13.Visible = true;
                siticoneButton2.Visible = true;
                siticoneButton3.Visible = true;
                siticoneButton4.Visible = true;
                siticoneButton5.Visible = true;
                siticoneButton9.Visible = true;
                siticoneButton7.Visible = true;
                siticoneButton53.Visible = false;

                siticoneButton54.Visible = false;
                siticoneButton55.Visible = false;
                siticoneButton51.Visible = false;
                siticoneButton6.Visible = true;
                siticoneButton17.Visible = false;
                siticoneButton18.Visible = false;
                siticoneButton19.Visible = false;
                label3.Visible = true;
                siticoneButton20.Visible = false;
                siticoneButton21.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                siticoneButton12.Visible = false;
                siticoneTextBox1.Visible = false;
                siticoneComboBox1.Visible = false;
                siticonePictureBox2.Visible = true;
                label1.Visible = true;
                siticonePictureBox3.Visible = true;
                siticoneButton13.FillColor = Color.FromArgb(56, 60, 64);
                siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton6.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
            }
            else
            {
                if (Oturumaçıkmıı == 1)
                {
                    label6.Visible = false;












































































































































































































































































































































                    panel26.Visible = false;
                    panel25.Visible = false;
                    siticonePanel3.Visible = false;
                    panel11.Visible = false;
                    siticonePanel2.Visible = false;
                    siticoneTextBox4.BorderColor = Color.Black;
                    siticoneTextBox5.BorderColor = Color.Black;
                    label117.Visible = false;
                    label118.Visible = false;
                    siticonePanel1.Visible = true;
                    label122.Visible = false;
                    siticonePictureBox2.FillColor = Color.Silver;
                    siticoneButton55.Visible = true;
                    label123.Visible = true;
                    label3.Visible = false;
                    siticonePictureBox3.FillColor = Color.Silver;
                    label1.ForeColor = Color.Silver;
                    panelaçıkmı = true;
                    label119.Visible = false;
                    label120.Visible = false;
                    label121.Visible = false;
                    siticoneTextBox8.Visible = false;
                    siticoneTextBox9.Visible = false;
                    siticoneTextBox10.Visible = false;
                    panel4.Visible = false;
                    chromiumWebBrowser2.Visible = false;
                    panel6.Visible = false;
                    panel7.Visible = false;
                    panel8.Visible = false;
                    siticonePanel18.Visible = false;
                    label1.Text = "Bal Nature";
                    siticonePictureBox2.FillColor = Color.Silver;

                    siticonePictureBox3.FillColor = Color.Silver;
                    label1.ForeColor = Color.Silver;
                    siticoneButton1.Visible = false;
                    siticoneButton8.Visible = false;
                    siticoneButton10.Visible = false;
                    siticoneButton11.Visible = false;
                    siticoneButton12.Visible = false;
                    siticoneComboBox2.Visible = false;
                    siticonePictureBox2.Visible = true;
                    label1.Visible = true;
                    siticonePictureBox3.Visible = true;

                    panel11.Visible = false;
                    panel1.Visible = false;

                }
                else
                {
                    if (Hesapaçıkmı == false)
                    {

                        timer1.Interval = 1;
                        timer1.Start();
                        siticoneImageButton1.Enabled = false;

                    }
                    if (Hesapaçıkmı == true)
                    {
                        timer1.Interval = 1;
                        timer1.Start();
                        siticoneImageButton1.Enabled = false;
                        siticoneButton43.Visible = false;
                        siticoneButton44.Visible = false;




                        siticoneButton48.Visible = false;
                        siticoneButton49.Visible = false;
                        siticoneButton50.Visible = false;
                    }
                    panelaçıkmı = true;
                }
            }


        }
        int sayı1 = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int y = this.Width / (19 / 5);
            int yy = y / 79;

            if (Hesapaçıkmı == false)
            {


                if (sayı1 == 79)
                {
                    siticoneImageButton1.Enabled = true;
                    timer1.Stop();
                    Hesapaçıkmı = true;
                    if (oturumaçıkmı == false)
                    {
                        siticoneButton43.Visible = true;
                        siticoneButton44.Visible = true;
                    }
                    else
                    {

                        siticoneButton48.Visible = true;
                        siticoneButton49.Visible = true;
                        siticoneButton50.Visible = true;
                    }
                }
                else
                {
                    sayı1 += 1;

                    panel7.Left -= yy;
                }
            }
            if (Hesapaçıkmı == true)
            {


                if (sayı1 == 0)
                {
                    siticoneImageButton1.Enabled = true;
                    timer1.Stop();
                    Hesapaçıkmı = false;

                }
                else
                {
                    sayı1 -= 1;
                    panel7.Left += yy;
                }
            }


        }

        private void webControl1_Click(object sender, EventArgs e)
        {
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
        }
        void paneloyunekle(string paneloyunad, string paneloyunboyut, Bitmap Paneloyunresim, string paneloyunsürümartıkonum)
        {
            // 
            // siticonePanel17
            // 




            SiticoneButton wer = new SiticoneButton();
            wer.BorderRadius = 11;
            wer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            wer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            wer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            wer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            wer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            wer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            wer.ForeColor = System.Drawing.Color.White;
            wer.Location = siticoneButton114.Location;
            wer.Name = "siticoneButton115";
            wer.Size = siticoneButton114.Size;
            wer.TabIndex = 2;
            wer.Text = "Yönet";


            SiticoneButton wer1 = new SiticoneButton();
            wer1.BorderRadius = 11;
            wer1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            wer1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            wer1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            wer1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            wer1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            wer1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            wer1.ForeColor = System.Drawing.Color.White;
            wer1.Location = siticoneButton115.Location;
            wer1.Name = "siticoneButton114";
            wer1.Size = siticoneButton115.Size;
            wer1.TabIndex = 2;
            wer1.Text = "Oyna";
            wer1.Tag = paneloyunad;
            wer1.Click += Wer1_Click;


            System.Windows.Forms.Label ert = new System.Windows.Forms.Label();

            ert.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ert.ForeColor = System.Drawing.Color.DimGray;
            ert.Location = label366.Location;
            ert.Name = "label366";
            ert.Size = label366.Size;
            ert.TabIndex = 1;
            ert.Text = paneloyunsürümartıkonum;
            ert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;




            System.Windows.Forms.Label ert1 = new System.Windows.Forms.Label();
            ert1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ert1.ForeColor = System.Drawing.Color.DimGray;
            ert1.Location = label364.Location;
            ert1.Name = "label364";
            ert1.Size = label364.Size;
            ert1.TabIndex = 1;
            ert1.Text = paneloyunboyut;



            System.Windows.Forms.Label ert2 = new System.Windows.Forms.Label();
            ert2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ert2.ForeColor = System.Drawing.Color.White;
            ert2.Location = label365.Location;
            ert2.Name = "label365";
            ert2.Size = label365.Size;
            ert2.TabIndex = 1;
            ert2.Text = paneloyunad;




            SiticonePictureBox rty = new SiticonePictureBox();
            rty.BorderRadius = 10;
            rty.Image = Paneloyunresim;
            rty.ImageRotate = 0F;
            rty.Location = siticonePictureBox278.Location;
            rty.Name = "siticonePictureBox278";
            rty.Size = siticonePictureBox278.Size;
            rty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            rty.TabIndex = 0;
            rty.TabStop = false;




            SiticonePanel qwe = new SiticonePanel();
            qwe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(28)))), ((int)(((byte)(32)))));
            qwe.BorderRadius = 3;
            qwe.Controls.Add(wer);
            qwe.Controls.Add(wer1);
            qwe.Controls.Add(ert);
            qwe.Controls.Add(ert1);
            qwe.Controls.Add(ert2);
            qwe.Controls.Add(rty);
            qwe.Location = siticonePanel17.Location;
            qwe.Name = "siticonePanel17";
            qwe.Size = siticonePanel17.Size;
            qwe.TabIndex = 0;
            this.flowLayoutPanel11.Controls.Add(qwe);
        }

        private void Wer1_Click(object sender, EventArgs e)
        {
            SiticoneButton vg = (SiticoneButton)sender; ;
            SiticonePanel srt = (SiticonePanel)vg.Parent;
            foreach (Control item in srt.Controls)
            {
                if (item is System.Windows.Forms.Label)
                {

                    if (item.Text == "Bottle and Advantures")
                    {
                        Process.Start("C:\\ProgramData\\SEAzer\\BALNature\\Bottle\\Bottle.exe");
                    }
                    if (item.Text == "Good Worker Boid")
                    {
                        Process.Start("C:\\ProgramData\\SEAzer\\BALNature\\Isik\\isik.exe");
                    }







                }
            }
        }

        void panelaçıksaindirme()
        {
            flowLayoutPanel11.Controls.Clear();
            int mevcut = 0;
            if (Directory.Exists("C:\\ProgramData\\SEAzer\\BALNature\\Bottle"))
            {

                mevcut++;

                paneloyunekle("Bottle and Advantures", "29.2 MB", BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_18_saat_00_20_36, "Sürüm 14.1324     Konum: C:");



            }
            if (Directory.Exists("C:\\ProgramData\\SEAzer\\BALNature\\Isik"))
            {

                mevcut++;

                paneloyunekle("Good Worker Boid", "28.9 MB", BAL_Nature.Properties.Resources.y, "Sürüm 18.5324     Konum: C:");



            }
            else
            {

            }
            label361.Text = $"Son İndirilenler({mevcut.ToString()})";
            siticonePanel18.Visible = true;
        }
        int xxxc = 0;
        private void siticoneButton51_Click(object sender, EventArgs e)
        {
            indirilenlerdemi = 0;
            if (siticonePanel18.Visible == true)
            {
                if (xxxc == 0)
                {
                    label368.Visible = true;
                }
                else
                {
                    label368.Visible = false;
                }

                if (panel9.Visible == true)
                {
                    siticonePanel18.Visible = false;
                }
                else
                {
                    panelaçıksaindirme();
                    siticonePanel18.Visible = true;
                }
                siticonePanel18.Visible = false;
                flowLayoutPanel13.Visible = false; ;
                flowLayoutPanel14.Visible = false; ;
                siticonePanel18.Visible = false;
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;

                panel27.Visible = false;
                siticonePanel3.Visible = false;
                siticonePanel2.Visible = false;
                label80.Visible = false;
                label81.Visible = false;
                label79.Visible = false;
                label63.Visible = false;
                linkLabel16.Visible = false;
                linkLabel17.Visible = false;
                linkLabel18.Visible = false;
                linkLabel19.Visible = false;
                linkLabel20.Visible = false;
                siticonePictureBox27.Visible = false;
                siticonePictureBox28.Visible = false;
                siticonePictureBox29.Visible = false;
                siticonePictureBox30.Visible = false;
                siticonePictureBox31.Visible = false;
                siticoneGroupBox1.Visible = false;
                label64.Visible = false;
                label66.Visible = false;
                label67.Visible = false;
                label68.Visible = false;
                label69.Visible = false;
                label70.Visible = false;
                label71.Visible = false;
                label72.Visible = false;
                label73.Visible = false;
                label74.Visible = false;
                label75.Visible = false;
                siticonePictureBox25.Visible = false;
                linkLabel14.Visible = false;
                linkLabel15.Visible = false;
                label47.Visible = true;
                label48.Visible = true;
                label49.Visible = true;
                siticonePictureBox22.Visible = true;
                siticonePictureBox23.Visible = true;
                siticonePictureBox24.Visible = true;
                label50.Visible = false;
                label51.Visible = false;
                label52.Visible = false;
                label53.Visible = false;
                label54.Visible = false;
                label55.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = false;
                pictureBox14.Visible = false;
                pictureBox15.Visible = false;
                pictureBox16.Visible = false;
                pictureBox17.Visible = false;
                label57.Visible = false;
                label58.Visible = false;
                label59.Visible = false;
                label60.Visible = false;
                label61.Visible = false;
                label62.Visible = false;
                label56.Visible = false;

                siticoneButton56.Visible = false;
                siticoneButton57.Visible = false;
                siticoneButton58.Visible = false;
                siticoneButton59.Visible = false;
                siticoneButton60.Visible = false;
                siticoneTabControl1.Visible = false;


                label16.Visible = false;
                panel31.Visible = true;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;

                if (bildirimmenüsüaçıkmı == true)
                {
                    panel6.Visible = false;
                    bildirimmenüsüaçıkmı = false;
                }
                if (Hesapaçıkmı == true)
                {
                    timer1.Interval = 1;
                    timer1.Start();
                    siticoneImageButton1.Enabled = false;
                    siticoneButton43.Visible = false;
                    siticoneButton44.Visible = false;




                    siticoneButton48.Visible = false;
                    siticoneButton49.Visible = false;
                    siticoneButton50.Visible = false;
                }

                siticoneButton53.FillColor = Color.FromArgb(56, 60, 64);
                siticoneButton51.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton54.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton54.Image = BAL_Nature.Properties.Resources.download_for_offline_FILL0_wght400_GRAD0_opsz48;
                siticoneButton55.FillColor = Color.FromArgb(22, 26, 31); siticonePanel3.Visible = false;

            }
            else
            {
                panelaçıksaindirme();
                siticonePanel18.Visible = true;
                siticoneButton53.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton51.FillColor = Color.FromArgb(56, 60, 64);
                siticoneButton54.Image = BAL_Nature.Properties.Resources.download_for_offline_FILL0_wght400_GRAD0_opsz48;
                siticoneButton54.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton55.FillColor = Color.FromArgb(22, 26, 31);
            }

            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;
                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }


        }

        private void siticoneButton52_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            bildirimmenüsüaçıkmı = false;
            siticoneButton112.Visible = false; siticoneButton117.Visible = false;
            siticoneButton117.Visible = false;
            panel27.Visible = false;
            siticonePanel3.Visible = false;
            siticonePanel2.Visible = false;
            panel11.Visible = true;
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;

            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;
            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            siticoneTabControl1.Visible = false;


            label16.Visible = false;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;

            panel31.Visible = false;
            label7.Visible = false;

            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }

            siticoneButton53.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton51.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton54.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton54.Image = BAL_Nature.Properties.Resources.download_for_offline_FILL0_wght400_GRAD0_opsz48;
            siticoneButton55.FillColor = Color.FromArgb(22, 26, 31); siticonePanel3.Visible = false;
        }

        private void siticoneButton53_Click(object sender, EventArgs e)
        {
            indirilenlerdemi = 0;
            flowLayoutPanel13.Visible = false; ;
            flowLayoutPanel14.Visible = false; ;
            siticonePanel18.Visible = false;
            panel6.Visible = false;
            bildirimmenüsüaçıkmı = false;

            panel27.Visible = false;
            siticonePanel3.Visible = false;
            siticonePanel2.Visible = false;
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;

            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;
            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            siticoneTabControl1.Visible = false;


            label16.Visible = false;
            panel31.Visible = true;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;

            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }

            siticoneButton53.FillColor = Color.FromArgb(56, 60, 64);
            siticoneButton51.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton54.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton54.Image = BAL_Nature.Properties.Resources.download_for_offline_FILL0_wght400_GRAD0_opsz48;
            siticoneButton55.FillColor = Color.FromArgb(22, 26, 31); siticonePanel3.Visible = false;
        }
        public static Bitmap GenerateProfilePhoto(string name, int width, int height)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name must be non-empty");
            }

            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width and height must be greater than 0");
            }

            using (var bitmap = new Bitmap(width, height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.Clear(Color.White);

                    using (var path = new GraphicsPath())
                    {
                        path.AddEllipse(0, 0, width, height);
                        graphics.SetClip(path);
                    }

                    using (var brush = new SolidBrush(GetRandomColor()))
                    {
                        graphics.FillRectangle(brush, 0, 0, width, height);
                    }

                    using (var font = new Font("Arial", width / 2, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        var size = graphics.MeasureString(name.ToUpper(), font);
                        graphics.DrawString(name.ToUpper(), font, Brushes.White,
                            new PointF((width - size.Width) / 2, (height - size.Height) / 2));
                    }
                }

                return new Bitmap(bitmap);
            }
        }

        private static Color GetRandomColor()
        {
            var random = new Random();
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private void webControl1_DoubleClick(object sender, EventArgs e)
        {
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
                siticoneButton55.FillColor = Color.FromArgb(22, 26, 31);

            }
        }


        void flw13eelemanyaz(Bitmap image13, string ad)
        {
            SiticonePictureBox zxc = new SiticonePictureBox();
            zxc.BorderRadius = 21;
            zxc.Image = image13;
            zxc.ImageRotate = 0F;
            zxc.Location = siticonePictureBox279.Location;
            zxc.Name = ad;
            zxc.Size = siticonePictureBox279.Size;

            zxc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            zxc.TabIndex = 0;
            zxc.TabStop = false;
            zxc.Click += Zxc_Click;
            flowLayoutPanel13.Controls.Add(zxc);
        }
        int indirilenlerdemi = 0;
        private void Zxc_Click(object sender, EventArgs e)
        {
            SiticonePictureBox ghj = (SiticonePictureBox)sender;
            indirilenlerdemi = 1;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            flowLayoutPanel13.Visible = false;
            flowLayoutPanel14.Visible = false;

            if (ghj.Name == "Bottle")
            {
                panel27_Göster("Bottle and Adventures", "2023 SEAZER BalNature Çekirdek Ekip™  tarafından oluşturulan bu oyun bir geri dönüşüm malzemesinin maceralarını içerir.", BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_12_saat_15_32_14, BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_12_saat_15_32_21, BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_12_saat_15_32_25, BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_12_saat_15_32_30, "Bal Nature LLC.", "Bal Nature LLC.", "28.2", new DateTime(2023, 12, 19), "Platform", "Windows XP®+", "İntel Pentinum C1100", "512 MB", "MX 350 / Readon HD 3452", "x86 / x64", "Windows 10/11", "Ryzen 7 7100x/İntel i9 12400h", "8 GB", "RTX 4090 Tİ /Readon RX 5040", "x64", "www", "Bottle", 1);
            }
            if (ghj.Name == "isik")
            {
                panel27_Göster("Good Worker Boid", "2023 SEAZER BalNature Çekirdek Ekip™  tarafından oluşturulan bu oyun bir doğa sever canlının dört bir tarafa dağılmış geri dönüşüm malzemelerini aramasını anlatmaktadır.", BAL_Nature.Properties.Resources.IMG_20230322_WA0004, BAL_Nature.Properties.Resources.
                    IMG_20230322_WA0007, BAL_Nature.Properties.Resources.IMG_20230322_WA0008, BAL_Nature.Properties.Resources.IMG_20230322_WA0009, "Bal Nature LLC.", "Bal Nature LLC.", "28.2", new DateTime(2023, 12, 19), "Platform", "Windows XP®+", "İntel Pentinum C1100", "512 MB", "MX 350 / Readon HD 3452", "x86 / x64", "Windows 10/11", "Ryzen 7 7100x/İntel i9 12400h", "8 GB", "RTX 4090 Tİ /Readon RX 5040", "x64", "www", "isik", 1);
            }
        }

        private void siticoneButton54_Click(object sender, EventArgs e)
        {
            indirilenlerdemi = 0;
            flowLayoutPanel13.Controls.Clear();
            if (Directory.Exists("C:\\ProgramData\\SEAzer\\BALNature\\Bottle"))
            {

                // 
                // siticonePictureBox279
                // 
                flw13eelemanyaz(BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_18_saat_00_20_36, "Bottle");
                label16.Visible = false;
            }
            if (Directory.Exists("C:\\ProgramData\\SEAzer\\BALNature\\Isik"))
            {

                // 
                // siticonePictureBox279
                // 
                flw13eelemanyaz(BAL_Nature.Properties.Resources.y, "isik");
                label16.Visible = false;
            }
            else
            {
                label16.Visible = true;
            }
            flowLayoutPanel13.Visible = true;
            flowLayoutPanel14.Visible = true;
            siticonePanel18.Visible = false;
            panel6.Visible = false;
            bildirimmenüsüaçıkmı = false;
            siticoneButton112.Visible = false; siticoneButton117.Visible = false;
            panel27.Visible = false;
            siticonePanel3.Visible = false;
            siticonePanel2.Visible = false;
            panel11.Visible = false;
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;

            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;
            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            siticoneTabControl1.Visible = false;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;

            panel31.Visible = false;





            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            siticoneButton54.Image = BAL_Nature.Properties.Resources.download_for_offline_FILL1_wght400_GRAD0_opsz48;

            siticoneButton53.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton51.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton55.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton54.FillColor = Color.FromArgb(56, 60, 64);
        }

        private void siticoneButton55_Click(object sender, EventArgs e)
        {
            indirilenlerdemi = 0;
            flowLayoutPanel13.Visible = false; ;
            flowLayoutPanel14.Visible = false; ;
            siticonePanel18.Visible = false;
            panel6.Visible = false;
            bildirimmenüsüaçıkmı = false;
            siticoneButton112.Visible = false; siticoneButton117.Visible = false;
            panel27.Visible = false;
            panel11.Visible = false;
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;

            siticoneButton56.Visible = false;
            siticoneButton57.Visible = false;
            siticoneButton58.Visible = false;
            siticoneButton59.Visible = false;
            siticoneButton60.Visible = false;
            siticoneTabControl1.Visible = true;
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
            siticoneTabControl1.Visible = true;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;

            panel31.Visible = false;



            label16.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;

            siticoneButton54.Image = BAL_Nature.Properties.Resources.download_for_offline_FILL0_wght400_GRAD0_opsz48;

            siticoneButton53.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton51.FillColor = Color.FromArgb(22, 26, 31);
            siticoneButton55.FillColor = Color.FromArgb(56, 60, 64);
            siticoneButton54.FillColor = Color.FromArgb(22, 26, 31);
        }

        private void siticoneProgressBar1_MouseEnter(object sender, EventArgs e)
        {
            siticoneProgressBar1.FillColor = Color.DarkGray;
        }

        private void siticoneProgressBar1_MouseLeave(object sender, EventArgs e)
        {
            if (tıklı != 1)
            {
                siticoneProgressBar1.FillColor = Color.Gray;
            }

        }

        private void siticoneProgressBar2_MouseEnter(object sender, EventArgs e)
        {

            siticoneProgressBar2.FillColor = Color.DarkGray;
        }

        private void siticoneProgressBar2_MouseLeave(object sender, EventArgs e)
        {
            if (tıklı != 2)
            {
                siticoneProgressBar2.FillColor = Color.Gray;
            }
        }

        private void siticoneProgressBar3_MouseEnter(object sender, EventArgs e)
        {
            siticoneProgressBar3.FillColor = Color.DarkGray;
        }

        private void siticoneProgressBar3_MouseLeave(object sender, EventArgs e)
        {
            if (tıklı != 3)
            {
                siticoneProgressBar3.FillColor = Color.Gray;
            }
        }

        private void siticoneProgressBar4_MouseEnter(object sender, EventArgs e)
        {
            siticoneProgressBar4.FillColor = Color.DarkGray;
        }

        private void siticoneProgressBar4_MouseLeave(object sender, EventArgs e)
        {
            if (tıklı != 4)
            {
                siticoneProgressBar4.FillColor = Color.Gray;
            }
        }

        private void siticoneProgressBar5_MouseEnter(object sender, EventArgs e)
        {
            siticoneProgressBar5.FillColor = Color.DarkGray;
        }

        private void siticoneProgressBar5_MouseLeave(object sender, EventArgs e)
        {
            if (tıklı != 5)
            {
                siticoneProgressBar5.FillColor = Color.Gray;
            }
        }

        private void siticoneProgressBar6_MouseEnter(object sender, EventArgs e)
        {
            siticoneProgressBar6.FillColor = Color.DarkGray;
        }

        private void siticoneProgressBar6_MouseLeave(object sender, EventArgs e)
        {
            if (tıklı != 6)
            {
                siticoneProgressBar6.FillColor = Color.Gray;
            }
        }
        int tıklı = 0;
        private void siticoneProgressBar1_Click(object sender, EventArgs e)
        {
            siticonePictureBox4.Image = BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_15_saat_00_25_34;
            tıklı = 1;
            siticoneProgressBar1.Value = 0;
            siticoneProgressBar2.Value = 0;
            siticoneProgressBar3.Value = 0;
            siticoneProgressBar4.Value = 0;
            siticoneProgressBar5.Value = 0;
            siticoneProgressBar6.Value = 0;
            timer2.Start();
            siticoneProgressBar1.FillColor = Color.DarkGray;
            siticoneProgressBar2.FillColor = Color.Gray;
            siticoneProgressBar3.FillColor = Color.Gray;
            siticoneProgressBar4.FillColor = Color.Gray;
            siticoneProgressBar5.FillColor = Color.Gray;
            siticoneProgressBar6.FillColor = Color.Gray;
            siticoneButton112.Visible = true; siticoneButton117.Visible = false;

        }

        private void siticoneProgressBar2_Click(object sender, EventArgs e)
        {
            siticonePictureBox4.Image = BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_20_saat_19_33_17;
            tıklı = 2;
            siticoneProgressBar1.Value = 0;
            siticoneProgressBar2.Value = 0;
            siticoneProgressBar3.Value = 0;
            siticoneProgressBar4.Value = 0;
            siticoneProgressBar5.Value = 0;
            siticoneProgressBar6.Value = 0;
            siticoneProgressBar2.FillColor = Color.DarkGray;
            siticoneProgressBar1.FillColor = Color.Gray;
            siticoneProgressBar3.FillColor = Color.Gray;
            siticoneProgressBar4.FillColor = Color.Gray;
            siticoneProgressBar5.FillColor = Color.Gray;
            siticoneProgressBar6.FillColor = Color.Gray;
            siticoneButton112.Visible = false; siticoneButton117.Visible = true;

        }

        private void siticoneProgressBar3_Click(object sender, EventArgs e)
        {
            siticonePictureBox4.Image = BAL_Nature.Properties.Resources.a07df83365da6ca90f635c0ba20bb6f8f3e958af;
            tıklı = 3;
            siticoneProgressBar1.Value = 0;
            siticoneProgressBar2.Value = 0;
            siticoneProgressBar3.Value = 0;
            siticoneProgressBar4.Value = 0;
            siticoneProgressBar5.Value = 0;
            siticoneProgressBar6.Value = 0;
            siticoneProgressBar3.FillColor = Color.DarkGray;
            siticoneProgressBar2.FillColor = Color.Gray;
            siticoneProgressBar1.FillColor = Color.Gray;
            siticoneProgressBar4.FillColor = Color.Gray;
            siticoneProgressBar5.FillColor = Color.Gray;
            siticoneProgressBar6.FillColor = Color.Gray; siticoneButton112.Visible = false; siticoneButton117.Visible = false;
        }

        private void siticoneProgressBar4_Click(object sender, EventArgs e)
        {
            siticonePictureBox4.Image = BAL_Nature.Properties.Resources.capsule_616x353;
            tıklı = 4;
            siticoneProgressBar1.Value = 0;
            siticoneProgressBar2.Value = 0;
            siticoneProgressBar3.Value = 0;
            siticoneProgressBar4.Value = 0;
            siticoneProgressBar5.Value = 0;
            siticoneProgressBar6.Value = 0;
            siticoneProgressBar4.FillColor = Color.DarkGray;
            siticoneProgressBar2.FillColor = Color.Gray;
            siticoneProgressBar3.FillColor = Color.Gray;
            siticoneProgressBar1.FillColor = Color.Gray;
            siticoneProgressBar5.FillColor = Color.Gray;
            siticoneProgressBar6.FillColor = Color.Gray; siticoneButton112.Visible = false; siticoneButton117.Visible = false;
        }

        private void siticoneProgressBar5_Click(object sender, EventArgs e)
        {
            tıklı = 5;
            siticonePictureBox4.Image = BAL_Nature.Properties.Resources.GroundedC;
            siticoneProgressBar2.Value = 0;
            siticoneProgressBar3.Value = 0;
            siticoneProgressBar4.Value = 0;
            siticoneProgressBar5.Value = 0;
            siticoneProgressBar6.Value = 0;
            siticoneProgressBar5.FillColor = Color.DarkGray;
            siticoneProgressBar2.FillColor = Color.Gray;
            siticoneProgressBar3.FillColor = Color.Gray;
            siticoneProgressBar4.FillColor = Color.Gray;
            siticoneProgressBar1.FillColor = Color.Gray;
            siticoneProgressBar6.FillColor = Color.Gray; siticoneButton112.Visible = false; siticoneButton117.Visible = false;
        }

        private void siticoneProgressBar6_Click(object sender, EventArgs e)
        {
            tıklı = 6;
            siticonePictureBox4.Image = BAL_Nature.Properties.Resources.Gormiti__1_;
            siticoneProgressBar1.Value = 0;
            siticoneProgressBar2.Value = 0;
            siticoneProgressBar3.Value = 0;
            siticoneProgressBar4.Value = 0;
            siticoneProgressBar5.Value = 0;
            siticoneProgressBar6.Value = 0;
            siticoneProgressBar6.FillColor = Color.DarkGray;
            siticoneProgressBar2.FillColor = Color.Gray;
            siticoneProgressBar3.FillColor = Color.Gray;
            siticoneProgressBar4.FillColor = Color.Gray;
            siticoneProgressBar5.FillColor = Color.Gray;
            siticoneProgressBar1.FillColor = Color.Gray; siticoneButton112.Visible = false; siticoneButton117.Visible = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (tıklı == 1)
            {
                if (siticoneProgressBar1.Value == 100)
                {
                    siticoneButton112.Visible = false; siticoneButton117.Visible = true;
                    siticonePictureBox4.Image = BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_20_saat_19_33_17;
                    siticoneProgressBar2.FillColor = Color.DarkGray;
                    siticoneProgressBar1.FillColor = Color.Gray;
                    siticoneProgressBar3.FillColor = Color.Gray;
                    siticoneProgressBar4.FillColor = Color.Gray;
                    siticoneProgressBar5.FillColor = Color.Gray;
                    siticoneProgressBar6.FillColor = Color.Gray;
                    tıklı = 2;
                    siticoneProgressBar1.Value = 0;
                }
                else
                {
                    siticoneProgressBar1.Value += 1;
                }

            }
            if (tıklı == 2)
            {
                if (siticoneProgressBar2.Value == 100)
                {
                    siticonePictureBox4.Image = BAL_Nature.Properties.Resources.a07df83365da6ca90f635c0ba20bb6f8f3e958af;



                    siticoneProgressBar3.FillColor = Color.DarkGray;
                    siticoneProgressBar1.FillColor = Color.Gray;
                    siticoneProgressBar2.FillColor = Color.Gray;
                    siticoneProgressBar4.FillColor = Color.Gray;
                    siticoneProgressBar5.FillColor = Color.Gray;
                    siticoneProgressBar6.FillColor = Color.Gray;
                    tıklı = 3; siticoneButton112.Visible = false; siticoneButton117.Visible = false;
                    siticoneProgressBar2.Value = 0;
                }
                else
                {
                    siticoneProgressBar2.Value += 1;
                }

            }
            if (tıklı == 3)
            {
                if (siticoneProgressBar3.Value == 100)
                {
                    siticonePictureBox4.Image = BAL_Nature.Properties.Resources.capsule_616x353;
                    siticoneProgressBar4.FillColor = Color.DarkGray;
                    siticoneProgressBar2.FillColor = Color.Gray;
                    siticoneProgressBar1.FillColor = Color.Gray;
                    siticoneProgressBar3.FillColor = Color.Gray;
                    siticoneProgressBar5.FillColor = Color.Gray;
                    siticoneProgressBar6.FillColor = Color.Gray;
                    tıklı = 4; siticoneButton112.Visible = false; siticoneButton117.Visible = false;
                    siticoneProgressBar3.Value = 0;
                }
                else
                {
                    siticoneProgressBar3.Value += 1;
                }

            }
            if (tıklı == 4)
            {
                if (siticoneProgressBar4.Value == 100)
                {
                    siticonePictureBox4.Image = BAL_Nature.Properties.Resources.GroundedC;
                    siticoneProgressBar5.FillColor = Color.DarkGray;
                    siticoneProgressBar2.FillColor = Color.Gray;
                    siticoneProgressBar3.FillColor = Color.Gray;
                    siticoneProgressBar1.FillColor = Color.Gray;
                    siticoneProgressBar4.FillColor = Color.Gray;
                    siticoneProgressBar6.FillColor = Color.Gray;
                    tıklı = 5; siticoneButton112.Visible = false; siticoneButton117.Visible = false;
                    siticoneProgressBar4.Value = 0;
                }
                else
                {
                    siticoneProgressBar4.Value += 1;
                }

            }
            if (tıklı == 5)
            {
                if (siticoneProgressBar5.Value == 100)
                {
                    siticonePictureBox4.Image = BAL_Nature.Properties.Resources.Gormiti__1_;
                    siticoneProgressBar6.FillColor = Color.DarkGray;
                    siticoneProgressBar2.FillColor = Color.Gray;
                    siticoneProgressBar3.FillColor = Color.Gray;
                    siticoneProgressBar4.FillColor = Color.Gray;
                    siticoneProgressBar1.FillColor = Color.Gray;
                    siticoneProgressBar5.FillColor = Color.Gray;
                    tıklı = 6; siticoneButton112.Visible = false; siticoneButton117.Visible = false;
                    siticoneProgressBar5.Value = 0;
                }
                else
                {
                    siticoneProgressBar5.Value += 1;
                }

            }
            if (tıklı == 6)
            {
                if (siticoneProgressBar6.Value == 100)
                {
                    siticonePictureBox4.Image = BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_15_saat_00_25_34;
                    siticoneProgressBar6.FillColor = Color.DarkGray;
                    siticoneProgressBar2.FillColor = Color.Gray;
                    siticoneProgressBar3.FillColor = Color.Gray;
                    siticoneProgressBar4.FillColor = Color.Gray;
                    siticoneProgressBar5.FillColor = Color.Gray;
                    siticoneProgressBar1.FillColor = Color.Gray;
                    tıklı = 1;
                    siticoneProgressBar6.Value = 0;
                    siticoneButton112.Visible = true; siticoneButton117.Visible = false;
                }
                else
                {
                    siticoneProgressBar6.Value += 1;
                }

            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            label10.ForeColor = Color.White;
            label11.ForeColor = Color.Gray;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            label10.ForeColor = Color.Gray;
            label11.ForeColor = Color.White;
        }



        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void siticonePictureBox8_MouseEnter(object sender, EventArgs e)
        {

        }

        private void label20_MouseEnter(object sender, EventArgs e)
        {
            label20.ForeColor = Color.Green;
            label20.Text = "FOR Future";
        }

        private void label20_MouseLeave(object sender, EventArgs e)
        {
            label20.ForeColor = Color.White;
            label20.Text = "BAL Nature";
        }

        private void siticonePictureBox9_Click(object sender, EventArgs e)
        {
            Process.Start("https://bursaanadolulisesi.meb.k12.tr/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://bursaanadolulisesi.meb.k12.tr/");
        }

        private void label17_Click(object sender, EventArgs e)
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
        int sayı2 = 0;
        bool indirilenuygulamalaraçıkmj = false;
        private void timer3_Tick(object sender, EventArgs e)
        {
            double y = this.Width / (19 / 5);
            double yyy = y / 34;
            int yy = Convert.ToInt32(yyy);
            siticoneButton51.Enabled = false;
            if (indirilenuygulamalaraçıkmj == false)
            {
                if (sayı2 == 34)

                {
                    siticoneButton51.Enabled = true;
                    indirilenuygulamalaraçıkmj = true;
                    timer3.Stop();
                }
                else
                {
                    siticonePanel18.Left += yy;
                    sayı2 += 1;


                }
            }

            if (indirilenuygulamalaraçıkmj == true)
            {


                if (sayı2 == 0)
                {
                    timer3.Stop();
                    siticoneButton51.Enabled = true;
                    indirilenuygulamalaraçıkmj = false;

                }
                else
                {
                    siticonePanel18.Left -= yy;
                    sayı2 -= 1;

                }
            }


        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton28_Click(object sender, EventArgs e)
        {
            Form2 qq = new Form2();
            qq.ShowDialog();
        }

        private void siticoneButton22_Click(object sender, EventArgs e)
        {

        }
        int sayı3 = 0;
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (sayı3 == 85)
            {
                timer4.Stop();
                siticoneProgressIndicator1.Visible = false;

                siticoneProgressIndicator1.Stop();

            }
            else
            {
                sayı3 += 1;

            }
        }
        #endregion
        #region hakkında kısmı
        private void siticoneButton56_Click(object sender, EventArgs e)
        {
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            siticonePictureBox22.Visible = true;
            siticonePictureBox23.Visible = true;
            siticonePictureBox24.Visible = true;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            label56.Visible = false;
        }

        private void siticoneButton57_Click(object sender, EventArgs e)
        {
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label56.Visible = true;
            label57.Visible = true;
            label58.Visible = true;
            label59.Visible = true;
            label60.Visible = true;
            label61.Visible = true;
            label62.Visible = true;
            pictureBox12.Visible = true;
            pictureBox13.Visible = true;
            pictureBox14.Visible = true;
            pictureBox15.Visible = true;
            pictureBox16.Visible = true;
            pictureBox17.Visible = true;
            label50.Visible = true;
            label51.Visible = true;
            label52.Visible = true;
            label53.Visible = true;
            label54.Visible = true;
            label55.Visible = true;

            label47.Visible = false;
            label48.Visible = false;
            label49.Visible = false;
            siticonePictureBox22.Visible = false;
            siticonePictureBox23.Visible = false;
            siticonePictureBox24.Visible = false;
        }

        private void siticonePictureBox23_Click(object sender, EventArgs e)
        {
            Process.Start("https://erasmus-plus.ec.europa.eu/");
        }

        private void siticonePictureBox22_Click(object sender, EventArgs e)
        {
            Process.Start("https://balnatureerasmus.wixsite.com/balnature");
        }

        private void label49_Click(object sender, EventArgs e)
        {
            Process.Start("https://balnatureerasmus.wixsite.com/balnature");
        }

        private void siticonePictureBox24_Click(object sender, EventArgs e)
        {
            Process.Start("https://bursaanadolulisesi.meb.k12.tr/");
        }

        private void siticoneButton58_Click(object sender, EventArgs e)
        {
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = true;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
            label64.Visible = true;
            label66.Visible = true;
            label67.Visible = true;
            label68.Visible = true;
            label69.Visible = true;
            label70.Visible = true;
            label71.Visible = true;
            label72.Visible = true;
            label73.Visible = true;
            label74.Visible = true;
            label75.Visible = true;
            siticonePictureBox25.Visible = true;
            linkLabel14.Visible = true;
            label56.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;

            label47.Visible = false;
            label48.Visible = false;
            label49.Visible = false;
            siticonePictureBox22.Visible = false;
            siticonePictureBox23.Visible = false;
            siticonePictureBox24.Visible = false;
            linkLabel14.Visible = true;
            linkLabel15.Visible = true;

        }





        private void siticoneButton61_Click(object sender, EventArgs e)
        {
            siticoneTextBox2.Text = "";
            siticoneTextBox3.Text = "";
            checkBox1.Checked = false;
        }

        private void siticoneButton59_Click(object sender, EventArgs e)
        {
            label80.Visible = false;
            label81.Visible = false;
            label79.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            label56.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;

            label47.Visible = false;
            label48.Visible = false;
            label49.Visible = false;
            siticonePictureBox22.Visible = false;
            siticonePictureBox23.Visible = false;
            siticonePictureBox24.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label63.Visible = true;
            linkLabel16.Visible = true;
            linkLabel17.Visible = true;
            linkLabel18.Visible = true;
            linkLabel19.Visible = true;
            linkLabel20.Visible = true;
            siticonePictureBox27.Visible = true;
            siticonePictureBox28.Visible = true;
            siticonePictureBox29.Visible = true;
            siticonePictureBox30.Visible = true;
            siticonePictureBox31.Visible = true;
            siticoneGroupBox1.Visible = true;

        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://balnatureerasmus.wixsite.com/balnature");
        }

        private void siticoneToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneToggleSwitch3.Checked == true)
            {
                siticoneToggleSwitch3.Checked = false;
                MessageBox.Show("Uygulamanın kararsız bir sürümünü kullanıyorsunuz bu ayarı açmak performansta düşmeye sebep olabilir", "Bal Nature Error Services");
            }
        }

        private void siticoneCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void siticonePanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton37_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(siticoneTextBox4.Text))
            {
                label117.Visible = true;
                siticoneTextBox4.BorderColor = Color.Red;
                if (String.IsNullOrEmpty(siticoneTextBox5.Text))
                {
                    label118.Visible = true;
                    siticoneTextBox5.BorderColor = Color.Red;
                }

            }
            else if (String.IsNullOrEmpty(siticoneTextBox5.Text))
            {
                label118.Visible = true;
                siticoneTextBox5.BorderColor = Color.Red;
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "profilproc"; //Stored Procedure' ümüzün ismi
                cmd.Parameters.Add("EPosta", SqlDbType.NVarChar, 50).Value = EPosta; //Stored procedure deki parametrelere
                cmd.Parameters.Add("Ad", SqlDbType.NVarChar, 50).Value = siticoneTextBox4.Text; // textboxlardan değerleri
                cmd.Parameters.Add("Soyad", SqlDbType.NVarChar, 50).Value = siticoneTextBox5.Text; //alıyoruz.
                cmd.Parameters.Add("Açıklama", SqlDbType.NVarChar, 50).Value = siticoneTextBox6.Text;
                int a = siticoneDateTimePicker1.Value.Day;
                string aa = Convert.ToString(a);
                int a2 = siticoneDateTimePicker1.Value.Year;
                string aa2 = Convert.ToString(a2);
                int a1 = siticoneDateTimePicker1.Value.Month;
                string aa1 = "";
                if (a1 == 1)
                {
                    aa1 = "Ocak";
                }
                if (a1 == 2)
                {
                    aa1 = "Şubat";
                }
                if (a1 == 3)
                {
                    aa1 = "Mart";
                }
                if (a1 == 4)
                {
                    aa1 = "Nisan";

                }
                if (a1 == 5)
                {
                    aa1 = "Mayıs";
                }
                if (a1 == 6)
                {
                    aa1 = "Haziran";

                }
                if (a1 == 7)
                {
                    aa1 = "Temmuz";
                }
                if (a1 == 8)
                {
                    aa1 = "Ağustos";
                }
                if (a1 == 9)
                {
                    aa1 = "Eylül";
                }
                if (a1 == 10)
                {
                    aa1 = "Ekim";
                }
                if (a1 == 11)
                {
                    aa1 = "Kasım";
                }
                if (a1 == 12)
                {
                    aa1 = "aralık";
                }
                int b;
                int b1;
                if (siticoneToggleSwitch1.Checked == true)
                {
                    b = 1;
                }
                else
                {
                    b = 0;
                }
                if (siticoneToggleSwitch2.Checked == true)
                {
                    b1 = 1;
                }
                else
                {
                    b1 = 0;
                }
                cmd.Parameters.Add("Doğumgünü", SqlDbType.NVarChar, 50).Value = aa; // textboxlardan değerleri
                cmd.Parameters.Add("Doğumayı", SqlDbType.NVarChar, 50).Value = aa1; //alıyoruz.
                cmd.Parameters.Add("doğumyılı", SqlDbType.NVarChar, 50).Value = aa2; //Stored procedure deki parametrelere
                cmd.Parameters.Add("benihatırla", SqlDbType.Int).Value = b; // textboxlardan değerleri
                cmd.Parameters.Add("uygulamverilerimisaklasın", SqlDbType.Int).Value = b1; //alıyoruz.
                MessageBox.Show("Verileriniz başarılı bir şekilde kaydeildi", "BALNature Save Service");
                cmd.ExecuteNonQuery();
                con.Close();
                KayıtEkleDatabase(EPosta, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");

            }
        }
        static public string AddProductCategory2(string newName, string connString)
        {
            string newProdID = "";
            string sql =
                "select dbo.function555(@eposta)";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {
                    conn.Open();
                    newProdID = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return (string)newProdID;
        }
        private void siticoneButton41_Click(object sender, EventArgs e)
        {
            label119.Visible = false;
            label120.Visible = false;
            label121.Visible = false;
            siticoneTextBox8.BorderColor = Color.Black;
            siticoneTextBox9.BorderColor = Color.Black;
            siticoneTextBox10.BorderColor = Color.Black;
            if (String.IsNullOrEmpty(siticoneTextBox8.Text))
            {
                label119.Text = "Bu alanın doldurulması zorunludur!";
                label119.Visible = true;
                siticoneTextBox8.BorderColor = Color.Red;
                if (String.IsNullOrEmpty(siticoneTextBox9.Text))
                {
                    label120.Visible = true;
                    siticoneTextBox9.BorderColor = Color.Red;
                    if (String.IsNullOrEmpty(siticoneTextBox10.Text))
                    {
                        label121.Text = "Bu alanın doldurulması zorunludur!";
                        label121.Visible = true;
                        siticoneTextBox10.BorderColor = Color.Red;
                    }
                    else
                    {
                        label121.Text = "Bu alanın doldurulması zorunludur!";
                        label121.Visible = false;
                        siticoneTextBox10.BorderColor = Color.Black;
                    }
                }
                else
                {
                    label120.Visible = false;
                    siticoneTextBox9.BorderColor = Color.Black;
                }

            }
            else if (String.IsNullOrEmpty(siticoneTextBox9.Text))
            {
                label120.Visible = true;
                siticoneTextBox9.BorderColor = Color.Red;
                if (String.IsNullOrEmpty(siticoneTextBox10.Text))
                {
                    label121.Text = "Bu alanın doldurulması zorunludur!";
                    label121.Visible = true;
                    siticoneTextBox10.BorderColor = Color.Red;
                }
                else
                {
                    label121.Visible = false;

                    siticoneTextBox10.BorderColor = Color.Black;
                }
            }
            else if (String.IsNullOrEmpty(siticoneTextBox10.Text))
            {
                label121.Visible = true;
                siticoneTextBox10.BorderColor = Color.Red;
            }
            else
            {
                if (AddProductCategory2(EPosta, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;") == siticoneTextBox8.Text)
                {
                    if (siticoneTextBox9.Text == siticoneTextBox10.Text)
                    {
                        if (siticoneTextBox8.Text.Length >= 8)
                        {

                            MessageBox.Show("Şifreniz Başarıyla değiştirildi.", "BalNature Password services");
                            SqlConnection con = new SqlConnection("Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
                            SqlCommand cmd = new SqlCommand();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "hesapproc2"; //Stored Procedure' ümüzün ismi
                            cmd.Parameters.Add("EPosta", SqlDbType.NVarChar, 50).Value = EPosta; //Stored procedure deki parametrelere
                            cmd.Parameters.Add("yenişifre", SqlDbType.NVarChar, 50).Value = siticoneTextBox10.Text;
                            cmd.ExecuteNonQuery();
                            con.Close();

                            KayıtEkleDatabase(EPosta, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
                            siticoneTextBox8.Text = "";
                            siticoneTextBox9.Text = "";
                            siticoneTextBox10.Text = "";
                        }
                        else
                        {
                            label121.Visible = true;
                            label121.Text = "Şifrelenizin uzunluğu 8'den uzun olmalıdır!";
                            siticoneTextBox9.BorderColor = Color.Red;
                            siticoneTextBox10.BorderColor = Color.Red;
                        }
                    }
                    else
                    {
                        label121.Visible = true;
                        label121.Text = "Şifreler eşleşmiyor!";

                        siticoneTextBox10.BorderColor = Color.Red;
                    }
                }
                else
                {
                    label120.Visible = false;
                    label121.Visible = false;
                    label119.Text = "Girdiğiniz şifre yanlış !";
                    label119.Visible = true;
                    siticoneTextBox8.BorderColor = Color.Red;
                }
            }



        }

        private void siticoneButton40_Click(object sender, EventArgs e)
        {
            label122.Hide();
            if (siticoneTextBox16.Text == "" || siticoneTextBox16.Text.StartsWith(@"http://") || siticoneTextBox16.Text.StartsWith(@"https://") || siticoneTextBox16.Text.StartsWith("www"))
            {
                string a = "";
                string a1 = "";
                string a2 = "";
                string a3 = "";
                string a4 = "";
                if (siticoneTextBox16.Text == "")
                {
                    a = "Belirtilmemiş";
                }
                else
                {
                    a = siticoneTextBox16.Text;
                }
                if (siticoneTextBox11.Text == "")
                {
                    a1 = "Belirtilmemiş";
                }
                else
                {
                    a1 = siticoneTextBox11.Text;
                }
                if (siticoneTextBox12.Text == "")
                {
                    a2 = "Belirtilmemiş";
                }
                else
                {
                    a2 = siticoneTextBox12.Text;
                }
                if (siticoneTextBox13.Text == "")
                {
                    a3 = "Belirtilmemiş";
                }
                else
                {
                    a3 = siticoneTextBox13.Text;
                }
                if (siticoneTextBox14.Text == "")
                {
                    a4 = "Belirtilmemiş";
                }
                else
                {
                    a4 = siticoneTextBox14.Text;
                }
                MessageBox.Show("Verilerini kaydedildi", "BalNature Database services");
                SqlConnection con = new SqlConnection("Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sosyalproc2"; //Stored Procedure' ümüzün ismi
                cmd.Parameters.Add("EPosta", SqlDbType.NVarChar, 50).Value = EPosta; //Stored procedure deki parametrelere
                cmd.Parameters.Add("web", SqlDbType.NVarChar, 50).Value = a;
                cmd.Parameters.Add("twitter", SqlDbType.NVarChar, 50).Value = a1;//Stored procedure deki parametrelere
                cmd.Parameters.Add("facebook", SqlDbType.NVarChar, 50).Value = a2;
                cmd.Parameters.Add("linkedin", SqlDbType.NVarChar, 50).Value = a3; ; //Stored procedure deki parametrelere
                cmd.Parameters.Add("İnstagram", SqlDbType.NVarChar, 50).Value = a4;

                cmd.ExecuteNonQuery();
                con.Close();

                KayıtEkleDatabase(EPosta, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");

            }
            else
            {
                label122.Visible = true;
            }
        }

        private void siticoneCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneCheckBox1.Checked == true)
            {
                siticoneTextBox8.UseSystemPasswordChar = false;
                siticoneTextBox8.PasswordChar = '\0';
                siticoneTextBox9.UseSystemPasswordChar = false;
                siticoneTextBox9.PasswordChar = '\0';
                siticoneTextBox10.UseSystemPasswordChar = false;
                siticoneTextBox10.PasswordChar = '\0';
            }
            if (siticoneCheckBox1.Checked == false)
            {
                siticoneTextBox8.UseSystemPasswordChar = true;
                siticoneTextBox8.PasswordChar = '\0';
                siticoneTextBox9.UseSystemPasswordChar = true;
                siticoneTextBox9.PasswordChar = '\0';
                siticoneTextBox10.UseSystemPasswordChar = true;
                siticoneTextBox10.PasswordChar = '\0';
            }
        }

        private void siticoneButton63_Click(object sender, EventArgs e)
        {
            string a = Convert.ToString(siticoneNumericUpDown1.Value);
            string b = Convert.ToString(siticoneNumericUpDown2.Value);
            int c = 0;
            int c1 = 0;
            int c2 = 0;
            int c3 = 0;
            int c4 = 0;
            int c5 = 0;
            int c6 = 0;
            int c7 = 0;
            if (siticoneToggleSwitch4.Checked)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
            if (siticoneToggleSwitch5.Checked)
            {
                c1 = 1;
            }
            else
            {
                c1 = 0;

            }
            if (siticoneToggleSwitch6.Checked)
            {
                c2 = 1;
            }
            else
            {
                c2 = 0;
            }
            if (siticoneCheckBox2.Checked)
            {
                c3 = 1;
            }
            else
            {
                c3 = 0;
            }
            if (siticoneCheckBox3.Checked)
            {
                c4 = 1;
            }
            else
            {
                c4 = 0;
            }
            if (siticoneCheckBox4.Checked)
            {
                c5 = 1;
            }
            else
            {
                c5 = 0;
            }
            if (siticoneCheckBox5.Checked)
            {
                c6 = 1;
            }
            else
            {
                c6 = 0;
            }
            if (siticoneCheckBox6.Checked)
            {
                c7 = 1;
            }
            else
            {
                c7 = 0;
            }
            MessageBox.Show("Verilerini kaydedildi", "BalNature Database services");

            SqlConnection con = new SqlConnection("Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "bildirimproc"; //Stored Procedure' ümüzün ismi
            cmd.Parameters.Add("EPosta", SqlDbType.NVarChar, 50).Value = EPosta; //Stored procedure deki parametrelere
            cmd.Parameters.Add("@kaçgündebir", SqlDbType.NVarChar, 50).Value = a;
            cmd.Parameters.Add("@gündekaçkere", SqlDbType.NVarChar, 50).Value = b;//Stored procedure deki parametrelere
            cmd.Parameters.Add("@masaüstübildirim", SqlDbType.Int).Value = c;
            cmd.Parameters.Add("@epostabildirim", SqlDbType.Int).Value = c1; ; //Stored procedure deki parametrelere
            cmd.Parameters.Add("@seazer", SqlDbType.Int).Value = c2;
            cmd.Parameters.Add("@sanaldepo", SqlDbType.Int).Value = c7;
            cmd.Parameters.Add("@günlükbildirim", SqlDbType.Int).Value = c3;//Stored procedure deki parametrelere
            cmd.Parameters.Add("@saniye2", SqlDbType.Int).Value = c4;
            cmd.Parameters.Add("@uyarıver", SqlDbType.Int).Value = c5; ; //Stored procedure deki parametrelere
            cmd.Parameters.Add("@bildirim5gün", SqlDbType.Int).Value = c6;

            cmd.ExecuteNonQuery();
            con.Close();

            KayıtEkleDatabase(EPosta, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");

        }

        private void siticoneButton65_Click(object sender, EventArgs e)
        {
            int a = 0, a1 = 0, a2 = 0, a3 = 0, a4 = 0, a5 = 0, a6 = 0;
            if (siticoneCheckBox10.Checked)
            {
                a = 1;
            }
            else
            {
                a = 0;
            }
            if (siticoneCheckBox11.Checked)
            {
                a1 = 1;
            }
            else
            {
                a1 = 0;
            }
            if (siticoneCheckBox12.Checked)
            {
                a2 = 1;
            }
            else
            {
                a2 = 0;
            }
            if (siticoneCheckBox13.Checked)
            {
                a3 = 1;
            }
            else
            {
                a3 = 0;
            }
            if (siticoneCheckBox7.Checked)
            {
                a4 = 1;
            }
            else
            {
                a4 = 0;
            }
            if (siticoneCheckBox8.Checked)
            {
                a5 = 1;
            }
            else
            {
                a5 = 0;
            }
            if (siticoneCheckBox9.Checked)
            {
                a6 = 1;
            }
            else
            {
                a6 = 0;
            }
            MessageBox.Show("Verilerini kaydedildi", "BalNature Database services");

            SqlConnection con = new SqlConnection("Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sonproc2"; //Stored Procedure' ümüzün ismi
            cmd.Parameters.Add("EPosta", SqlDbType.NVarChar, 50).Value = EPosta; //Stored procedure deki parametrelere
            cmd.Parameters.Add("@verilerkayt", SqlDbType.Int).Value = a;
            cmd.Parameters.Add("@database", SqlDbType.Int).Value = a1;//Stored procedure deki parametrelere
            cmd.Parameters.Add("@analiz", SqlDbType.Int).Value = a2;
            cmd.Parameters.Add("@başkaları", SqlDbType.Int).Value = a3; ; //Stored procedure deki parametrelere
            cmd.Parameters.Add("@üçüncü", SqlDbType.Int).Value = a6;
            cmd.Parameters.Add("@yükseltme", SqlDbType.Int).Value = a5;
            cmd.Parameters.Add("@üçüncü2", SqlDbType.Int).Value = a6;//Stored procedure deki parametrelere


            cmd.ExecuteNonQuery();
            con.Close();

            KayıtEkleDatabase(EPosta, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");

        }

        private void siticoneButton67_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Tüm verileriniz ve mevcut hesabınız silinecek devam etmak istediğinize emin misiniz?", "BalNature Acount Services", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (a == DialogResult.OK)
            {
                MessageBox.Show("Verileriniz Silindi uygulama kapatılacak", "BalNature Database services");

                SqlConnection con = new SqlConnection("Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sonproc3"; //Stored Procedure' ümüzün ismi
                cmd.Parameters.Add("EPosta", SqlDbType.NVarChar, 50).Value = EPosta; //Stored procedure deki parametrelere

                cmd.ExecuteNonQuery();
                con.Close();
                File.Delete(@"C:\ProgramData\SEAzer\BALNature\mevcutkullanıcı.txt");
                this.Close();
            }
            else
            {

            }


        }

        private void siticoneButton70_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Hesaptan çıkılacak devam etmak istediğinize emin misiniz?", "BalNature Acount Services", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (a == DialogResult.OK)
            {
                MessageBox.Show("Hesaptan çıkılacak, uygulama kapatılacak", "BalNature Database services");
                File.Delete(@"C:\ProgramData\SEAzer\BALNature\mevcutkullanıcı.txt");
                this.Close();
            }
            else
            {

            }

        }

        private void siticoneButton68_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Tüm verileriniz silinecek devam etmak istediğinize emin misiniz?", "BalNature Acount Services", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (a == DialogResult.OK)
            {
                MessageBox.Show("Veriler temizlendi, uygulama kapatılacak", "BalNature Database services");

                SqlConnection con = new SqlConnection("Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sonproc4"; //Stored Procedure' ümüzün ismi
                cmd.Parameters.Add("EPosta", SqlDbType.NVarChar, 50).Value = EPosta; //Stored procedure deki parametrelere

                cmd.ExecuteNonQuery();
                con.Close();
                this.Close();
            }
            else
            {

            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void siticoneChip1_Click(object sender, EventArgs e)
        {

        }






        private void siticoneChip3_MouseEnter(object sender, EventArgs e)
        {
            siticoneChip3.FillColor = Color.Green;
            siticoneChip3.ForeColor = Color.Silver;
        }

        private void siticoneChip2_MouseEnter(object sender, EventArgs e)
        {
            siticoneChip2.FillColor = Color.Green;
            siticoneChip2.ForeColor = Color.Silver;
        }

        private void siticoneChip1_MouseEnter(object sender, EventArgs e)
        {
            siticoneChip1.FillColor = Color.Green;
            siticoneChip1.ForeColor = Color.Silver;
        }

        private void siticoneChip5_MouseEnter(object sender, EventArgs e)
        {
            siticoneChip5.FillColor = Color.Green;
            siticoneChip5.ForeColor = Color.Silver;
        }

        private void siticoneChip8_MouseEnter(object sender, EventArgs e)
        {
            siticoneChip8.FillColor = Color.Green;
            siticoneChip8.ForeColor = Color.Silver;
        }

        private void siticoneChip7_MouseEnter(object sender, EventArgs e)
        {
            siticoneChip7.FillColor = Color.Green;
            siticoneChip7.ForeColor = Color.Silver;
        }

        private void siticoneChip4_Click(object sender, EventArgs e)
        {

        }

        private void siticoneChip4_MouseEnter_1(object sender, EventArgs e)
        {
            siticoneChip4.FillColor = Color.Green;
            siticoneChip4.ForeColor = Color.Silver;
        }

        private void siticoneChip4_DragLeave(object sender, EventArgs e)
        {
            siticoneChip4.FillColor = Color.Silver;
            siticoneChip4.ForeColor = Color.Green;
        }

        private void siticoneChip3_MouseLeave(object sender, EventArgs e)
        {
            siticoneChip3.FillColor = Color.Silver;
            siticoneChip3.ForeColor = Color.Green;
        }

        private void siticoneChip2_MouseLeave(object sender, EventArgs e)
        {
            siticoneChip2.FillColor = Color.Silver;
            siticoneChip2.ForeColor = Color.Green;
        }

        private void siticoneChip1_MouseLeave(object sender, EventArgs e)
        {
            siticoneChip1.FillColor = Color.Silver;
            siticoneChip1.ForeColor = Color.Green;
        }

        private void siticoneChip5_MouseLeave(object sender, EventArgs e)
        {
            siticoneChip5.FillColor = Color.Silver;
            siticoneChip5.ForeColor = Color.Green;
        }

        private void siticoneChip8_MouseLeave(object sender, EventArgs e)
        {
            siticoneChip8.FillColor = Color.Silver;
            siticoneChip8.ForeColor = Color.Green;
        }

        private void siticoneChip7_MouseLeave(object sender, EventArgs e)
        {
            siticoneChip7.FillColor = Color.Silver;
            siticoneChip7.ForeColor = Color.Green;
        }

        private void siticoneChip4_MouseLeave(object sender, EventArgs e)
        {
            siticoneChip4.FillColor = Color.Silver;
            siticoneChip4.ForeColor = Color.Green;
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (siticoneTabControl2.SelectedTab == tabPage7)
            {
                siticoneTabControl2.SelectedTab = tabPage8;
                siticoneComboBox2.Enabled = true;
                siticoneComboBox2.SelectedIndex = 1;

            }
        }

        private void siticoneTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (siticoneTabControl2.SelectedTab == tabPage7)
            {
                siticonePictureBox2.FillColor = Color.FromArgb(50, 60, 64);
                siticonePictureBox3.FillColor = Color.FromArgb(50, 60, 64);
                label1.ForeColor = Color.FromArgb(50, 60, 64);
                siticoneComboBox2.SelectedIndex = 0;
                siticoneComboBox2.Enabled = false;
                siticoneButton1.Visible = true;
                siticoneButton8.Visible = true;
                siticoneButton10.Visible = true;
                siticoneButton11.Visible = true;
                siticoneButton12.Visible = true;
                siticoneComboBox2.Visible = true;
                siticonePictureBox2.Visible = false;
                label1.Visible = false;
                siticonePictureBox3.Visible = false;
            }
            else if (siticoneTabControl2.SelectedTab == tabPage8)
            {
                siticonePictureBox2.FillColor = Color.FromArgb(50, 60, 64);
                siticonePictureBox3.FillColor = Color.FromArgb(50, 60, 64);
                label1.ForeColor = Color.FromArgb(50, 60, 64);
                siticoneComboBox2.SelectedIndex = 1;
                siticoneComboBox2.Enabled = true;
                siticoneButton1.Visible = true;
                siticoneButton8.Visible = true;
                siticoneButton10.Visible = true;
                siticoneButton11.Visible = true;
                siticoneButton12.Visible = true;
                siticoneComboBox2.Visible = true;
                siticonePictureBox2.Visible = false;
                label1.Visible = false;
                siticonePictureBox3.Visible = false;
            }
            else if (siticoneTabControl2.SelectedTab == tabPage15)
            {
                label1.Text = "Veri Listele";
                siticonePictureBox2.FillColor = Color.Silver;

                siticonePictureBox3.FillColor = Color.Silver;
                label1.ForeColor = Color.Silver;
                siticoneButton1.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                siticoneButton12.Visible = false;
                siticoneComboBox2.Visible = false;
                siticonePictureBox2.Visible = true;
                label1.Visible = true;
                siticonePictureBox3.Visible = true;
            }
            else if (siticoneTabControl2.SelectedTab == tabPage22)
            {
                label1.Text = "Veri Çıkar";
                siticonePictureBox2.FillColor = Color.Silver;

                siticonePictureBox3.FillColor = Color.Silver;
                label1.ForeColor = Color.Silver;
                siticoneButton1.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                siticoneButton12.Visible = false;
                siticoneComboBox2.Visible = false;
                siticonePictureBox2.Visible = true;
                label1.Visible = true;
                siticonePictureBox3.Visible = true;
            }
            else if (siticoneTabControl2.SelectedTab == tabPage22)
            {
                label1.Text = "Veri Düzenle";
                siticonePictureBox2.FillColor = Color.Silver;

                siticonePictureBox3.FillColor = Color.Silver;
                label1.ForeColor = Color.Silver;
                siticoneButton1.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                siticoneButton12.Visible = false;
                siticoneComboBox2.Visible = false;
                siticonePictureBox2.Visible = true;
                label1.Visible = true;
                siticonePictureBox3.Visible = true;
            }
            else
            {
                if (siticoneTabControl2.SelectedTab == tabPage9)
                {
                    label1.Text = "Veri Ekle";
                }
                if (siticoneTabControl2.SelectedTab == tabPage8)
                {
                    label1.Text = "Verileri Listele";
                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    dataGridView1.DataSource = Data;

                }
                siticonePictureBox2.FillColor = Color.Silver;

                siticonePictureBox3.FillColor = Color.Silver;
                label1.ForeColor = Color.Silver;
                siticoneButton1.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                siticoneButton12.Visible = false;
                siticoneComboBox2.Visible = false;
                siticonePictureBox2.Visible = true;
                label1.Visible = true;
                siticonePictureBox3.Visible = true;
            }
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void radCalendar2_SelectionChanged(object sender, EventArgs e)
        {
            if (radCalendar2.SelectedDate > DateTime.Now)
            {
                label133.Text = DateTime.Now.ToShortDateString();
                MessageBox.Show("Lütfen günümüz veya daha öncesini seçiniz.");
                label133.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                label133.Text = radCalendar2.SelectedDate.ToShortDateString();

            }

        }

        private void siticoneImageRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneImageRadioButton2.Checked == true)
            {
                label137.ForeColor = Color.FromArgb(119, 190, 79);
                label138.ForeColor = Color.Black; label139.ForeColor = Color.FromArgb(119, 190, 79);
                siticoneTextBox18.ForeColor = Color.FromArgb(119, 190, 79);

            }
        }

        private void siticoneImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneImageRadioButton1.Checked == true)
            {
                label137.ForeColor = Color.Black;
                label138.ForeColor = Color.FromArgb(119, 190, 79); label139.ForeColor = Color.FromArgb(119, 190, 79);
                siticoneTextBox18.ForeColor = Color.FromArgb(119, 190, 79);

            }


        }

        private void label139_Click(object sender, EventArgs e)
        {

        }

        private void siticoneImageRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneImageRadioButton3.Checked == true)
            {
                label137.ForeColor = Color.FromArgb(119, 190, 79);
                label138.ForeColor = Color.FromArgb(119, 190, 79); label139.ForeColor = Color.Black;
                siticoneTextBox18.ForeColor = Color.FromArgb(119, 190, 79);

            }
        }

        private void siticoneImageRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneImageRadioButton4.Checked == true)
            {
                label137.ForeColor = Color.FromArgb(119, 190, 79);
                label138.ForeColor = Color.FromArgb(119, 190, 79); label139.ForeColor = Color.FromArgb(119, 190, 79);
                siticoneTextBox18.ForeColor = Color.Black;

            }
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {
            siticoneTabControl2.SelectedTab = tabPage9;
        }

        private void siticoneButton39_Click_1(object sender, EventArgs e)
        {
            siticoneTabControl2.SelectedTab = tabPage7;
        }

        private void siticoneButton72_Click(object sender, EventArgs e)
        {
            siticoneTabControl2.SelectedTab = tabPage11;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (eklemeler == "Boş" || eklemeler == "Bos")
            {
                MessageBox.Show("Kayıtlı Veriniz Bulunmamaktadır", "Bal Nature Database Servisi");
            }
            else
            {


                List<kayıtsınıfı> Data = Veridönüştürü( );
                dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                foreach (var a in Data)
                {
                    this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                }
            }
        }

        private void radTaskbarButton1_ThumbnailButtonClick(object sender, Telerik.WinControls.Taskbar.ThumbnailButtonEventArgs e)
        {
            if (e.Button == radTaskbarButton1.ThumbnailButtons[1])
            {
                siticoneTabControl2.SelectedTab = tabPage7;
                siticoneComboBox2.Enabled = false;
                siticoneChip1.BorderRadius = 12;
                siticoneChip2.BorderRadius = 12;
                siticoneChip3.BorderRadius = 12;
                siticoneChip4.BorderRadius = 12;
                siticoneChip5.BorderRadius = 12;

                siticoneChip8.BorderRadius = 12;
                siticoneChip7.BorderRadius = 12;
                siticoneButton56.Visible = false;
                siticoneButton57.Visible = false;
                siticoneButton58.Visible = false;
                siticoneButton59.Visible = false;
                siticoneButton60.Visible = false;
                panel6.Visible = false;
                if (bildirimmenüsüaçıkmı == true)
                {
                    panel6.Visible = false;
                    bildirimmenüsüaçıkmı = false;
                }
                if (Hesapaçıkmı == true)
                {
                    timer1.Interval = 1;
                    timer1.Start();
                    siticoneImageButton1.Enabled = false;
                    siticoneButton43.Visible = false;
                    siticoneButton44.Visible = false;




                    siticoneButton48.Visible = false;
                    siticoneButton49.Visible = false;
                    siticoneButton50.Visible = false;
                }
                panel4.Visible = false;

                label4.Visible = true;
                chromiumWebBrowser2.Visible = false;
                siticoneButton1.Visible = true; siticoneComboBox2.Visible = true; siticoneComboBox1.Visible = false; siticoneTextBox1.Visible = false;
                siticonePictureBox2.Visible = false;
                label1.Visible = false;
                siticonePictureBox3.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                label3.Visible = false;
                siticoneButton12.Visible = false;
                siticoneButton8.Visible = true;
                siticoneButton14.Visible = false;
                siticoneButton15.Visible = false;
                siticoneButton16.Visible = false;
                siticoneButton17.Visible = false;
                siticoneButton18.Visible = false;
                siticoneButton19.Visible = false;
                siticoneButton20.Visible = false;
                siticoneButton21.Visible = false;
                siticoneButton10.Visible = true;
                siticoneButton11.Visible = true;
                siticoneButton12.Visible = true;
                siticoneButton13.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton2.FillColor = Color.FromArgb(56, 60, 64);
                siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton4.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton6.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton22.Visible = false;
                siticoneButton23.Visible = false;
                siticoneButton24.Visible = false;
                siticoneButton25.Visible = false;
                siticonePanel2.Visible = true;
                siticoneTabControl2.SelectedTab = tabPage9;
                this.WindowState = FormWindowState.Maximized;
            }

            else if (e.Button == radTaskbarButton1.ThumbnailButtons[0])
            {
                List<kayıtsınıfı> Data = Veridönüştürü( );

                foreach (var a in Data)
                {

                    this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);




                }

                siticoneTabControl2.SelectedTab = tabPage7;
                siticoneComboBox2.Enabled = false;
                siticoneChip1.BorderRadius = 12;
                siticoneChip2.BorderRadius = 12;
                siticoneChip3.BorderRadius = 12;
                siticoneChip4.BorderRadius = 12;
                siticoneChip5.BorderRadius = 12;

                siticoneChip8.BorderRadius = 12;
                siticoneChip7.BorderRadius = 12;
                siticoneButton56.Visible = false;
                siticoneButton57.Visible = false;
                siticoneButton58.Visible = false;
                siticoneButton59.Visible = false;
                siticoneButton60.Visible = false;
                panel6.Visible = false;
                if (bildirimmenüsüaçıkmı == true)
                {
                    panel6.Visible = false;
                    bildirimmenüsüaçıkmı = false;
                }
                if (Hesapaçıkmı == true)
                {
                    timer1.Interval = 1;
                    timer1.Start();
                    siticoneImageButton1.Enabled = false;
                    siticoneButton43.Visible = false;
                    siticoneButton44.Visible = false;




                    siticoneButton48.Visible = false;
                    siticoneButton49.Visible = false;
                    siticoneButton50.Visible = false;
                }
                panel4.Visible = false;

                label4.Visible = true;
                chromiumWebBrowser2.Visible = false;
                siticoneButton1.Visible = true; siticoneComboBox2.Visible = true; siticoneComboBox1.Visible = false; siticoneTextBox1.Visible = false;
                siticonePictureBox2.Visible = false;
                label1.Visible = false;
                siticonePictureBox3.Visible = false;
                siticoneButton8.Visible = false;
                siticoneButton10.Visible = false;
                siticoneButton11.Visible = false;
                label3.Visible = false;
                siticoneButton12.Visible = false;
                siticoneButton8.Visible = true;
                siticoneButton14.Visible = false;
                siticoneButton15.Visible = false;
                siticoneButton16.Visible = false;
                siticoneButton17.Visible = false;
                siticoneButton18.Visible = false;
                siticoneButton19.Visible = false;
                siticoneButton20.Visible = false;
                siticoneButton21.Visible = false;
                siticoneButton10.Visible = true;
                siticoneButton11.Visible = true;
                siticoneButton12.Visible = true;
                siticoneButton13.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton2.FillColor = Color.FromArgb(56, 60, 64);
                siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton4.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton6.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
                siticoneButton22.Visible = false;
                siticoneButton23.Visible = false;
                siticoneButton24.Visible = false;
                siticoneButton25.Visible = false;
                siticonePanel2.Visible = true;
                siticoneTabControl2.SelectedTab = tabPage9;
                this.WindowState = FormWindowState.Maximized;

                siticoneTabControl2.SelectedTab = tabPage15;
                this.WindowState = FormWindowState.Maximized;
            }
            else if (e.Button == radTaskbarButton1.ThumbnailButtons[2])
            {
                siticonePanel2.Visible = false;
                label123.Visible = false;
                siticonePanel1.Visible = false;
                panel1.Visible = true;
                panel11.Visible = false;
                label80.Visible = false;
                label81.Visible = false;
                label79.Visible = false;
                label63.Visible = false;
                linkLabel16.Visible = false;
                linkLabel17.Visible = false;
                linkLabel18.Visible = false;
                linkLabel19.Visible = false;
                linkLabel20.Visible = false;
                siticonePictureBox27.Visible = false;
                siticonePictureBox28.Visible = false;
                siticonePictureBox29.Visible = false;
                siticonePictureBox30.Visible = false;
                siticonePictureBox31.Visible = false;
                siticoneGroupBox1.Visible = false;
                label64.Visible = false;
                label66.Visible = false;
                label67.Visible = false;
                label68.Visible = false;
                label69.Visible = false;
                label70.Visible = false;
                label71.Visible = false;
                label72.Visible = false;
                label73.Visible = false;
                label74.Visible = false;
                label75.Visible = false;
                siticonePictureBox25.Visible = false;
                linkLabel14.Visible = false;
                linkLabel15.Visible = false;
                label47.Visible = true;
                label48.Visible = true;
                label49.Visible = true;
                siticonePictureBox22.Visible = true;
                siticonePictureBox23.Visible = true;
                siticonePictureBox24.Visible = true;
                label50.Visible = false;
                label51.Visible = false;
                label52.Visible = false;
                label53.Visible = false;
                label54.Visible = false;
                label55.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = false;
                pictureBox14.Visible = false;
                pictureBox15.Visible = false;
                pictureBox16.Visible = false;
                pictureBox17.Visible = false;
                label57.Visible = false;
                label58.Visible = false;
                label59.Visible = false;
                label60.Visible = false;
                label61.Visible = false;
                label62.Visible = false;
                label56.Visible = false;

                siticoneButton56.Visible = false;
                siticoneButton57.Visible = false;
                siticoneButton58.Visible = false;
                siticoneButton59.Visible = false;
                siticoneButton60.Visible = false;
                siticoneProgressBar1.Value = 0;
                siticoneProgressBar2.Value = 0;
                siticoneProgressBar3.Value = 0;
                siticoneProgressBar4.Value = 0;
                siticoneProgressBar5.Value = 0;
                siticoneProgressBar6.Value = 0;
                if (bildirimmenüsüaçıkmı == true)
                {
                    panel6.Visible = false;
                    bildirimmenüsüaçıkmı = false;
                }
                if (Hesapaçıkmı == true)
                {
                    timer1.Interval = 1;
                    timer1.Start();
                    siticoneImageButton1.Enabled = false;
                    siticoneButton43.Visible = false;
                    siticoneButton44.Visible = false;




                    siticoneButton48.Visible = false;
                    siticoneButton49.Visible = false;
                    siticoneButton50.Visible = false;
                }
                if (indirilenkısmıaçıkmı == false)
                {
                    timer2.Start();
                    panel11.Visible = false;
                    tıklı = 1;
                    siticonePictureBox2.FillColor = Color.Silver;
                    siticoneButton55.Visible = true;
                    siticonePictureBox3.FillColor = Color.Silver;
                    label1.ForeColor = Color.Silver;
                    siticoneButton6.Visible = false;
                    siticoneButton7.Visible = false;
                    siticoneButton51.Visible = true;
                    panel8.Visible = true;
                    siticoneButton54.Visible = true;

                    siticoneButton53.Visible = true;
                    siticoneButton2.Visible = false;
                    siticoneButton3.Visible = false;
                    siticoneButton4.Visible = false;
                    siticoneButton5.Visible = false;
                    siticoneButton9.Visible = false;
                    siticoneButton13.Visible = false;
                    indirilenkısmıaçıkmı = true;
                    chromiumWebBrowser2.Visible = false;


                    siticoneButton22.Visible = false;
                    siticoneButton23.Visible = false;
                    siticoneButton24.Visible = false;
                    siticoneButton25.Visible = false;
                    siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
                    siticoneButton8.Visible = false;
                    siticoneButton14.Visible = false;
                    siticoneButton15.Visible = false;
                    siticoneButton16.Visible = false;
                    siticoneButton17.Visible = false;
                    siticoneButton18.Visible = false;
                    siticoneButton19.Visible = false;
                    label3.Visible = false;

                    label6.Visible = true;
                    siticoneButton20.Visible = false;
                    siticoneButton21.Visible = false;
                    siticoneButton10.Visible = false;
                    siticoneButton11.Visible = false;
                    siticoneButton12.Visible = false;
                    siticoneTextBox1.Visible = false;
                    siticoneComboBox1.Visible = false;
                    siticonePictureBox2.Visible = true;
                    label1.Visible = true;
                    siticonePictureBox3.Visible = true;
                }
                else
                {
                    timer2.Stop();
                    tıklı = 1;
                    chromiumWebBrowser2.Visible = true;
                    siticonePictureBox2.FillColor = Color.FromArgb(50, 60, 64);
                    siticonePictureBox3.FillColor = Color.FromArgb(50, 60, 64);
                    label1.ForeColor = Color.FromArgb(50, 60, 64);
                    panel11.Visible = false;
                    panel6.Visible = false;
                    panel4.Visible = false;
                    siticoneButton55.Visible = false;

                    label4.Visible = false;
                    chromiumWebBrowser2.Visible = true;
                    siticoneButton22.Visible = false;
                    siticoneButton23.Visible = false;
                    siticoneButton24.Visible = false;
                    siticoneButton25.Visible = false;
                    siticoneButton1.Visible = false; siticoneComboBox2.Visible = false;
                    siticoneButton8.Visible = false;
                    siticoneButton14.Visible = false;
                    siticoneButton15.Visible = false;
                    siticoneButton16.Visible = false;
                    siticoneButton17.Visible = false;
                    siticoneButton18.Visible = false;
                    siticoneButton19.Visible = false;
                    label3.Visible = true;
                    siticoneButton20.Visible = false;
                    siticoneButton21.Visible = false;
                    siticoneButton10.Visible = false;
                    siticoneButton11.Visible = false;
                    siticoneButton12.Visible = false;
                    siticoneTextBox1.Visible = false;
                    siticoneComboBox1.Visible = false;
                    siticonePictureBox2.Visible = true;
                    label1.Visible = true;
                    siticonePictureBox3.Visible = true;
                    siticoneButton13.FillColor = Color.FromArgb(56, 60, 64);
                    siticoneButton2.FillColor = Color.FromArgb(22, 26, 31);
                    siticoneButton3.FillColor = Color.FromArgb(22, 26, 31);
                    siticoneButton4.FillColor = Color.FromArgb(22, 26, 31);
                    siticoneButton5.FillColor = Color.FromArgb(22, 26, 31);
                    siticoneButton6.FillColor = Color.FromArgb(22, 26, 31); siticoneButton9.FillColor = Color.FromArgb(22, 26, 31);
                    siticoneButton7.FillColor = Color.FromArgb(22, 26, 31);
                    label3.Visible = true;
                    label6.Visible = false;
                    siticoneButton6.Visible = true;
                    siticoneButton7.Visible = true;
                    siticoneButton51.Visible = false;
                    panel8.Visible = false;
                    indirilenkısmıaçıkmı = false;
                    siticoneButton54.Visible = false;

                    siticoneButton53.Visible = false;
                    siticoneButton2.Visible = true;
                    siticoneButton3.Visible = true;
                    siticoneButton4.Visible = true;
                    siticoneButton5.Visible = true;
                    siticoneButton9.Visible = true;
                    siticoneButton13.Visible = true;
                    this.WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void radCardView1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void radCardView1_CardViewItemFormatting(object sender, CardViewItemFormattingEventArgs e)
        {
            CardViewItem item = e.Item as CardViewItem;
            if (item != null && item.FieldName == "Column 0")
            {
                e.Item.NumberOfColors = 1;
                e.Item.ForeColor = Color.Green;
                e.Item.BorderColor = Color.Black;
                e.Item.Font = new Font("Segoe Print", 12);
            }
            else if (e.VisualItem.Selected)
            {
                e.VisualItem.NumberOfColors = 1;
                e.VisualItem.BackColor = Color.Gainsboro;
                e.VisualItem.ForeColor = Color.Blue;
                e.VisualItem.BorderColor = Color.Black;
                e.Item.Font = new Font("Segoe Print", 11);
            }
            else
            {
                e.VisualItem.ResetValue(LightVisualElement.NumberOfColorsProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.VisualItem.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.VisualItem.ResetValue(LightVisualElement.ForeColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.VisualItem.ResetValue(LightVisualElement.BorderColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.VisualItem.ResetValue(LightVisualElement.FontProperty, Telerik.WinControls.ValueResetFlags.Local);
            }
        }
        void kontrol()
        {
            if (siticoneToggleSwitch7.Checked == true)
            {

                label163.ForeColor = Color.White;
                radCardView1.CardViewElement.ViewElement.Orientation = Orientation.Vertical;
                label163.Text = "Dikey Sıralama";
            }
            else
            {
                label163.ForeColor = Color.Black;
                radCardView1.CardViewElement.ViewElement.Orientation = Orientation.Horizontal; label163.Text = "Yatay Sıralama";
            }
        }
        void kontrol2()
        {
            if (siticoneToggleSwitch8.Checked == true)
            {

                label131.ForeColor = Color.White;
                radCardView2.CardViewElement.ViewElement.Orientation = Orientation.Vertical;
                label131.Text = "Dikey Sıralama";
            }
            else
            {
                label131.ForeColor = Color.Black;
                radCardView2.CardViewElement.ViewElement.Orientation = Orientation.Horizontal; label163.Text = "Yatay Sıralama";
            }
        }
        private void siticoneToggleSwitch7_CheckedChanged(object sender, EventArgs e)
        {

            kontrol();
        }

        private void siticoneComboBox5_SelectedIndexChanged(object sender, EventArgs e)//grup
        {
            if (siticoneComboBox4.SelectedIndex == 0)
            {


                radCardView1.Groups.Clear();
                radCardView1.Items.Clear();
                if (siticoneComboBox5.SelectedIndex == 1)
                {
                    this.radCardView1.EnableGrouping = true;
                    this.radCardView1.ShowGroups = true;
                    this.radCardView1.EnableCustomGrouping = true;
                    kontrol();
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                    int item = 0;
                    foreach (var a in Data)
                    {
                        item++;
                        this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        if (a.zamanx.Month == 1)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                        }

                        if (a.zamanx.Month == 2)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                        }
                        if (a.zamanx.Month == 3)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                        }
                        if (a.zamanx.Month == 4)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                        }
                        if (a.zamanx.Month == 5)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                        }
                        if (a.zamanx.Month == 6)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                        }
                        if (a.zamanx.Month == 7)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                        }
                        if (a.zamanx.Month == 8)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                        }
                        if (a.zamanx.Month == 9)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                        }
                        if (a.zamanx.Month == 10)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                        }
                        if (a.zamanx.Month == 11)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                        }
                        if (a.zamanx.Month == 12)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                        }
                    }



                }
                else if (siticoneComboBox5.SelectedIndex == 0)
                {


                    radCardView1.GroupDescriptors.Clear();
                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                    radTaskbarButton1.Flash(123456, 6);
                    foreach (var a in Data)
                    {
                        this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                    }
                }
                else if (siticoneComboBox5.SelectedIndex == 2)
                {


                    radCardView1.GroupDescriptors.Clear();
                    this.radCardView1.EnableGrouping = true;
                    this.radCardView1.ShowGroups = true;
                    this.radCardView1.EnableCustomGrouping = true;
                    kontrol();
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                    int item = 0;
                    radTaskbarButton1.Flash(123456, 6);
                    foreach (var a in Data)
                    {
                        item++;
                        this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        if (a.kayıtdeğerlendirme > 79.9)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                        }
                        else if (a.kayıtdeğerlendirme > 59.9)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                        }
                        else if (a.kayıtdeğerlendirme > 39.9)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                        }
                        else if (a.kayıtdeğerlendirme > 19.9)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                        }
                        else
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                        }

                    }

                }
                else if (siticoneComboBox5.SelectedIndex == 3)
                {


                    radCardView1.GroupDescriptors.Clear();
                    this.radCardView1.EnableGrouping = true;
                    this.radCardView1.ShowGroups = true;
                    this.radCardView1.EnableCustomGrouping = true;
                    kontrol();
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                    int item = 0;
                    radTaskbarButton1.Flash(123456, 6);
                    foreach (var a in Data)
                    {
                        item++;
                        this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                        if (a.toplamatıkoranx > 100)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                        }

                        else if (a.toplamatıkoranx > 50)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                        }
                        else
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                        }

                    }
                }
                else if (siticoneComboBox5.SelectedIndex == 4)
                {


                    radCardView1.GroupDescriptors.Clear();
                    this.radCardView1.EnableGrouping = true;
                    this.radCardView1.ShowGroups = true;
                    this.radCardView1.EnableCustomGrouping = true;
                    kontrol();
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                    this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                    int item = 0;
                    radTaskbarButton1.Flash(123456, 6);
                    foreach (var a in Data)
                    {
                        item++;
                        this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                        }

                        else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                        }
                        else
                        {
                            this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                        }

                    }
                }
                else
                {


                }
            }
        }

        private void siticoneButton38_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(siticoneTextBox15.Text))
            {
                MessageBox.Show("Lütfen yukarıda belirtilen alanların hepsini doldurun. ", "Bal Nature Kayıt Servisi");
            }
            else if (String.IsNullOrEmpty(siticoneTextBox17.Text))
            {
                MessageBox.Show("Lütfen yukarıda belirtilen alanların hepsini doldurun. ", "Bal Nature Kayıt Servisi");
            }
            else
            {
                kayıtbaşlık = siticoneTextBox15.Text;
                kayıtaçıklama = siticoneTextBox17.Text;
                siticoneTabControl2.SelectedTab = tabPage10;
            }

        }

        private void siticoneComboBox6_SelectedIndexChanged(object sender, EventArgs e)//sıralama
        {
            if (siticoneComboBox4.SelectedIndex == 0)
            {


                this.radCardView1.SortDescriptors.Clear();
                radCardView1.Groups.Clear();
                radCardView1.Items.Clear();
                if (siticoneComboBox6.SelectedIndex == 0)
                {
                    this.radCardView1.SortDescriptors.Clear();
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        this.radCardView1.CardViewElement.ViewElement.Orientation = Orientation.Horizontal;
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }

                }
                if (siticoneComboBox6.SelectedIndex == 1)
                {

                    this.radCardView1.SortDescriptors.Clear();
                    this.radCardView1.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 25", ListSortDirection.Ascending);
                    this.radCardView1.SortDescriptors.Add(sortDescriptor);
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }

                }
                if (siticoneComboBox6.SelectedIndex == 2)
                {

                    this.radCardView1.SortDescriptors.Clear();
                    this.radCardView1.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 25", ListSortDirection.Descending);
                    this.radCardView1.SortDescriptors.Add(sortDescriptor);
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 3)
                {

                    this.radCardView1.SortDescriptors.Clear();
                    this.radCardView1.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 24", ListSortDirection.Ascending);
                    this.radCardView1.SortDescriptors.Add(sortDescriptor);
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 4)
                {

                    this.radCardView1.SortDescriptors.Clear();
                    this.radCardView1.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 24", ListSortDirection.Descending);
                    this.radCardView1.SortDescriptors.Add(sortDescriptor);
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                }

                if (siticoneComboBox6.SelectedIndex == 5)
                {

                    this.radCardView1.SortDescriptors.Clear();
                    this.radCardView1.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 4", ListSortDirection.Ascending);
                    this.radCardView1.SortDescriptors.Add(sortDescriptor);
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }

                }
                if (siticoneComboBox6.SelectedIndex == 6)
                {

                    this.radCardView1.SortDescriptors.Clear();
                    this.radCardView1.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 4", ListSortDirection.Descending);
                    this.radCardView1.SortDescriptors.Add(sortDescriptor);
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 7)
                {

                    this.radCardView1.SortDescriptors.Clear();
                    this.radCardView1.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column15", ListSortDirection.Ascending);
                    this.radCardView1.SortDescriptors.Add(sortDescriptor);
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 8)
                {

                    this.radCardView1.SortDescriptors.Clear();
                    this.radCardView1.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 15", ListSortDirection.Descending);
                    this.radCardView1.SortDescriptors.Add(sortDescriptor);
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 9)
                {

                    this.radCardView1.SortDescriptors.Clear();
                    this.radCardView1.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 26", ListSortDirection.Descending);
                    this.radCardView1.SortDescriptors.Add(sortDescriptor);
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 10)
                {

                    this.radCardView1.SortDescriptors.Clear();
                    this.radCardView1.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 26", ListSortDirection.Ascending);
                    this.radCardView1.SortDescriptors.Add(sortDescriptor);
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 11)
                {

                    this.radCardView1.SortDescriptors.Clear();
                    this.radCardView1.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 0", ListSortDirection.Descending);
                    this.radCardView1.SortDescriptors.Add(sortDescriptor);
                    radCardView1.Groups.Clear();
                    radCardView1.Items.Clear();
                    if (siticoneComboBox5.SelectedIndex == 1)
                    {
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox5.SelectedIndex == 0)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 2)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox5.SelectedIndex == 3)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox5.SelectedIndex == 4)
                    {


                        radCardView1.GroupDescriptors.Clear();
                        this.radCardView1.EnableGrouping = true;
                        this.radCardView1.ShowGroups = true;
                        this.radCardView1.EnableCustomGrouping = true;
                        kontrol();
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView1.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView1.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[1];
                            }
                            else
                            {
                                this.radCardView1.Items[item - 1].Group = this.radCardView1.Groups[2];
                            }

                        }
                    }
                }
            }
            if (siticoneComboBox4.SelectedIndex == 1)
            {
                List<kayıtsınıfı> Data = Veridönüştürü( );
                siticoneDataGridView1.DataSource = null;
                if (siticoneComboBox6.SelectedIndex == 0)
                {
                    siticoneDataGridView1.Rows.Clear();
                    foreach (var a in Data)
                    {

                        this.siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }




                }
                if (siticoneComboBox6.SelectedIndex == 1)
                {
                    siticoneDataGridView1.Rows.Clear();

                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.zamanx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 2)
                {
                    siticoneDataGridView1.Rows.Clear();
                    Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.zamanx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 3)
                {
                    siticoneDataGridView1.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.kayıtdeğerlendirme).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 4)
                {
                    siticoneDataGridView1.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.kayıtdeğerlendirme).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 5)
                {
                    siticoneDataGridView1.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.toplamatıkx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 6)
                {
                    siticoneDataGridView1.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.toplamatıkx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 7)
                {
                    siticoneDataGridView1.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.geridönüştürülenatığıntoplamatığaoranıx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 8)
                {
                    siticoneDataGridView1.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.geridönüştürülenatığıntoplamatığaoranıx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 9)
                {
                    siticoneDataGridView1.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.toplamatıkoranx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 10)
                {
                    siticoneDataGridView1.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.toplamatıkoranx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox6.SelectedIndex == 11)
                {
                    siticoneDataGridView1.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.kayıtbaşlıkx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
            }
        }
        public bool InternetKontrol()
        {
            try
            {
                System.Net.Sockets.TcpClient kontrol_client = new System.Net.Sockets.TcpClient("www.google.com.tr", 80);
                kontrol_client.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void siticoneComboBox4_SelectedIndexChanged(object sender, EventArgs e)//liste türü
        {
            siticoneDataGridView1.Rows.Clear();
            siticoneComboBox5.SelectedIndex = 0;
            siticoneComboBox5.SelectedIndex = 0;
            siticoneComboBox6.SelectedIndex = 0;
            siticoneDataGridView1.DataSource = null;
            radCardView1.Items.Clear();
            List<kayıtsınıfı> Data = Veridönüştürü( );

            if (siticoneComboBox4.SelectedIndex == 0)
            {
                foreach (var a in Data)
                {

                    this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);




                }
                siticoneTabControl3.SelectedTab = tabPage21;
                siticoneComboBox5.Visible = true;
                siticoneComboBox5.Enabled = true;
                label163.Visible = true;
                siticoneToggleSwitch7.Visible = true;

            }
            if (siticoneComboBox4.SelectedIndex == 1)
            {


                siticoneTabControl3.SelectedTab = tabPage20;
                foreach (var a in Data)
                {

                    siticoneDataGridView1.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
                siticoneComboBox5.Enabled = false;
            }
            if (siticoneComboBox4.SelectedIndex == 2)
            {
                siticoneTabControl3.SelectedTab = tabPage19;
                siticoneComboBox5.Visible = true;
                siticoneComboBox6.Location = new Point(511, 6);
            }
            if (siticoneComboBox4.SelectedIndex == 3)
            {
                siticoneTabControl3.SelectedTab = tabPage18;
                siticoneComboBox5.Visible = true;
                siticoneComboBox6.Location = new Point(511, 6);
            }
            if (siticoneComboBox4.SelectedIndex == 4)
            {
                siticoneTabControl3.SelectedTab = tabPage17;
                siticoneComboBox5.Visible = true;
                siticoneComboBox6.Location = new Point(511, 6);
            }
        }

        private void siticoneGradientButton1_Click(object sender, EventArgs e)
        {
            List<kayıtsınıfı> Data = Veridönüştürü( );

            foreach (var a in Data)
            {

                this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);




            }
            siticoneTabControl2.SelectedTab = tabPage15;
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton11_Click(object sender, EventArgs e)
        {
            if (eklemeler == "Boş")
            {
                MessageBox.Show("Kayıtlı veriniz bulunmamaktadır lütfen ilk önce veri ekleyiniz");
            }
            else
            {
                List<kayıtsınıfı> Data = Veridönüştürü( );
                this.radCardView1.Items.Clear();
                foreach (var a in Data)
                {

                    this.radCardView1.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);




                }
                siticoneTabControl2.SelectedTab = tabPage15;
                siticoneTabControl3.SelectedTab = tabPage21;
            }

        }

        private void windowsUIButtonPanel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            this.Location = new Point(0, 0);

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            Rectangle ClienCozunurluk = new Rectangle();
            ClienCozunurluk = Screen.GetBounds(ClienCozunurluk);
            float OranWidth = ((float)ClienCozunurluk.Width / (float)SimdikiWidth);
            float OranHeight = ((float)ClienCozunurluk.Height / (float)SimdikiHeight);
            this.Scale(new SizeF(OranWidth, OranHeight));

            chromiumWebBrowser2.LoadUrl("http://balnature.great-site.net/");

        }

        private void siticoneImageButton7_Click(object sender, EventArgs e)
        {
            List<kayıtsınıfı> Data = Veridönüştürü( );
            Form6 mö = new Form6(eklemeler);
            mö.ShowDialog();
            if (eklemeler == "Boş")
            {
                siticoneTabControl2.SelectedTab = tabPage7;
                MessageBox.Show("Hiçbir veriniz bulunmamaktadır lütfen veri ekleyin", "Bal Nature Databae Service");
            }
            else
            {
                List<kayıtsınıfı> Data2 = Veridönüştürü( );
                siticoneDataGridView2.Rows.Clear();
                foreach (var a in Data2)
                {


                    siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
            }
        }




        private void siticoneButton45_Click_1(object sender, EventArgs e)
        {
            siticoneTabControl2.SelectedTab = tabPage9;
        }

        private void Form1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {

        }

        private void siticoneComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (siticoneComboBox9.SelectedIndex == 0)
            {
                if (eklemeler == "Boş")
                {
                    MessageBox.Show("Hiç bir veriniz bulunmamaktadır lütfen veri ekleyin", "Bal Nature Database Servisi");
                }
                else
                {
                    siticoneTabControl4.SelectedTab = tabPage26;
                    siticoneComboBox7.SelectedIndex = 0;
                    siticoneComboBox8.SelectedIndex = 0;
                    siticoneComboBox7.Enabled = true;
                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    siticoneDataGridView2.Rows.Clear(); siticoneComboBox8.Enabled = false;
                    foreach (var a in Data)
                    {


                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                    }

                }

            }
            if (siticoneComboBox9.SelectedIndex == 1)
            {
                if (eklemeler == "Boş")
                {
                    MessageBox.Show("Hiç bir veriniz bulunmamaktadır lütfen veri ekleyin", "Bal Nature Database Servisi");
                }
                else
                {
                    siticoneTabControl4.SelectedTab = tabPage23;
                    siticoneComboBox7.Enabled = false;
                    siticoneComboBox7.SelectedIndex = 0;
                    siticoneComboBox8.SelectedIndex = 0;
                    siticoneComboBox8.Enabled = true;
                    siticoneDataGridView2.Rows.Clear();

                    List<kayıtsınıfı> Data = Veridönüştürü( );



                }


            }
        }

        private void siticoneComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (siticoneComboBox9.SelectedIndex == 0)
            {
                List<kayıtsınıfı> Data = Veridönüştürü( );
                siticoneDataGridView2.DataSource = null;
                if (siticoneComboBox7.SelectedIndex == 0)
                {
                    siticoneDataGridView2.Rows.Clear();
                    foreach (var a in Data)
                    {

                        this.siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }




                }
                if (siticoneComboBox7.SelectedIndex == 1)
                {
                    siticoneDataGridView2.Rows.Clear();

                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.zamanx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox7.SelectedIndex == 2)
                {
                    siticoneDataGridView2.Rows.Clear();
                    Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.zamanx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox7.SelectedIndex == 3)
                {
                    siticoneDataGridView2.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.kayıtdeğerlendirme).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox7.SelectedIndex == 4)
                {
                    siticoneDataGridView2.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.kayıtdeğerlendirme).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox7.SelectedIndex == 5)
                {
                    siticoneDataGridView2.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.toplamatıkx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox7.SelectedIndex == 6)
                {
                    siticoneDataGridView2.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.toplamatıkx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox7.SelectedIndex == 7)
                {
                    siticoneDataGridView2.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.geridönüştürülenatığıntoplamatığaoranıx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox7.SelectedIndex == 8)
                {
                    siticoneDataGridView2.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.geridönüştürülenatığıntoplamatığaoranıx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox7.SelectedIndex == 9)
                {
                    siticoneDataGridView2.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.toplamatıkoranx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox7.SelectedIndex == 10)
                {
                    siticoneDataGridView2.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.toplamatıkoranx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox7.SelectedIndex == 11)
                {
                    siticoneDataGridView2.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.kayıtbaşlıkx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
            }
        }

        private void siticoneComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (siticoneComboBox8.SelectedIndex == 0)
            {
                siticoneTabControl4.SelectedTab = tabPage23;
            }
            if (siticoneComboBox8.SelectedIndex == 1)
            {
                siticoneTabControl4.SelectedTab = tabPage24;
            }
            if (siticoneComboBox8.SelectedIndex == 2)
            {
                siticoneTabControl4.SelectedTab = tabPage25;
            }
            if (siticoneComboBox8.SelectedIndex == 3)
            {
                siticoneTabControl4.SelectedTab = tabPage27;
            }
            if (siticoneComboBox8.SelectedIndex == 4)
            {
                siticoneTabControl4.SelectedTab = tabPage28;
            }
            if (siticoneComboBox8.SelectedIndex == 5)
            {
                siticoneTabControl4.SelectedTab = tabPage29;
            }
        }

        private void siticoneButton10_Click(object sender, EventArgs e)
        {
            if (eklemeler == "Boş")
            {
                MessageBox.Show("Hiçbir kullanıcı verisi bulunamadı lütfen önce veri ekleyin");
            }
            else
            {
                siticoneTabControl2.SelectedTab = tabPage22;
                siticoneTabControl4.SelectedTab = tabPage26;
                List<kayıtsınıfı> Data2 = Veridönüştürü( );
                siticoneDataGridView2.Rows.Clear();
                foreach (var a in Data2)
                {


                    siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
            }

        }
        void griddoldur()
        {
            if (eklemeler == "Boş")
            {
                siticoneTabControl2.SelectedTab = tabPage7;
            }
            else
            {
                List<kayıtsınıfı> Data = Veridönüştürü( );
                siticoneDataGridView2.Rows.Clear();
                foreach (var a in Data)
                {


                    siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
            }


        }
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand komut;
        void KayıtSil(string numara)
        {
            List<kayıtsınıfı> Data = Veridönüştürü( );

            foreach (var a in Data)
            {
                if (a.kayıtbaşlıkx == numara)
                {
                    Data.Remove(a);

                    eklemeler = Newtonsoft.Json.JsonConvert.SerializeObject(Data);

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
                    KayıtEkleDatabase(EPosta, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");




                    break;
                }
                else

                {

                }




            }
        }
        private void siticoneButton74_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in siticoneDataGridView2.SelectedRows)  //Seçili Satırları Silme
            {
                string numara = Convert.ToString(drow.Cells[0].Value);
                KayıtSil(numara);
            }
            griddoldur();
        }

        private void siticonePictureBox36_Click(object sender, EventArgs e)
        {

        }

        private void siticoneImageButton9_Click(object sender, EventArgs e)
        {
            List<kayıtsınıfı> Data = Veridönüştürü( );
            Form8 mö = new Form8(eklemeler, EPosta);
            mö.ShowDialog();
            KayıtEkleDatabase(EPosta, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
            if (eklemeler == "Boş")
            {
                siticoneTabControl2.SelectedTab = tabPage7;
                MessageBox.Show("Hiçbir veriniz bulunmamaktadır lütfen veri ekleyin", "Bal Nature Databae Service");
            }
            else
            {
                List<kayıtsınıfı> Data2 = Veridönüştürü( );
                siticoneDataGridView2.Rows.Clear();
                foreach (var a in Data2)
                {


                    siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
            }
        }

        private void siticoneImageButton10_Click(object sender, EventArgs e)
        {
            if (eklemeler == "Boş")
            {
                siticoneTabControl2.SelectedTab = tabPage7;
                MessageBox.Show("Hiçbir veriniz bulunmamaktadır lütfen veri ekleyin", "Bal Nature Databae Service");
            }
            else
            {
                List<kayıtsınıfı> Data2 = Veridönüştürü( );
                siticoneDataGridView2.Rows.Clear();
                foreach (var a in Data2)
                {


                    siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
            }
        }

        private void siticoneImageButton2_Click(object sender, EventArgs e)
        {
            if (eklemeler == "Boş")
            {
                siticoneTabControl2.SelectedTab = tabPage7;
                MessageBox.Show("Hiçbir veriniz bulunmamaktadır lütfen veri ekleyin", "Bal Nature Databae Service");
            }
            else
            {
                siticoneTabControl2.SelectedTab = tabPage30; siticoneTabControl5.SelectedTab = tabPage34;
                List<kayıtsınıfı> Data = Veridönüştürü( );
                siticoneTabControl5.SelectedTab = tabPage34;
                foreach (var a in Data)
                {

                    siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
                siticoneComboBox11.Enabled = false;

            }
        }

        private void siticoneButton12_Click(object sender, EventArgs e)
        {
            if (eklemeler == "Boş")
            {
                siticoneTabControl2.SelectedTab = tabPage7;
                MessageBox.Show("Hiçbir veriniz bulunmamaktadır lütfen veri ekleyin", "Bal Nature Databae Service");
            }
            else
            {
                siticoneTabControl2.SelectedTab = tabPage30; siticoneTabControl5.SelectedTab = tabPage34;
                List<kayıtsınıfı> Data2 = Veridönüştürü( );
                siticoneDataGridView3.Rows.Clear();
                foreach (var a in Data2)
                {


                    siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
            }
        }

        private void siticoneComboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            siticoneComboBox11.SelectedIndex = 0;
            siticoneComboBox11.SelectedIndex = 0;
            siticoneComboBox10.SelectedIndex = 0;
            siticoneDataGridView3.Rows.Clear();
            radCardView2.Items.Clear();
            List<kayıtsınıfı> Data = Veridönüştürü( );

            if (siticoneComboBox12.SelectedIndex == 0)
            {
                foreach (var a in Data)
                {

                    this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);




                }
                siticoneTabControl5.SelectedTab = tabPage35;
                siticoneComboBox11.Visible = true;
                siticoneComboBox11.Enabled = true;
                label131.Visible = true;
                siticoneToggleSwitch8.Visible = true;

            }
            if (siticoneComboBox12.SelectedIndex == 1)
            {


                siticoneTabControl5.SelectedTab = tabPage34;
                foreach (var a in Data)
                {

                    siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
                siticoneComboBox11.Enabled = false;
            }
            if (siticoneComboBox11.SelectedIndex == 2)
            {
                siticoneTabControl3.SelectedTab = tabPage33;
                siticoneComboBox11.Visible = true;
                siticoneComboBox10.Location = new Point(511, 6);
            }
            if (siticoneComboBox12.SelectedIndex == 3)
            {
                siticoneTabControl3.SelectedTab = tabPage32;
                siticoneComboBox11.Visible = true;
                siticoneComboBox10.Location = new Point(511, 6);
            }
            if (siticoneComboBox12.SelectedIndex == 4)
            {
                siticoneTabControl3.SelectedTab = tabPage31;
                siticoneComboBox11.Visible = true;
                siticoneComboBox10.Location = new Point(511, 6);
            }
        }

        private void siticoneToggleSwitch8_CheckedChanged(object sender, EventArgs e)
        {
            kontrol2();
        }

        private void siticoneComboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (siticoneComboBox12.SelectedIndex == 0)
            {


                radCardView2.Groups.Clear();
                radCardView2.Items.Clear();
                if (siticoneComboBox11.SelectedIndex == 1)
                {
                    this.radCardView2.EnableGrouping = true;
                    this.radCardView2.ShowGroups = true;
                    this.radCardView2.EnableCustomGrouping = true;
                    kontrol2();
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    siticoneDataGridView2.DataSource = Data;
                    int item = 0;
                    foreach (var a in Data)
                    {
                        item++;
                        this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        if (a.zamanx.Month == 1)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                        }

                        if (a.zamanx.Month == 2)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                        }
                        if (a.zamanx.Month == 3)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                        }
                        if (a.zamanx.Month == 4)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                        }
                        if (a.zamanx.Month == 5)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                        }
                        if (a.zamanx.Month == 6)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                        }
                        if (a.zamanx.Month == 7)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                        }
                        if (a.zamanx.Month == 8)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                        }
                        if (a.zamanx.Month == 9)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                        }
                        if (a.zamanx.Month == 10)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                        }
                        if (a.zamanx.Month == 11)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                        }
                        if (a.zamanx.Month == 12)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                        }
                    }



                }
                else if (siticoneComboBox11.SelectedIndex == 0)
                {


                    radCardView2.GroupDescriptors.Clear();
                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    siticoneDataGridView2.DataSource = Data;
                    radTaskbarButton1.Flash(123456, 6);
                    foreach (var a in Data)
                    {
                        this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                    }
                }
                else if (siticoneComboBox11.SelectedIndex == 2)
                {


                    radCardView2.GroupDescriptors.Clear();
                    this.radCardView2.EnableGrouping = true;
                    this.radCardView2.ShowGroups = true;
                    this.radCardView2.EnableCustomGrouping = true;
                    kontrol2();
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    dataGridView1.DataSource = Data; siticoneDataGridView2.DataSource = Data;
                    int item = 0;
                    radTaskbarButton1.Flash(123456, 6);
                    foreach (var a in Data)
                    {
                        item++;
                        this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        if (a.kayıtdeğerlendirme > 79.9)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                        }
                        else if (a.kayıtdeğerlendirme > 59.9)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                        }
                        else if (a.kayıtdeğerlendirme > 39.9)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                        }
                        else if (a.kayıtdeğerlendirme > 19.9)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                        }
                        else
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                        }

                    }

                }
                else if (siticoneComboBox11.SelectedIndex == 3)
                {


                    radCardView2.GroupDescriptors.Clear();
                    this.radCardView2.EnableGrouping = true;
                    this.radCardView2.ShowGroups = true;
                    this.radCardView2.EnableCustomGrouping = true;
                    kontrol2();
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    dataGridView1.DataSource = Data; siticoneDataGridView2.DataSource = Data;
                    int item = 0;
                    radTaskbarButton1.Flash(123456, 6);
                    foreach (var a in Data)
                    {
                        item++;
                        this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                        if (a.toplamatıkoranx > 100)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                        }

                        else if (a.toplamatıkoranx > 50)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                        }
                        else
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                        }

                    }
                }
                else if (siticoneComboBox11.SelectedIndex == 4)
                {


                    radCardView2.GroupDescriptors.Clear();
                    this.radCardView2.EnableGrouping = true;
                    this.radCardView2.ShowGroups = true;
                    this.radCardView2.EnableCustomGrouping = true;
                    kontrol2();
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                    this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                    List<kayıtsınıfı> Data = Veridönüştürü( );
                    dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                    int item = 0;
                    radTaskbarButton1.Flash(123456, 6);
                    foreach (var a in Data)
                    {
                        item++;
                        this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                        }

                        else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                        }
                        else
                        {
                            this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                        }

                    }
                }
                else
                {


                }
            }
        }

        private void siticoneImageButton13_Click(object sender, EventArgs e)
        {
            if (eklemeler == "Boş")
            {
                siticoneTabControl2.SelectedTab = tabPage7;
                MessageBox.Show("Hiçbir veriniz bulunmamaktadır lütfen veri ekleyin", "Bal Nature Databae Service");
            }
            else
            {
                List<kayıtsınıfı> Data2 = Veridönüştürü( );
                siticoneDataGridView3.Rows.Clear();
                foreach (var a in Data2)
                {


                    siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
            }
        }

        private void siticoneComboBox10_SelectedIndexChanged(object sender, EventArgs e)//sıralama
        {
            if (siticoneComboBox12.SelectedIndex == 0)
            {


                this.radCardView2.SortDescriptors.Clear();
                radCardView2.Groups.Clear();
                radCardView2.Items.Clear();
                if (siticoneComboBox10.SelectedIndex == 0)
                {
                    this.radCardView2.SortDescriptors.Clear();
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        this.radCardView2.CardViewElement.ViewElement.Orientation = Orientation.Horizontal;
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }

                }
                if (siticoneComboBox10.SelectedIndex == 1)
                {

                    this.radCardView2.SortDescriptors.Clear();
                    this.radCardView2.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 25", ListSortDirection.Ascending);
                    this.radCardView2.SortDescriptors.Add(sortDescriptor);
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }

                }
                if (siticoneComboBox10.SelectedIndex == 2)
                {

                    this.radCardView2.SortDescriptors.Clear();
                    this.radCardView2.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 25", ListSortDirection.Descending);
                    this.radCardView2.SortDescriptors.Add(sortDescriptor);
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 3)
                {

                    this.radCardView2.SortDescriptors.Clear();
                    this.radCardView2.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 24", ListSortDirection.Ascending);
                    this.radCardView2.SortDescriptors.Add(sortDescriptor);
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 4)
                {

                    this.radCardView2.SortDescriptors.Clear();
                    this.radCardView2.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 24", ListSortDirection.Descending);
                    this.radCardView2.SortDescriptors.Add(sortDescriptor);
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                }

                if (siticoneComboBox10.SelectedIndex == 5)
                {

                    this.radCardView2.SortDescriptors.Clear();
                    this.radCardView2.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 4", ListSortDirection.Ascending);
                    this.radCardView2.SortDescriptors.Add(sortDescriptor);
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }

                }
                if (siticoneComboBox10.SelectedIndex == 6)
                {

                    this.radCardView2.SortDescriptors.Clear();
                    this.radCardView2.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 4", ListSortDirection.Descending);
                    this.radCardView2.SortDescriptors.Add(sortDescriptor);
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 7)
                {

                    this.radCardView2.SortDescriptors.Clear();
                    this.radCardView2.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column15", ListSortDirection.Ascending);
                    this.radCardView2.SortDescriptors.Add(sortDescriptor);
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 8)
                {

                    this.radCardView2.SortDescriptors.Clear();
                    this.radCardView2.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 15", ListSortDirection.Descending);
                    this.radCardView2.SortDescriptors.Add(sortDescriptor);
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 9)
                {

                    this.radCardView2.SortDescriptors.Clear();
                    this.radCardView2.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 26", ListSortDirection.Descending);
                    this.radCardView2.SortDescriptors.Add(sortDescriptor);
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 10)
                {

                    this.radCardView2.SortDescriptors.Clear();
                    this.radCardView2.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 26", ListSortDirection.Ascending);
                    this.radCardView2.SortDescriptors.Add(sortDescriptor);
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 11)
                {

                    this.radCardView2.SortDescriptors.Clear();
                    this.radCardView2.EnableSorting = true;
                    SortDescriptor sortDescriptor = new SortDescriptor("Column 0", ListSortDirection.Descending);
                    this.radCardView2.SortDescriptors.Add(sortDescriptor);
                    radCardView2.Groups.Clear();
                    radCardView2.Items.Clear();
                    if (siticoneComboBox11.SelectedIndex == 1)
                    {
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ocak"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Şubat"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mart"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Nisan"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Mayıs"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Haziran"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Temmuz"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ağustos"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Eylül"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Ekim"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Kasım"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Aralık"));




                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.zamanx.Month == 1)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            if (a.zamanx.Month == 2)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            if (a.zamanx.Month == 3)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            if (a.zamanx.Month == 4)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            if (a.zamanx.Month == 5)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            if (a.zamanx.Month == 6)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[5];
                            }
                            if (a.zamanx.Month == 7)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[6];
                            }
                            if (a.zamanx.Month == 8)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[7];
                            }
                            if (a.zamanx.Month == 9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[8];
                            }
                            if (a.zamanx.Month == 10)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[9];
                            }
                            if (a.zamanx.Month == 11)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[10];
                            }
                            if (a.zamanx.Month == 12)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[11];
                            }
                        }



                    }
                    else if (siticoneComboBox11.SelectedIndex == 0)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 2)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("1 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("2 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("3 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("4 Yıldız"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("5 Yıldız"));
                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.kayıtdeğerlendirme > 79.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[4];
                            }
                            else if (a.kayıtdeğerlendirme > 59.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[3];
                            }
                            else if (a.kayıtdeğerlendirme > 39.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }
                            else if (a.kayıtdeğerlendirme > 19.9)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                        }

                    }
                    else if (siticoneComboBox11.SelectedIndex == 3)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek Atık"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta Atık"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük Atık"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.toplamatıkoranx > 100)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.toplamatıkoranx > 50)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                    else if (siticoneComboBox11.SelectedIndex == 4)
                    {


                        radCardView2.GroupDescriptors.Clear();
                        this.radCardView2.EnableGrouping = true;
                        this.radCardView2.ShowGroups = true;
                        this.radCardView2.EnableCustomGrouping = true;
                        kontrol2();
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Yüksek GD"));

                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Orta GD"));
                        this.radCardView2.Groups.Add(new ListViewDataItemGroup("Düşük GD"));

                        List<kayıtsınıfı> Data = Veridönüştürü( );
                        dataGridView1.DataSource = Data; siticoneDataGridView3.DataSource = Data;
                        int item = 0;
                        radTaskbarButton1.Flash(123456, 6);
                        foreach (var a in Data)
                        {
                            item++;
                            this.radCardView2.Items.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx, a.gdcam + a.gdkağıt + a.gdmetal + a.gdplastik);
                            if (a.geridönüştürülenatığıntoplamatığaoranıx > 75)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[0];
                            }

                            else if (a.geridönüştürülenatığıntoplamatığaoranıx > 40)
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[1];
                            }
                            else
                            {
                                this.radCardView2.Items[item - 1].Group = this.radCardView2.Groups[2];
                            }

                        }
                    }
                }
            }
            if (siticoneComboBox12.SelectedIndex == 1)
            {
                List<kayıtsınıfı> Data = Veridönüştürü( );
                siticoneDataGridView3.DataSource = null;
                if (siticoneComboBox10.SelectedIndex == 0)
                {
                    siticoneDataGridView3.Rows.Clear();
                    foreach (var a in Data)
                    {

                        this.siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }




                }
                if (siticoneComboBox10.SelectedIndex == 1)
                {
                    siticoneDataGridView3.Rows.Clear();

                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.zamanx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 2)
                {
                    siticoneDataGridView3.Rows.Clear();
                    Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.zamanx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 3)
                {
                    siticoneDataGridView3.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.kayıtdeğerlendirme).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 4)
                {
                    siticoneDataGridView3.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.kayıtdeğerlendirme).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 5)
                {
                    siticoneDataGridView3.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.toplamatıkx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 6)
                {
                    siticoneDataGridView3.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.toplamatıkx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 7)
                {
                    siticoneDataGridView3.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.geridönüştürülenatığıntoplamatığaoranıx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 8)
                {
                    siticoneDataGridView3.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.geridönüştürülenatığıntoplamatığaoranıx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 9)
                {
                    siticoneDataGridView3.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.toplamatıkoranx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 10)
                {
                    siticoneDataGridView3.Rows.Clear();
                    ; Data = Data.OrderByDescending(kayıtsınıfı => kayıtsınıfı.toplamatıkoranx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
                if (siticoneComboBox10.SelectedIndex == 11)
                {
                    siticoneDataGridView3.Rows.Clear();
                    ; Data = Data.OrderBy(kayıtsınıfı => kayıtsınıfı.kayıtbaşlıkx).ToList();

                    foreach (var a in Data)
                    {

                        siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);
                    }
                }
            }
        }

        private void siticoneImageButton12_Click(object sender, EventArgs e)
        {
            List<kayıtsınıfı> Data = Veridönüştürü( );
            Form9 mö = new Form9(eklemeler, EPosta);
            mö.ShowDialog();
            KayıtEkleDatabase(EPosta, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
            if (eklemeler == "Boş")
            {
                siticoneTabControl2.SelectedTab = tabPage7;
                MessageBox.Show("Hiçbir veriniz bulunmamaktadır lütfen veri ekleyin", "Bal Nature Databae Service");
            }
            else
            {
                List<kayıtsınıfı> Data2 = Veridönüştürü( );
                siticoneDataGridView3.Rows.Clear();
                foreach (var a in Data2)
                {


                    siticoneDataGridView3.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
            }
        }

        private void siticonePictureBox142_Click(object sender, EventArgs e)
        {

        }
        List<kayıtsınıfı> emp = new List<kayıtsınıfı>();
        private void siticoneButton75_Click(object sender, EventArgs e)
        {
            var Result = siticoneDataGridView3.Rows.OfType<DataGridViewRow>().Select(
            r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();
            foreach (var ri in Result)
            {
                if (ri[0] == null)
                {
                    break;
                }
                else if (ri[0] == null || ri[1] == null || ri[2] == null || ri[3] == null || ri[4] == null || ri[5] == null || ri[6] == null || ri[7] == null || ri[8] == null || ri[9] == null || ri[10] == null || ri[11] == null || ri[12] == null || ri[13] == null || ri[14] == null || ri[15] == null || ri[16] == null || ri[17] == null || ri[18] == null || ri[19] == null || ri[20] == null || ri[21] == null || ri[22] == null || ri[23] == null || ri[24] == null || ri[25] == null)
                {
                    MessageBox.Show("Kaydınız Yaoılırken bir sorunla karşılaşıldı.Lütfen kaydınızı yaparken tüm alanları doldurun.Not:Bazı Veriler kaydedilmemiş olabilir", "BalNature Data Servisi");
                    break;
                }
                var t = new List<kayıtsınıfı>();
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
                kıy.zamanx = Convert.ToDateTime(ri[25]);

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
            KayıtEkleDatabase(EPosta, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
            if (eklemeler == "Boş")
            {
                siticoneTabControl2.SelectedTab = tabPage7;
                MessageBox.Show("Hiçbir veriniz bulunmamaktadır lütfen veri ekleyin", "Bal Nature Databae Service");
            }
            else
            {
                List<kayıtsınıfı> Data2 = Veridönüştürü( );
                siticoneDataGridView2.Rows.Clear();
                foreach (var a in Data2)
                {


                    siticoneDataGridView2.Rows.Add(a.kayıtbaşlıkx, a.kayıtaçıklamax, a.kayıttürx, a.kayıtalanıx, a.toplamatıkx, a.metalatıkx, a.camatıkx, a.kağıtatıkx, a.plastikatıkx, a.toplamatıkoranx, a.evselatıkorax, a.metalatıkoranx, a.kağıtatıkoranx, a.camatıkoranx, a.plastikatıkoranx, a.geridönüştürülenatığıntoplamatığaoranıx, a.gdmetal, a.gdcam, a.gdkağıt, a.gdplastik, a.gdmetaloran, a.gdcamoran, a.gdkağıtoran, a.gdplastikoran, a.kayıtdeğerlendirme, a.zamanx);



                }
            }

        }

        private void siticoneDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton19_Click(object sender, EventArgs e)
        {
            siticoneTabControl6.SelectedTab = tabPage45;
        }

        private void siticoneButton20_Click(object sender, EventArgs e)
        {
            siticoneTabControl6.SelectedTab = tabPage46;
        }

        private void siticoneButton21_Click(object sender, EventArgs e)
        {
            siticoneTabControl6.SelectedTab = tabPage47;
        }

        private void siticoneButton18_Click(object sender, EventArgs e)
        {
            siticoneTabControl6.SelectedTab = tabPage44;
        }

        private void siticoneButton14_Click(object sender, EventArgs e)
        {
            siticoneTabControl6.SelectedTab = tabPage37;
        }

        private void tabNavigationPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticonePictureBox164_Click(object sender, EventArgs e)
        {

        }

        private void label178_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneTabControl7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void siticonePictureBox168_Click(object sender, EventArgs e)
        {

        }
        List<kayıtsınıfı> Veridönüştürü( ) {

            List<kayıtsınıfı> kayy=new List<kayıtsınıfı>();
            foreach(veriaktarimi vv in dataa.VeriListesi)
            {
                kayıtsınıfı kl=new kayıtsınıfı();
                kl.camatıkx = vv.Cama;
                kl.metalatıkx = vv.Metala;
                kl.kağıtatıkx = vv.Kağıta;
                kl.camatıkx = vv.Cama;
                kl.plastikatıkx = vv.Plastika;
                kl.gdcam = vv.Camg;
                kl.gdkağıt = vv.Kağıtg;
                kl.gdplastik = vv.Platikg;
                long ticks = vv.Tarih; // Örnek bir long tarih değeri

                // Long tarih değerini DateTime'e çevirin
                DateTime dateTime = new DateTime(ticks);

                // DateTime'i bir stringe dönüştürün

                kl.zamanx = dateTime;
                kl.gdmetal = vv.Metalg;
                kl.kayıtbaşlıkx = vv.Ad;
                kl.kayıtaçıklamax = vv.Açiklama;
                kl.kayıttürx =  "1";
                kl.kayıtalanıx = vv.Faliyetalanı;
                kl.kayıtdeğerlendirme = vv.Kaydıdegerlendir;
                //   kl.evselatıkorax=vv.Toplamatık-(vv.Metala+vv.Cama+vv.Kağıta+vv.Plastika);
                kl.toplamatıkx = vv.Toplamatık;
                double aj1, aj2, aj3, aj4, aj5, aj6, aj7, aj8, aj9, aj10, aj11, aj12;
                int uıo = vv.Kağıtg + vv.Metalg + vv.Camg + vv.Platikg;
                if (uıo != 0)
                {
                    int opp = (int)vv.Toplamatık - uıo;
                    double aa1 = opp / vv.Toplamatık * 100;
                     aj1 = Math.Round(aa1, 0);
                }
                else
                {
                    aj1 = 0;
                }
                 
                 
                 
                int uıo2 = (int)vv.Toplamatık ;
                if (uıo2 != 0) { 
                    double aa2 = uıo2 / vv.Toplamatık * 100;
                 aj2 = Math.Round(aa2, 0);
                }
                else
                {
                    aj2 = 0;
                }
                int uıo3 =   vv.Metala  ;
                if (uıo3 != 0) { 
                    double aa3 = uıo3 / vv.Toplamatık * 100;
                 aj3 = Math.Round(aa3, 0);
                }
                else
                {
                    aj3 = 0;
                }
                int uıo4 = vv.Cama;
                if (uıo4 != 0) { 
                    double aa4 = uıo4 / vv.Toplamatık * 100;
                 aj4 = Math.Round(aa4, 0);

                }
                else
                {
                    aj4 = 0;
                }
                int uıo5 = vv.Kağıta;
                if (uıo5 != 0) { 
                    double aa5 = uıo5 / vv.Toplamatık * 100;
                 aj5 = Math.Round(aa5, 0);
                }
                else
                {
                    aj5 = 0;
                }
                int uıo6 = vv.Plastika;
                if (uıo6 != 0) { 
                    double aa6 = uıo6 / vv.Toplamatık * 100;
                 aj6 = Math.Round(aa6, 0);
                }
                else
                {
                    aj6 = 0;
                }

                int uıo7 = vv.Kağıta + vv.Metala + vv.Cama + vv.Plastika;
                if (uıo7 != 0) { 
                    int opp7 = (int)vv.Toplamatık - uıo7;
                double aa7 = opp7 / vv.Toplamatık * 100;
                 aj7 = Math.Round(aa7, 0);
                }
                else
                {
                    aj7 = 0;
                }



                int uıo8 = vv.Metalg; 
                if (uıo8 != 0) { 
                    double aa8 = uıo8 / vv.Toplamatık * 100;
                     aj8 = Math.Round(aa8, 0);
                }
                else
                {
                    aj8 = 0;
                }

                int uıo9 = vv.Camg;
                if (uıo9 != 0) { 
                    double aa9 = uıo9/ vv.Toplamatık * 100;
                 aj9 = Math.Round(aa9, 0);
                }
                else
                {
                    aj9 = 0;
                }

                int uıo10 = vv.Platikg;
                if (uıo10 != 0) { 
                    double aa10 = uıo10 / vv.Toplamatık * 100;
                 aj10 = Math.Round(aa10, 0);
                }
                else
                {
                    aj10 = 0;
                }

                int uıo11 = vv.Kağıtg;
                if (uıo11 != 0) { 
                    double aa11 = uıo11 / vv.Toplamatık * 100;
                 aj11 = Math.Round(aa11, 0);
                }
                else
                {
                    aj11 = 0;
                }
                kl.toplamatıkoranx = (int)aj2;

                kl.evselatıkorax = (int)aj1;
                kl.metalatıkoranx = (int)aj3;
                kl.camatıkoranx = (int)aj4;
                kl.kağıtatıkoranx = (int)aj5;
                kl.plastikatıkoranx = (int)aj6;
                kl.geridönüştürülenatığıntoplamatığaoranıx = (int)aj7;
                kl.gdmetaloran = (int)aj8;
                kl.gdcamoran = (int)aj9;
                kl.gdplastikoran = (int)aj10;
                kl.gdkağıtoran = (int)aj11;
                kayy.Add(kl);

            }
            return kayy;

        }

        private void siticoneComboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {

            ay1 = 0;
            ay2 = 0;
            ay3 = 0;
            ay4 = 0;
            ay5 = 0;
            ay6 = 0;
            ay7 = 0;
            ay8 = 0;
            ay9 = 0;
            ay10 = 0;
            ay11 = 0;
            ay12 = 0;
            chartControl9.Series[0].Points.Clear();
            List<kayıtsınıfı> Data3 = Veridönüştürü();
            DevExpress.XtraCharts.Series xxxyx = chartControl9.Series[0];
            chartControl9.Series.Clear();
            foreach (kayıtsınıfı itepom in Data3)


            {
                if (siticoneComboBox15.SelectedIndex == 0)
                {


                    if (itepom.zamanx.Year == 2023)
                    {


                        if (itepom.zamanx.Month == 1)
                        {
                            ay1 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 2)
                        {
                            ay2 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 3)
                        {
                            ay3 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 4)
                        {
                            ay4 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 5)
                        {
                            ay5 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 6)
                        {
                            ay6 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 7)
                        {
                            ay7 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 8)
                        {
                            ay8 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 9)
                        {
                            ay9 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 10)
                        {
                            ay10 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 11)
                        {
                            ay11 += itepom.toplamatıkx;

                        }
                        else if (itepom.zamanx.Month == 12)
                        {
                            ay12 += itepom.toplamatıkx;

                        }
                    }
                }
                if (siticoneComboBox15.SelectedIndex == 1)
                {


                    if (itepom.zamanx.Year == 2022)
                    {


                        if (itepom.zamanx.Month == 1)
                        {
                            ay1 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 2)
                        {
                            ay2 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 3)
                        {
                            ay3 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 4)
                        {
                            ay4 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 5)
                        {
                            ay5 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 6)
                        {
                            ay6 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 7)
                        {
                            ay7 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 8)
                        {
                            ay8 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 9)
                        {
                            ay9 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 10)
                        {
                            ay10 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 11)
                        {
                            ay11 += itepom.toplamatıkx;

                        }
                        else if (itepom.zamanx.Month == 12)
                        {
                            ay12 += itepom.toplamatıkx;

                        }
                    }
                }
                if (siticoneComboBox15.SelectedIndex == 2)
                {


                    if (itepom.zamanx.Year == 2021)
                    {


                        if (itepom.zamanx.Month == 1)
                        {
                            ay1 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 2)
                        {
                            ay2 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 3)
                        {
                            ay3 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 4)
                        {
                            ay4 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 5)
                        {
                            ay5 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 6)
                        {
                            ay6 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 7)
                        {
                            ay7 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 8)
                        {
                            ay8 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 9)
                        {
                            ay9 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 10)
                        {
                            ay10 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 11)
                        {
                            ay11 += itepom.toplamatıkx;

                        }
                        else if (itepom.zamanx.Month == 12)
                        {
                            ay12 += itepom.toplamatıkx;

                        }
                    }
                }
                if (siticoneComboBox15.SelectedIndex == 3)
                {


                    if (itepom.zamanx.Year == 2020)
                    {


                        if (itepom.zamanx.Month == 1)
                        {
                            ay1 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 2)
                        {
                            ay2 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 3)
                        {
                            ay3 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 4)
                        {
                            ay4 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 5)
                        {
                            ay5 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 6)
                        {
                            ay6 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 7)
                        {
                            ay7 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 8)
                        {
                            ay8 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 9)
                        {
                            ay9 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 10)
                        {
                            ay10 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 11)
                        {
                            ay11 += itepom.toplamatıkx;

                        }
                        else if (itepom.zamanx.Month == 12)
                        {
                            ay12 += itepom.toplamatıkx;

                        }
                    }
                }
                if (siticoneComboBox15.SelectedIndex == 4)
                {


                    if (itepom.zamanx.Year == 2019)
                    {


                        if (itepom.zamanx.Month == 1)
                        {
                            ay1 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 2)
                        {
                            ay2 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 3)
                        {
                            ay3 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 4)
                        {
                            ay4 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 5)
                        {
                            ay5 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 6)
                        {
                            ay6 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 7)
                        {
                            ay7 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 8)
                        {
                            ay8 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 9)
                        {
                            ay9 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 10)
                        {
                            ay10 += itepom.toplamatıkx;
                        }
                        else if (itepom.zamanx.Month == 11)
                        {
                            ay11 += itepom.toplamatıkx;

                        }
                        else if (itepom.zamanx.Month == 12)
                        {
                            ay12 += itepom.toplamatıkx;

                        }
                    }
                }
            }
            DevExpress.XtraCharts.SeriesPoint seriesPointxxxy1 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay1)))});
            xxxyx.Points.Add(seriesPointxxxy1);
            seriesPointxxxy1.ColorSerializable = "#820263";

            DevExpress.XtraCharts.SeriesPoint seriesPointxx1y2 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay2)))});
            xxxyx.Points.Add(seriesPointxx1y2);
            seriesPointxx1y2.ColorSerializable = "#e53d00";

            DevExpress.XtraCharts.SeriesPoint seriesPointxx2y3 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay3)))});
            xxxyx.Points.Add(seriesPointxx2y3);
            seriesPointxx2y3.ColorSerializable = "#07a0c3";

            DevExpress.XtraCharts.SeriesPoint seriesPointxx3y4 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay4)))});
            xxxyx.Points.Add(seriesPointxx3y4);
            seriesPointxx3y4.ColorSerializable = " #4abc95";
            DevExpress.XtraCharts.SeriesPoint seriesPointxxxy5 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay5)))});
            xxxyx.Points.Add(seriesPointxxxy5);
            seriesPointxxxy5.ColorSerializable = "#f05365";

            DevExpress.XtraCharts.SeriesPoint seriesPointxx1y6 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay6)))});
            xxxyx.Points.Add(seriesPointxx1y6);
            seriesPointxx1y6.ColorSerializable = "#d83e38";

            DevExpress.XtraCharts.SeriesPoint seriesPointxx2y7 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay7)))});
            xxxyx.Points.Add(seriesPointxx2y7);
            seriesPointxx2y7.ColorSerializable = "#fdea3e";

            DevExpress.XtraCharts.SeriesPoint seriesPointxx3y8 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay8)))});
            xxxyx.Points.Add(seriesPointxx3y8);
            seriesPointxx3y8.ColorSerializable = " #63bb35";
            DevExpress.XtraCharts.SeriesPoint seriesPointxxxy9 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay9)))});
            xxxyx.Points.Add(seriesPointxxxy9);
            seriesPointxxxy9.ColorSerializable = "#233d6b";

            DevExpress.XtraCharts.SeriesPoint seriesPointxx1y10 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay10)))});
            xxxyx.Points.Add(seriesPointxx1y10);
            seriesPointxx1y10.ColorSerializable = "#edb68c";

            DevExpress.XtraCharts.SeriesPoint seriesPointxx2y11 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay11)))});
            xxxyx.Points.Add(seriesPointxx2y11);
            seriesPointxx2y11.ColorSerializable = "#928d93";

            DevExpress.XtraCharts.SeriesPoint seriesPointxx3y12 = new DevExpress.XtraCharts.SeriesPoint($"0", new object[] {
             ((object)((ay12)))});
            xxxyx.Points.Add(seriesPointxx3y12);
            seriesPointxx3y12.ColorSerializable = " #8a59cd";

            chartControl9.Series.Add(xxxyx);


        }

        private void siticoneButton93_Click(object sender, EventArgs e)
        {
            Form15 fdg = new Form15(eklemeler);
            fdg.Show();
        }

        private void siticoneButton76_Click(object sender, EventArgs e)
        {
            siticoneTabControl7.SelectedTab = tabPage39;
        }

        private void siticoneButton78_Click(object sender, EventArgs e)
        {
            siticoneTabControl7.SelectedTab = tabPage39;
        }

        private void siticoneButton77_Click(object sender, EventArgs e)
        {
            siticoneTabControl7.SelectedTab = tabPage40;
        }

        private void tabPage36_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton15_Click(object sender, EventArgs e)
        {
            siticoneTabControl6.SelectedTab = tabPage36;
            siticoneTabControl7.SelectedTab = tabPage41;
        }

        private void siticoneButton95_Click(object sender, EventArgs e)
        {
            Form14 fdg = new Form14(eklemeler);
            fdg.Show();
        }

        private void siticoneButton96_Click(object sender, EventArgs e)
        {
            //Form10 fdg = new Form10("a");
            //fdg.Show();
        }

        private void siticoneButton97_Click(object sender, EventArgs e)
        {
            Form13 fdg = new Form13("a");
            fdg.Show();
        }

        private void siticoneButton98_Click(object sender, EventArgs e)
        {
            Form12 fdg = new Form12(eklemeler);
            fdg.Show();
        }

        private void siticoneButton16_Click(object sender, EventArgs e)
        {
            siticoneTabControl6.SelectedTab = tabPage36;
            siticoneTabControl7.SelectedTab = tabPage43;
        }

        private void radChat1_TimeSeparatorAdding(object sender, TimeSeparatorEventArgs e)
        {

        }

        private void radChat1_Click(object sender, EventArgs e)
        {

        }

        private void radChat1_ControlAdded(object sender, ControlEventArgs e)
        {

        }
        string şikayetmesaj;
        string şikayetmesajmetin;

        private void siticonePictureBox253_Click(object sender, EventArgs e)
        {
            siticonePictureBox252.Image = siticonePictureBox253.Image;
        }

        private void siticonePictureBox254_Click(object sender, EventArgs e)
        {
            siticonePictureBox252.Image = siticonePictureBox254.Image;
        }

        private void siticonePictureBox255_Click(object sender, EventArgs e)
        {
            siticonePictureBox252.Image = siticonePictureBox255.Image;
        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel28_Paint(object sender, PaintEventArgs e)
        {

        }
        int tıklıı = 0;
        private void panel28_Click(object sender, EventArgs e)
        {

        }

        private void panel29_Click(object sender, EventArgs e)
        {

        }

        private void panel28_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panel28_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panel29_MouseHover(object sender, EventArgs e)
        {

        }

        private void panel29_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panel29_MouseLeave(object sender, EventArgs e)
        {

        }

        private void label306_Click(object sender, EventArgs e)
        {
            siticoneTabControl9.SelectedTab = tabPage49; siticonePictureBox256.Visible = true; siticonePictureBox257.Visible = false;
            tıklıı = 0;
        }

        private void label307_Click(object sender, EventArgs e)
        {
            siticoneTabControl9.SelectedTab = tabPage50; siticonePictureBox256.Visible = false; siticonePictureBox257.Visible = true;
            tıklıı = 1;
        }

        private void label306_MouseEnter(object sender, EventArgs e)
        {
            if (tıklıı == 0)
            {

            }
            else
            {
                siticonePictureBox256.Visible = true; siticonePictureBox257.Visible = false;
            }

        }

        private void label306_MouseLeave(object sender, EventArgs e)
        {
            if (tıklıı == 0)
            {

            }
            else
            {
                siticonePictureBox256.Visible = false; siticonePictureBox257.Visible = true;

            }

        }

        private void label307_MouseEnter(object sender, EventArgs e)
        {
            if (tıklıı == 1)
            {

            }
            else
            {
                siticonePictureBox257.Visible = true; siticonePictureBox256.Visible = false;
            }
        }

        private void label307_MouseLeave(object sender, EventArgs e)
        {
            if (tıklıı == 1)
            {

            }
            else
            {
                siticonePictureBox257.Visible = false; siticonePictureBox256.Visible = true;
            }
        }

        private void siticoneButton111_Click(object sender, EventArgs e)
        {
            if (indirilenlerdemi == 1)
            {
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                flowLayoutPanel13.Visible = true;
                flowLayoutPanel14.Visible = true;
                indirilenlerdemi = 0;
            }
            panel27.Visible = false;
        }
        int siticoneButton112Visible = 0;
        private void siticoneProgressBar1_ValueChanged(object sender, EventArgs e)
        {


        }
        int indirilimi = 0;
        private void siticoneButton112_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:\\ProgramData\\SEAzer\\BALNature\\Bottle"))
            {
                indirilimi = 1;

            }
            else
            {
                indirilimi = 0;
            }
            panel27_Göster("Bottle and Adventures", "2023 SEAZER BalNature Çekirdek Ekip™  tarafından oluşturulan buı oyun bir geri dönüşüm malzemesinin maceralarını içerir.", BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_12_saat_15_32_14, BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_12_saat_15_32_21, BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_12_saat_15_32_25, BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_12_saat_15_32_30, "Bal Nature LLC.", "Bal Nature LLC.", "28.2", new DateTime(2023, 12, 19), "Platform", "Windows XP®+", "İntel Pentinum C1100", "512 MB", "MX 350 / Readon HD 3452", "x86 / x64", "Windows 10/11", "Ryzen 7 7100x/İntel i9 12400h", "8 GB", "RTX 4090 Tİ /Readon RX 5040", "x64", "www", "Bottle", indirilimi);

        }

        private void siticoneProgressBar2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void siticoneProgressBar6_ValueChanged(object sender, EventArgs e)
        {

        }
        void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            label367.Text = $"indiriliyor: %{e.ProgressPercentage}";
            siticoneProgressBar7.Value = e.ProgressPercentage;

            double sayi = (e.ProgressPercentage * e.TotalBytesToReceive) / 100;
            double sonuc = sayi / 1000000; // 435934 / 10000 = 43.5934

            double sayi2 = e.TotalBytesToReceive;
            double sonuc2 = sayi2 / 1000000; // 435934 / 10000 = 43.5934
            label369.Text = $" {sonuc.ToString("0.##")}MB / {sonuc2.ToString("0.##")}MB";

            if (e.ProgressPercentage == 100)
            {
                indiriliyor = 0;
                xxxc = 0;

                siticoneButton109.Text = "Oyna";
            }
        }

        void Completed(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Dosya indirme tamamlandı!");
            try
            {
                ZipFile.ExtractToDirectory(@"C:\ProgramData\SEAzer\BALNature\Dosya.zip", @"C:\ProgramData\SEAzer\BALNature");
                File.Delete(@"C:\ProgramData\SEAzer\BALNature\Dosya.zip");
            }
            catch (Exception)
            {
                File.Delete(@"C:\ProgramData\SEAzer\BALNature\Dosya.zip");

            }

            siticonePanel16.Visible = false;
            panelaçıksaindirme();
            siticoneButton109.Enabled = true;
            label368.Visible = true;

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void siticonePanel16_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }
        long downloadedBytes = 0; WebClient webClient = new WebClient();
        private void siticoneButton109_Click(object sender, EventArgs e)
        {
            if (inecekoyun == "Bottle")
            {
                if (Directory.Exists("C:\\ProgramData\\SEAzer\\BALNature\\Bottle"))
                {
                    Process.Start("C:\\ProgramData\\SEAzer\\BALNature\\Bottle\\Bottle.exe");

                }
                else
                {
                    indiriliyor = 1;
                    label368.Visible = false;
                    siticonePictureBox276.Image = BAL_Nature.Properties.Resources.WhatsApp_Görsel_2023_03_18_saat_00_20_36;
                    label362.Text = "Bottle and Adventures";
                    string indirilecek = "http://balnature2-001-site1.atempurl.com/jj.zip";
                    string klasor = @"C:\ProgramData\SEAzer\BALNature\";
                    string dosyaAdi = "Dosya.zip";
                    xxxc = 1;
                    siticonePanel16.Visible = true;
                    siticoneButton109.Text = "İndiriliyor...";
                    siticoneButton109.Enabled = false;

                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.DownloadFileAsync(new Uri(indirilecek), klasor + dosyaAdi);
                }



            }
            if (inecekoyun == "isik")
            {
                if (Directory.Exists("C:\\ProgramData\\SEAzer\\BALNature\\Isik"))
                {
                    Process.Start("C:\\ProgramData\\SEAzer\\BALNature\\Isik\\isik.exe");

                }
                else
                {
                    label368.Visible = false;
                    indiriliyor = 1;
                    siticonePictureBox276.Image = BAL_Nature.Properties.Resources.y;
                    xxxc = 1;
                    label362.Text = "Good Worker Boid";
                    string indirilecek = "http://balnature2-001-site1.atempurl.com/Isik.zip";
                    string klasor = @"C:\ProgramData\SEAzer\BALNature\";
                    string dosyaAdi = "Dosya.zip";
                    label368.Visible = false;
                    siticonePanel16.Visible = true;
                    siticoneButton109.Text = "İndiriliyor...";
                    siticoneButton109.Enabled = false;

                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.DownloadFileAsync(new Uri(indirilecek), klasor + dosyaAdi);
                }



            }


        }

        private void siticoneButton113_Click(object sender, EventArgs e)
        {
            siticonePanel18.Visible = false;
            bildirimmenüsüaçıkmı = false;
        }

        private void tabPage49_Click(object sender, EventArgs e)
        {

        }

        private void siticonePictureBox279_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton117_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:\\ProgramData\\SEAzer\\BALNature\\Isik"))
            {
                indirilimi = 1;

            }
            else
            {
                indirilimi = 0;
            }
            panel27_Göster("Good Worker Boid", "2023 SEAZER BalNature Çekirdek Ekip™  tarafından oluşturulan bu oyun bir doğa sever canlının dört bir tarafa dağılmış geri dönüşüm malzemelerini aramasını anlatmaktadır.", BAL_Nature.Properties.Resources.IMG_20230322_WA0004, BAL_Nature.Properties.Resources.
                    IMG_20230322_WA0007, BAL_Nature.Properties.Resources.IMG_20230322_WA0008, BAL_Nature.Properties.Resources.IMG_20230322_WA0009, "Bal Nature LLC.", "Bal Nature LLC.", "28.2", new DateTime(2023, 12, 19), "Platform", "Windows XP®+", "İntel Pentinum C1100", "512 MB", "MX 350 / Readon HD 3452", "x86 / x64", "Windows 10/11", "Ryzen 7 7100x/İntel i9 12400h", "8 GB", "RTX 4090 Tİ /Readon RX 5040", "x64", "www", "isik", indirilimi);
        }

        private void siticonePictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void siticoneProgressBar5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void siticoneProgressBar4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void siticoneProgressBar3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneCircleButton1_Click(object sender, EventArgs e)
        {
            webClient.CancelAsync();
            xxxc = 0;


        }

        private void siticoneCircleButton2_Click(object sender, EventArgs e)
        {
            webClient.CancelAsync();
            xxxc = 0;

        }

        private void siticonePanel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label301_Click(object sender, EventArgs e)
        {

        }

        private void chromiumWebBrowser2_DoubleClick(object sender, EventArgs e)
        {
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
                siticoneButton55.FillColor = Color.FromArgb(22, 26, 31);
            }
        }

        private void chromiumWebBrowser2_Click(object sender, EventArgs e)
        {
            if (bildirimmenüsüaçıkmı == true)
            {
                panel6.Visible = false;
                bildirimmenüsüaçıkmı = false;
            }
            if (Hesapaçıkmı == true)
            {
                timer1.Interval = 1;
                timer1.Start();
                siticoneImageButton1.Enabled = false;
                siticoneButton43.Visible = false;
                siticoneButton44.Visible = false;




                siticoneButton48.Visible = false;
                siticoneButton49.Visible = false;
                siticoneButton50.Visible = false;
            }
        }

        private void radChat1_SendMessage(object sender, SendMessageEventArgs e)
        {
            /*    listOverlay.ListView.Items.Add("Gelen Hata Mesajı");
                listOverlay.ListView.Items.Add("Çalışmayan Özellik");
                listOverlay.ListView.Items.Add("Eksik Yada Hatalı Veri");
                listOverlay.ListView.Items.Add("Hesap Hataları");
                listOverlay.ListView.Items.Add("İşleyiş Hataları");
                listOverlay.ListView.Items.Add("Diğer");*/
            ChatTextMessage aa = (ChatTextMessage)e.Message;
            string hqh = aa.Message.ToString();
            if (seçimyapıldımı == false)
            {
                if (sıracc == 0)
                {
                    this.radChat1.AddMessage(new ChatTextMessage("Lütfen bir değer seçiniz", author2, DateTime.Now));
                }

            }
            else
            {
                if (sıracc == 1)
                {

                    this.radChat1.AddMessage(new ChatTextMessage("Mesajınız Değerlendiriliyor...", author2, DateTime.Now));
                    if (hqh == "list")
                    {
                        ChatListOverlay listOverlay = new ChatListOverlay("List overlay");

                        listOverlay.ListView.Items.Add("Gelen Hata Mesajı");
                        listOverlay.ListView.Items.Add("Çalışmayan Özellik");
                        listOverlay.ListView.Items.Add("Eksik Yada Hatalı Veri");
                        listOverlay.ListView.Items.Add("Hesap Hataları");
                        listOverlay.ListView.Items.Add("İşleyiş Hataları");
                        listOverlay.ListView.Items.Add("Diğer");
                        bool showAsPopup = false;

                        ChatOverlayMessage overlayMessage = new ChatOverlayMessage(listOverlay, showAsPopup, author2, DateTime.Now);
                        this.radChat1.AddMessage(overlayMessage);

                    }
                    else if (hqh == "Çalışmayan Özellik")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'Çalışmayan özelliği' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "Çalışmayan Özellik";
                        sıracc = 2;
                    }

                    else if (hqh == "Eksik Yada Hatalı Veri")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'Eksik Yada Hatalı Veri' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "Eksik Yada Hatalı Veri"; sıracc = 2;
                    }
                    else if (hqh == "Hesap Hataları")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'Hesap Hataları' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "Hesap Hataları"; sıracc = 2;
                    }
                    else if (hqh == "Gelen Hata Mesajı")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'Gelen Hata Mesajı' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "Gelen Hata Mesajı"; sıracc = 2;
                    }
                    else if (hqh == "İşleyiş Hataları")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'İşleyiş Hataları' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "İşleyiş Hataları"; sıracc = 2;
                    }
                    else if (hqh == "Diğer")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'Diğer' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "Diğer"; sıracc = 2;
                    }
                    else if (hqh == "IPTAL")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("iptal ediliyor...", author2, DateTime.Now));
                        sıracc = 0;
                        ChatTextMessage message3 = new ChatTextMessage(" Lütfen yapmak istediklerinden birini seç ..", author2, DateTime.Now);
                        this.radChat1.AddMessage(message3);


                        List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                        actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                        actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                        actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                        actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                        actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                        actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                        actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                        actions.Add(new SuggestedActionDataItem("Diğer"));

                        ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                        this.radChat1.AddMessage(suggestionActionsMessage);
                    }
                    else
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Lütfen verilen seçeneklerden birini girin.İstediğiniz işlem seçeneklerde yoksa diğer seçeneğini seçin.Seçenekleri görüntülemek için list yazın.", author2, DateTime.Now));
                    }

                }
                else if (sıracc == 2)
                {
                    if (hqh == "IPTAL")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("iptal ediliyor...", author2, DateTime.Now));
                        sıracc = 0;
                        ChatTextMessage message3 = new ChatTextMessage(" Lütfen yapmak istediklerinden birini seç ..", author2, DateTime.Now);
                        this.radChat1.AddMessage(message3);


                        List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                        actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                        actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                        actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                        actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                        actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                        actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                        actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                        actions.Add(new SuggestedActionDataItem("Diğer"));

                        ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                        this.radChat1.AddMessage(suggestionActionsMessage);
                    }
                    else
                    {
                        ChatTextMessage aad = (ChatTextMessage)e.Message;
                        string hqhd = aad.Message.ToString();
                        şikayetmesajmetin = hqhd;
                        this.radChat1.AddMessage(new ChatTextMessage($"Mesajınız Göndermeye hazır \n\nMasaj Konusu:\n{şikayetmesaj}\n\n İçeriği:\n{hqhd}\n\n\nOnaylıyormusun", author2, DateTime.Now));
                        List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                        actions.Add(new SuggestedActionDataItem("Evet"));
                        actions.Add(new SuggestedActionDataItem("Hayır"));
                        ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                        this.radChat1.AddMessage(suggestionActionsMessage);

                    }
                }
                else if (sıracc == 3)
                {
                    /* listOverlay.ListView.Items.Add("Veri İşleyişi ile ilgili Öneri");
                       listOverlay.ListView.Items.Add("Ekstra özellik için öneri");
                       listOverlay.ListView.Items.Add("Algoritma düzeni için öneri");
                       listOverlay.ListView.Items.Add("Şirket içi Öneriler");
                       listOverlay.ListView.Items.Add("İstatistik Önerileri");
                       listOverlay.ListView.Items.Add("Diğer");*/
                    this.radChat1.AddMessage(new ChatTextMessage("Mesajınız Değerlendiriliyor...", author2, DateTime.Now));
                    if (hqh == "list")
                    {
                        ChatListOverlay listOverlay = new ChatListOverlay("List overlay");

                        listOverlay.ListView.Items.Add("Veri İşleyişi ile ilgili Öneri");
                        listOverlay.ListView.Items.Add("Ekstra özellik için öneri");
                        listOverlay.ListView.Items.Add("Algoritma düzeni için öneri");
                        listOverlay.ListView.Items.Add("Şirket içi Öneriler");
                        listOverlay.ListView.Items.Add("İstatistik Önerileri");
                        listOverlay.ListView.Items.Add("Diğer");
                        bool showAsPopup = false;

                        ChatOverlayMessage overlayMessage = new ChatOverlayMessage(listOverlay, showAsPopup, author2, DateTime.Now);
                        this.radChat1.AddMessage(overlayMessage);

                    }
                    else if (hqh == "Veri İşleyişi ile ilgili Öneri")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'Veri İşleyişi ile ilgili Öneri' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "Çalışmayan Özellik";
                        sıracc = 4;
                    }

                    else if (hqh == "Ekstra özellik için öneri")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'Ekstra özellik için öneri' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "Ekstra özellik için öneri"; sıracc = 4;
                    }
                    else if (hqh == "Algoritma düzeni için öneri")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'Algoritma düzeni için öneri' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "Algoritma düzeni için öneri"; sıracc = 4;
                    }
                    else if (hqh == "Şirket içi Öneriler")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'Şirket içi Önerilerı' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "Şirket içi Öneriler"; sıracc = 4;
                    }
                    else if (hqh == "İstatistik Önerileri")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'İstatistik Önerileri' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "İstatistik Önerileri"; sıracc = 4;
                    }
                    else if (hqh == "Diğer")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Konu Olarak 'Diğer' seçtiniz Lütfen metninizi yazınız.", author2, DateTime.Now));
                        şikayetmesaj = "Diğer"; sıracc = 4;
                    }
                    else if (hqh == "IPTAL")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("iptal ediliyor...", author2, DateTime.Now));
                        sıracc = 0;
                        ChatTextMessage message3 = new ChatTextMessage(" Lütfen yapmak istediklerinden birini seç ..", author2, DateTime.Now);
                        this.radChat1.AddMessage(message3);


                        List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                        actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                        actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                        actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                        actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                        actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                        actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                        actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                        actions.Add(new SuggestedActionDataItem("Diğer"));

                        ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                        this.radChat1.AddMessage(suggestionActionsMessage);
                    }
                    else
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("Lütfen verilen seçeneklerden birini girin.İstediğiniz işlem seçeneklerde yoksa diğer seçeneğini seçin.Seçenekleri görüntülemek için list yazın.", author2, DateTime.Now));
                    }

                }
                else if (sıracc == 4)
                {
                    if (hqh == "IPTAL")
                    {
                        this.radChat1.AddMessage(new ChatTextMessage("iptal ediliyor...", author2, DateTime.Now));
                        sıracc = 0;
                        ChatTextMessage message3 = new ChatTextMessage(" Lütfen yapmak istediklerinden birini seç ..", author2, DateTime.Now);
                        this.radChat1.AddMessage(message3);


                        List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                        actions.Add(new SuggestedActionDataItem("Hata Bildir"));
                        actions.Add(new SuggestedActionDataItem("Öneri Yap"));
                        actions.Add(new SuggestedActionDataItem("Hızlı Veri"));
                        actions.Add(new SuggestedActionDataItem("Seazer ve Balnature Hakkında"));
                        actions.Add(new SuggestedActionDataItem("Analiz Verilerini Göster"));
                        actions.Add(new SuggestedActionDataItem("Araçları Görüntüle"));
                        actions.Add(new SuggestedActionDataItem("Oyun ve Ayrıntıları Listele"));
                        actions.Add(new SuggestedActionDataItem("Diğer"));

                        ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                        this.radChat1.AddMessage(suggestionActionsMessage);
                    }
                    else
                    {
                        ChatTextMessage aad = (ChatTextMessage)e.Message;
                        string hqhd = aad.Message.ToString();
                        şikayetmesajmetin = hqhd;
                        this.radChat1.AddMessage(new ChatTextMessage($"Mesajınız Göndermeye hazır \n\nMasaj Konusu:\n{şikayetmesaj}\n\n İçeriği:\n{hqhd}\n\n\nOnaylıyormusun", author2, DateTime.Now));
                        List<SuggestedActionDataItem> actions = new List<SuggestedActionDataItem>();

                        actions.Add(new SuggestedActionDataItem("Evet"));
                        actions.Add(new SuggestedActionDataItem("Hayır"));
                        ChatSuggestedActionsMessage suggestionActionsMessage = new ChatSuggestedActionsMessage(actions, author2, DateTime.Now);
                        this.radChat1.AddMessage(suggestionActionsMessage);

                    }
                }
            }
        }

        private void siticonePictureBox74_Click(object sender, EventArgs e)
        {

        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton47_Click(object sender, EventArgs e)
        {
            siticoneTabControl2.SelectedTab = tabPage10;
        }

        private void siticoneButton46_Click_1(object sender, EventArgs e)
        {

            if (siticoneImageRadioButton4.Checked == true)
            {
                if (String.IsNullOrEmpty(siticoneTextBox18.Text))
                {
                    MessageBox.Show("Lütfen seçtiğiniz mekanı belirtin. ", "Bal Nature Kayıt Servisi");
                }
                else
                {
                    siticoneTabControl2.SelectedTab = tabPage11;
                    if (siticoneImageRadioButton1.Checked == true)
                    {
                        kayıttür = "Sokak Hayvanlarına Yardım";
                    }
                    else
                    {
                        kayıttür = "Geri Dönüşüm Faaliyeti";
                    }
                    kayıtzaman = radCalendar2.SelectedDate;
                    if (siticoneImageRadioButton1.Checked == true)
                    {
                        kayıtalanı = "Ev";
                    }
                    if (siticoneImageRadioButton2.Checked == true)
                    {
                        kayıtalanı = "İş Yeri";
                    }
                    if (siticoneImageRadioButton3.Checked == true)
                    {
                        kayıtalanı = "Okul";
                    }
                    if (siticoneImageRadioButton4.Checked == true)
                    {
                        kayıtalanı = siticoneTextBox18.Text;
                    }
                    zaman = radCalendar2.FocusedDate;
                }
            }
            else
            {
                siticoneTabControl2.SelectedTab = tabPage11;
                if (siticoneImageRadioButton1.Checked == true)
                {
                    kayıttür = "Sokak Hayvanlarına Yardım";
                }
                else
                {
                    kayıttür = "Geri Dönüşüm Faaliyeti";
                }
                kayıtzaman = radCalendar2.SelectedDate;
                if (siticoneImageRadioButton1.Checked == true)
                {
                    kayıtalanı = "Ev";
                }
                if (siticoneImageRadioButton2.Checked == true)
                {
                    kayıtalanı = "İş Yeri";
                }
                if (siticoneImageRadioButton3.Checked == true)
                {
                    kayıtalanı = "Okul";
                }
                if (siticoneImageRadioButton4.Checked == true)
                {
                    kayıtalanı = siticoneTextBox18.Text;
                }
                zaman = radCalendar2.FocusedDate;
            }

        }
        int sayııııı = 0;
        int ortlama = 35;
        private void siticoneNumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            siticoneNumericUpDown5.Value = 0;
            siticoneNumericUpDown3.Value = 0;
            siticoneNumericUpDown6.Value = 0;
            siticoneNumericUpDown7.Value = 0;
            siticoneNumericUpDown9.Value = 0;
            siticoneNumericUpDown8.Value = 0;
            siticoneNumericUpDown10.Value = 0;
            siticoneNumericUpDown11.Value = 0;
            radRadialGauge8.Value = 0;
            radRadialGauge9.Value = 0;
            radRadialGauge10.Value = 0;
            radRadialGauge11.Value = 0;
            radRadialGauge12.Value = 0;
            radRadialGauge13.Value = 0;
            radRadialGauge14.Value = 0;
            radRadialGauge15.Value = 0;
            radRadialGauge16.Value = 0;
            radRadialGauge4.Value = 0;
            radRadialGauge5.Value = 0;
            radRadialGauge6.Value = 0;
            radRadialGauge7.Value = 0;
            radRadialGauge2.Value = 0;


            int rete = ortlama;
            double abcd = 0;
            abcd = (int)siticoneNumericUpDown4.Value;
            double u = abcd; sayııııı = (int)abcd;
            double aa = u / rete * 100;
            double aj = Math.Round(aa, 0);
            if (101 > aj)
            {
                siticonePictureBox77.FillColor = Color.FromArgb(250, 240, 14);
                siticonePictureBox78.FillColor = Color.FromArgb(250, 240, 14);
                radialGaugeArc5.BackColor = Color.FromArgb(250, 240, 14);
                label140.BackColor = Color.FromArgb(250, 240, 14);
            }
            else
            {
                siticonePictureBox77.FillColor = Color.FromArgb(249, 25, 25);
                siticonePictureBox78.FillColor = Color.FromArgb(249, 25, 25);
                radialGaugeArc5.BackColor = Color.FromArgb(249, 25, 25); label140.BackColor = Color.FromArgb(249, 25, 25);
            }
            radRadialGauge3.Value = (int)aj;
        }
        int metal = 0, kağıt = 0, cam = 0, plastik = 0;

        private void siticoneNumericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            siticoneNumericUpDown11.Value = 0;
            plastik = (int)siticoneNumericUpDown7.Value;
            if (sayııııı - (kağıt + metal + cam + plastik) < 0)
            {
                siticoneNumericUpDown7.Value = 0;
                plastik = 0; radRadialGauge11.Value = 0; radRadialGauge12.Value = 0;
                MessageBox.Show("Lütfen girilen ürünler toplam ürünle orantılı olsun", "Bal NAture Veri Servisi");
            }
            else
            {
                double abcd = 0;
                abcd = (int)siticoneNumericUpDown4.Value;
                double u = abcd;
                double aa = plastik / abcd * 100;
                double aj = Math.Round(aa, 0);

                radRadialGauge11.Value = (int)aj;
                int uıo = kağıt + metal + cam + plastik;
                int opp = (int)abcd - uıo;
                double aa1 = opp / abcd * 100;
                double aj1 = Math.Round(aa1, 0);
                radRadialGauge12.Value = (int)aj1;
            }
        }

        private void siticoneNumericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            if (siticoneNumericUpDown9.Value <= siticoneNumericUpDown5.Value)
            {
                double abcd = 0;
                abcd = (int)siticoneNumericUpDown4.Value;
                double u = abcd;
                double yuı = (double)siticoneNumericUpDown5.Value;
                double aa = 1, aa1 = 1;
                if (yuı != 0)
                {
                    aa = (double)siticoneNumericUpDown9.Value / yuı * 100;
                }
                else
                {
                    aa = (double)siticoneNumericUpDown9.Value / 1 * 100;
                }
                double aj = Math.Round(aa, 0);
                radRadialGauge4.Value = (int)aj;
                radRadialGauge13.Value = (int)aj;
                decimal yum = siticoneNumericUpDown8.Value + siticoneNumericUpDown9.Value + siticoneNumericUpDown10.Value + siticoneNumericUpDown11.Value;
                if (yum != 0)
                {
                    aa1 = (double)yum / (double)siticoneNumericUpDown4.Value * 100;
                }
                else
                {
                    aa1 = 0;
                }
                double aj1 = Math.Round(aa1, 0);

                radRadialGauge2.Value = (int)aj1;
                if (aj1 > 51)
                {
                    radialGaugeSingleLabel1.ForeColor = Color.FromArgb(29, 184, 197);
                    label141.BackColor = Color.FromArgb(29, 184, 197);
                    siticonePictureBox79.FillColor = Color.FromArgb(29, 184, 197); siticonePictureBox80.FillColor = Color.FromArgb(29, 184, 197); siticonePictureBox80.FillColor = Color.FromArgb(29, 184, 197); siticonePictureBox80.FillColor = Color.FromArgb(29, 184, 197); siticonePictureBox80.FillColor = Color.FromArgb(29, 184, 197);
                    radialGaugeArc3.BackColor = Color.FromArgb(29, 184, 197);
                }
                else
                {
                    radialGaugeSingleLabel1.ForeColor = Color.FromArgb(249, 25, 25);
                    label141.BackColor = Color.FromArgb(249, 25, 25);
                    siticonePictureBox79.FillColor = Color.FromArgb(249, 25, 25); siticonePictureBox80.FillColor = Color.FromArgb(249, 25, 25);
                    radialGaugeArc3.BackColor = Color.FromArgb(249, 25, 25);
                }
            }
            else
            {
                siticoneNumericUpDown9.Value = 0;
                radRadialGauge13.Value = 0;
                MessageBox.Show("Lütfen dönüştürülen atık malzemenizin miktarını toplam atık madde miktarından küçük ayarlayın", "Bal NAture Veri Servisi");
                radRadialGauge4.Value = 0;
            }
        }

        private void siticoneNumericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            if (siticoneNumericUpDown8.Value <= siticoneNumericUpDown3.Value)
            {
                double abcd = 0;
                abcd = (int)siticoneNumericUpDown4.Value;
                double u = abcd;
                double yuı = (double)siticoneNumericUpDown3.Value;
                double aa = 1, aa1 = 1;
                if (yuı != 0)
                {
                    aa = (double)siticoneNumericUpDown8.Value / yuı * 100;
                }
                else
                {
                    aa = (double)siticoneNumericUpDown8.Value / 1 * 100;
                }
                double aj = Math.Round(aa, 0);
                radRadialGauge14.Value = (int)aj;
                radRadialGauge5.Value = (int)aj; decimal yum = siticoneNumericUpDown8.Value + siticoneNumericUpDown9.Value + siticoneNumericUpDown10.Value + siticoneNumericUpDown11.Value;
                if (yum != 0)
                {
                    aa1 = (double)yum / (double)siticoneNumericUpDown4.Value * 100;
                }
                else
                {
                    aa1 = 0;
                }
                double aj1 = Math.Round(aa1, 0);

                radRadialGauge2.Value = (int)aj1; if (aj1 > 51)
                {
                    radialGaugeSingleLabel1.ForeColor = Color.FromArgb(29, 184, 197);
                    label141.BackColor = Color.FromArgb(29, 184, 197);
                    siticonePictureBox79.FillColor = Color.FromArgb(29, 184, 197); siticonePictureBox80.FillColor = Color.FromArgb(29, 184, 197); siticonePictureBox80.FillColor = Color.FromArgb(29, 184, 197);
                    radialGaugeArc3.BackColor = Color.FromArgb(29, 184, 197);
                }
                else
                {
                    radialGaugeSingleLabel1.ForeColor = Color.FromArgb(249, 25, 25);
                    label141.BackColor = Color.FromArgb(249, 25, 25);
                    siticonePictureBox79.FillColor = Color.FromArgb(249, 25, 25); siticonePictureBox80.FillColor = Color.FromArgb(249, 25, 25); siticonePictureBox80.FillColor = Color.FromArgb(249, 25, 25);
                    radialGaugeArc3.BackColor = Color.FromArgb(249, 25, 25);
                }
            }
            else
            {
                siticoneNumericUpDown8.Value = 0;
                radRadialGauge14.Value = 0;
                MessageBox.Show("Lütfen dönüştürülen atık malzemenizin miktarını toplam atık madde miktarından küçük ayarlayın", "Bal NAture Veri Servisi");
                radRadialGauge5.Value = 0;
            }
        }

        private void siticoneNumericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            if (siticoneNumericUpDown10.Value <= siticoneNumericUpDown6.Value)
            {
                double abcd = 0;
                abcd = (int)siticoneNumericUpDown4.Value;
                double u = abcd; double yuı = (double)siticoneNumericUpDown6.Value;
                double aa = 1, aa1 = 1;
                if (yuı != 0)
                {
                    aa = (double)siticoneNumericUpDown10.Value / yuı * 100;
                }
                else
                {
                    aa = (double)siticoneNumericUpDown10.Value / 1 * 100;
                }
                double aj = Math.Round(aa, 0);
                radRadialGauge15.Value = (int)aj;
                radRadialGauge6.Value = (int)aj; decimal yum = siticoneNumericUpDown8.Value + siticoneNumericUpDown9.Value + siticoneNumericUpDown10.Value + siticoneNumericUpDown11.Value;
                if (yum != 0)
                {
                    aa1 = (double)yum / (double)siticoneNumericUpDown4.Value * 100;
                }
                else
                {
                    aa1 = 0;
                }
                double aj1 = Math.Round(aa1, 0);

                radRadialGauge2.Value = (int)aj1; if (aj1 > 51)
                {
                    radialGaugeSingleLabel1.ForeColor = Color.FromArgb(29, 184, 197);
                    label141.BackColor = Color.FromArgb(29, 184, 197);
                    siticonePictureBox79.FillColor = Color.FromArgb(29, 184, 197); siticonePictureBox80.FillColor = Color.FromArgb(29, 184, 197); siticonePictureBox80.FillColor = Color.FromArgb(29, 184, 197);
                    radialGaugeArc3.BackColor = Color.FromArgb(29, 184, 197);
                }
                else
                {
                    radialGaugeSingleLabel1.ForeColor = Color.FromArgb(249, 25, 25);
                    label141.BackColor = Color.FromArgb(249, 25, 25);
                    siticonePictureBox79.FillColor = Color.FromArgb(249, 25, 25); siticonePictureBox80.FillColor = Color.FromArgb(249, 25, 25);
                    radialGaugeArc3.BackColor = Color.FromArgb(249, 25, 25);
                }
            }
            else
            {
                siticoneNumericUpDown10.Value = 0;
                radRadialGauge15.Value = 0;
                MessageBox.Show("Lütfen dönüştürülen atık malzemenizin miktarını toplam atık madde miktarından küçük ayarlayın", "Bal NAture Veri Servisi");
                radRadialGauge6.Value = 0;
            }
        }

        private void siticoneNumericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            if (siticoneNumericUpDown11.Value <= siticoneNumericUpDown7.Value)
            {
                double abcd = 0;
                abcd = (int)siticoneNumericUpDown4.Value;
                double u = abcd; double yuı = (double)siticoneNumericUpDown7.Value;
                double aa = 1, aa1 = 1;
                if (yuı != 0)
                {
                    aa = (double)siticoneNumericUpDown11.Value / yuı * 100;
                }
                else
                {
                    aa = (double)siticoneNumericUpDown11.Value / 1 * 100;
                }

                double aj = Math.Round(aa, 0);
                radRadialGauge16.Value = (int)aj;
                radRadialGauge7.Value = (int)aj; decimal yum = siticoneNumericUpDown8.Value + siticoneNumericUpDown9.Value + siticoneNumericUpDown10.Value + siticoneNumericUpDown11.Value;
                if (yum != 0)
                {
                    aa1 = (double)yum / (double)siticoneNumericUpDown4.Value * 100;
                }
                else
                {
                    aa1 = 0;
                }
                double aj1 = Math.Round(aa1, 0);

                radRadialGauge2.Value = (int)aj1; if (aj1 > 51)
                {
                    radialGaugeSingleLabel1.ForeColor = Color.FromArgb(29, 184, 197);
                    label141.BackColor = Color.FromArgb(29, 184, 197);
                    siticonePictureBox79.FillColor = Color.FromArgb(29, 184, 197); siticonePictureBox80.FillColor = Color.FromArgb(29, 184, 197); siticonePictureBox80.FillColor = Color.FromArgb(29, 184, 197);
                    radialGaugeArc3.BackColor = Color.FromArgb(29, 184, 197);
                }
                else
                {
                    radialGaugeSingleLabel1.ForeColor = Color.FromArgb(249, 25, 25);
                    label141.BackColor = Color.FromArgb(249, 25, 25);
                    siticonePictureBox79.FillColor = Color.FromArgb(249, 25, 25); siticonePictureBox80.FillColor = Color.FromArgb(249, 25, 25); siticonePictureBox80.FillColor = Color.FromArgb(249, 25, 25);
                    radialGaugeArc3.BackColor = Color.FromArgb(249, 25, 25);
                }
            }
            else
            {
                siticoneNumericUpDown11.Value = 0;
                radRadialGauge16.Value = 0;
                MessageBox.Show("Lütfen dönüştürülen atık malzemenizin miktarını toplam atık madde miktarından küçük ayarlayın", "Bal NAture Veri Servisi");
                radRadialGauge7.Value = 0;
            }
        }

        private void siticonePictureBox121_Click(object sender, EventArgs e)
        {

        }

        private void label143_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton71_Click(object sender, EventArgs e)
        {
            if (siticoneNumericUpDown4.Value == 0)
            {
                MessageBox.Show("Lütfen bir değer girin. ", "Bal Nature Kayıt Servisi");
            }
            else
            {
                if (siticoneNumericUpDown3.Value == siticoneNumericUpDown4.Value && siticoneNumericUpDown4.Value == siticoneNumericUpDown6.Value && siticoneNumericUpDown6.Value == siticoneNumericUpDown7.Value && siticoneNumericUpDown7.Value == 0)
                {
                    DialogResult ajs = MessageBox.Show("Ya çok kötü bir gün yada yanlışıkla ileri bastınız. ", "Bal Nature Kayıt Servisi", MessageBoxButtons.OKCancel);
                    if (ajs == DialogResult.OK)
                    {
                        siticoneTabControl2.SelectedTab = tabPage12;
                        toplamatık = (int)siticoneNumericUpDown4.Value;
                        toplamatıkoran = (int)radRadialGauge3.Value;

                        kağıatık = (int)siticoneNumericUpDown3.Value;
                        kağıtatıkoran = (int)radRadialGauge9.Value;

                        camatık = (int)siticoneNumericUpDown6.Value;
                        camatıkoran = (int)radRadialGauge10.Value;

                        metalatık = (int)siticoneNumericUpDown5.Value;
                        metalatıkoran = (int)radRadialGauge8.Value;

                        plastikatık = (int)siticoneNumericUpDown7.Value;
                        plastikatıkoran = (int)radRadialGauge11.Value;
                        geridönüştürülenatığıntoplamatığpaoranı = (int)radRadialGauge12.Value;
                        evselatıkoran = (int)radRadialGauge12.Value;
                        gdcam = (int)siticoneNumericUpDown10.Value;
                        gdcamoran = (int)radRadialGauge15.Value;
                        gdkağıt = (int)siticoneNumericUpDown8.Value;
                        gdkağıtoran = (int)radRadialGauge14.Value;
                        gdmetal = (int)siticoneNumericUpDown9.Value;
                        gdmetaloran = (int)radRadialGauge13.Value;
                        gdplastik = (int)siticoneNumericUpDown11.Value;
                        gdplastikoran = (int)radRadialGauge16.Value;
                        geridönüştürülenatığıntoplamatığpaoranı = (int)radRadialGauge2.Value;
                    }
                }
                else if (siticoneNumericUpDown8.Value == siticoneNumericUpDown9.Value && siticoneNumericUpDown9.Value == siticoneNumericUpDown10.Value && siticoneNumericUpDown10.Value == siticoneNumericUpDown11.Value && siticoneNumericUpDown11.Value == 0)
                {
                    DialogResult ajs = MessageBox.Show("Ya çok kötü bir gün yada yanlışıkla ileri bastınız. ", "Bal Nature Kayıt Servisi", MessageBoxButtons.OKCancel);
                    if (ajs == DialogResult.OK)
                    {
                        siticoneTabControl2.SelectedTab = tabPage12;
                        toplamatık = (int)siticoneNumericUpDown4.Value;
                        toplamatıkoran = (int)radRadialGauge3.Value;

                        kağıatık = (int)siticoneNumericUpDown3.Value;
                        kağıtatıkoran = (int)radRadialGauge9.Value;

                        camatık = (int)siticoneNumericUpDown6.Value;
                        camatıkoran = (int)radRadialGauge10.Value;

                        metalatık = (int)siticoneNumericUpDown5.Value;
                        metalatıkoran = (int)radRadialGauge8.Value;

                        plastikatık = (int)siticoneNumericUpDown7.Value;
                        plastikatıkoran = (int)radRadialGauge11.Value;
                        geridönüştürülenatığıntoplamatığpaoranı = (int)radRadialGauge12.Value;
                        evselatıkoran = (int)radRadialGauge12.Value;
                        gdcam = (int)siticoneNumericUpDown10.Value;
                        gdcamoran = (int)radRadialGauge15.Value;
                        gdkağıt = (int)siticoneNumericUpDown8.Value;
                        gdkağıtoran = (int)radRadialGauge14.Value;
                        gdmetal = (int)siticoneNumericUpDown9.Value;
                        gdmetaloran = (int)radRadialGauge13.Value;
                        gdplastik = (int)siticoneNumericUpDown11.Value;
                        gdplastikoran = (int)radRadialGauge16.Value;
                        geridönüştürülenatığıntoplamatığpaoranı = (int)radRadialGauge2.Value;
                    }
                }
                else
                {
                    siticoneTabControl2.SelectedTab = tabPage12;
                    toplamatık = (int)siticoneNumericUpDown4.Value;
                    toplamatıkoran = (int)radRadialGauge3.Value;

                    kağıatık = (int)siticoneNumericUpDown3.Value;
                    kağıtatıkoran = (int)radRadialGauge9.Value;

                    camatık = (int)siticoneNumericUpDown6.Value;
                    camatıkoran = (int)radRadialGauge10.Value;

                    metalatık = (int)siticoneNumericUpDown5.Value;
                    metalatıkoran = (int)radRadialGauge8.Value;

                    plastikatık = (int)siticoneNumericUpDown7.Value;
                    plastikatıkoran = (int)radRadialGauge11.Value;
                    geridönüştürülenatığıntoplamatığpaoranı = (int)radRadialGauge12.Value;
                    evselatıkoran = (int)radRadialGauge12.Value;
                    gdcam = (int)siticoneNumericUpDown10.Value;
                    gdcamoran = (int)radRadialGauge15.Value;
                    gdkağıt = (int)siticoneNumericUpDown8.Value;
                    gdkağıtoran = (int)radRadialGauge14.Value;
                    gdmetal = (int)siticoneNumericUpDown9.Value;
                    gdmetaloran = (int)radRadialGauge13.Value;
                    gdplastik = (int)siticoneNumericUpDown11.Value;
                    gdplastikoran = (int)radRadialGauge16.Value;
                    geridönüştürülenatığıntoplamatığpaoranı = (int)radRadialGauge2.Value;
                }
            }
            radRadialGauge17.Value = radRadialGauge3.Value; radRadialGauge18.Value = radRadialGauge2.Value; label158.Text = $"Merhaba {Ad} {Soyad} {DateTime.Now.ToShortDateString()} Tarihi itibariyle yaptığğınız kayıt verilerinize eklenmiştir.Aşağıdaki bitir tuşuna basıp ana menüye dönebilirsiniz \r\n\r\nSağlıklı Günler Dileriz,";
        }

        private void siticoneButton73_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton73_Click_1(object sender, EventArgs e)
        {
            if (radRating1.Value == 0 || radRating1.Value == null)
            {
                MessageBox.Show("Lütfen analizlerimizde kullanmak için Kendini değerlendir bölümünü doldurun.", "Bal Nature Kayıt SErvisi");
            }
            else
            {

                MessageBox.Show("Kaydınız Başarıyla tamamlandı.", "Bal Nature Kayıt Servisi");
                kayıtdeğerlendirme = (double)radRating1.Value;

                siticoneTextBox15.Text = ""; siticoneTextBox17.Text = ""; siticoneTextBox18.Text = ""; radCalendar2.SelectedDate = DateTime.Now;
                radRating1.Value = 0; radRadioButton2.CheckState = CheckState.Checked;
                siticoneNumericUpDown3.Value = 0;
                siticoneNumericUpDown4.Value = 0;
                siticoneNumericUpDown5.Value = 0;
                siticoneNumericUpDown6.Value = 0;
                siticoneNumericUpDown7.Value = 0;
                siticoneNumericUpDown8.Value = 0;
                siticoneNumericUpDown9.Value = 0;
                siticoneNumericUpDown10.Value = 0;
                siticoneNumericUpDown11.Value = 0;
                radRadialGauge3.Value = 0;
                radRadialGauge8.Value = 0;
                radRadialGauge9.Value = 0;
                radRadialGauge10.Value = 0;

                radRadialGauge11.Value = 0;
                radRadialGauge12.Value = 0;
                radRadialGauge2.Value = 0;
                radRadialGauge4.Value = 0;
                radRadialGauge5.Value = 0;
                radRadialGauge6.Value = 0;
                radRadialGauge7.Value = 0;
                radRadialGauge13.Value = 0;
                radRadialGauge14.Value = 0;
                radRadialGauge15.Value = 0;
                radRadialGauge16.Value = 0;
                radRadialGauge17.Value = 0;
                radRadialGauge18.Value = 0;

                //List<kayıtsınıfı> kayıt = new List<kayıtsınıfı>();
                ////yazma
                //string json = Newtonsoft.Json.JsonConvert.SerializeObject(kayıt);
                ////okuma
                //Newtonsoft.Json.JsonConvert.DeserializeObject<List<kayıtsınıfı>>("");
                List<kayıtsınıfı> kayıt = new List<kayıtsınıfı>();
                if (eklemeler == "Bos" || eklemeler == "Boş")
                {
                    kayıtsınıfı kıy = new kayıtsınıfı();
                    kıy.camatıkoranx = camatıkoran;
                    kıy.camatıkx = camatık;
                    kıy.evselatıkorax = evselatıkoran;
                    kıy.gdcam = gdcam;
                    kıy.gdcamoran = gdcamoran;
                    kıy.gdkağıt = gdkağıt;
                    kıy.gdkağıtoran = gdkağıtoran;
                    kıy.gdmetaloran = gdmetaloran;
                    kıy.gdmetal = gdmetal;
                    kıy.gdplastik = gdplastik;
                    kıy.gdplastikoran = gdplastikoran;
                    kıy.kayıtdeğerlendirme = kayıtdeğerlendirme;
                    kıy.geridönüştürülenatığıntoplamatığaoranıx = geridönüştürülenatığıntoplamatığpaoranı;
                    kıy.kayıtalanıx = kayıtalanı;
                    kıy.kayıtaçıklamax = kayıtaçıklama;
                    kıy.kayıtbaşlıkx = kayıtbaşlık;
                    kıy.kayıttürx = kayıttür;
                    kıy.kağıtatıkoranx = kağıtatıkoran;
                    kıy.kağıtatıkx = kağıatık;
                    kıy.plastikatıkx = plastikatık;
                    kıy.plastikatıkoranx = plastikatıkoran;
                    kıy.toplamatıkoranx = toplamatıkoran;
                    kıy.toplamatıkx = toplamatık;
                    kıy.metalatıkx = metalatık;
                    kıy.metalatıkoranx = metalatıkoran;
                    kıy.zamanx = zaman;
                    kayıt.Add(kıy);
                    eklemeler = Newtonsoft.Json.JsonConvert.SerializeObject(kayıt);
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
                    KayıtEkleDatabase(EPosta, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;");
                }
                else
                {

                    veriaktarimi kıy = new veriaktarimi();
                    
                    kıy.Cama = camatık;
              
                    kıy.Camg = gdcam;
                
                    kıy.Kağıtg = gdkağıt;
                 
                    kıy.Metalg = gdmetal;
                    kıy.Platikg = gdplastik;
              kıy.Kaydıdegerlendir =Convert.ToInt32( kayıtdeğerlendirme);
                  
                    kıy.Faliyetalanı = kayıtalanı;
                    kıy.Açiklama = kayıtaçıklama;
                    kıy.Ad = kayıtbaşlık;
                    kıy.Tur = 1;
               
                    kıy.Kağıta = kağıatık;
                    kıy.Plastika = plastikatık;
                   
                    kıy.Toplamatık = toplamatık;
                    kıy.Cama = metalatık;

                    kıy.Tarih = DateTime.Now.Ticks;

                    dataa.VeriListesi.Add(kıy);
                    async Task mlşmAsync()
                    {



                        var config2 = new FirebaseAuthConfig
                        {
                            ApiKey = "AIzaSyATfIezNXb9MdNuTczda2uDkw4BJiLsG28",
                            AuthDomain = "balnature.firebaseapp.com",
                            Providers = new FirebaseAuthProvider[]
                            {
                                    // Add and configure individual providers
                                    new GoogleProvider().AddScopes(),
                                    new EmailProvider()
                                // ...
                            },
                            // WPF
                            UserRepository = new FileUserRepository(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ball.json"))
                        };

                        // ...and create your FirebaseAuthClient
                        var client2 = new FirebaseAuthClient(config2);
                        String uid = "kjl";
                        try
                        {
                            







                            try
                            {
                                IFirebaseConfig config3 = new FirebaseConfig
                                {
                                    AuthSecret = "txG0YPGu6DZWk6KgyWss2qAveKAGhpjlrzEybbda",
                                    BasePath = "https://balnature-default-rtdb.firebaseio.com"
                                };

                                IFirebaseClient client3;
                                void Connection3()
                                {
                                    client3 = new FireSharp.FirebaseClient(config3);

                                    if (client3 != null)
                                    {

                                        SetResponse response = null;
                                        Kullanici result = null;

                                        async void Insert()
                                        {













                                            uid = File.ReadAllText("C:\\ProgramData\\SEAzer\\BALNature\\uid.txt");

                                          
                                            response = await client3.SetAsync("kullanicilar/" + uid + "/veriListesi/", dataa.VeriListesi);
                                            

                                           


                                        }
                                        Insert();
                                    }


                                }
                                Connection3();
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("hgbhdghj");
                            }




                        }
                        catch (Exception x)
                        {

                            MessageBox.Show($"dslkajflasdhjfkas  {x.Message.ToString()}");
                        }

                        sayı1 = 8;
                        timer1.Start();
                    }
                    mlşmAsync();

                }
            }
            siticoneTabControl2.SelectedTab = tabPage7;
        }

        void bildirimekle(bild veri)
        {
            async Task mlşmAsync()
            {



                var config2 = new FirebaseAuthConfig
                {
                    ApiKey = "AIzaSyATfIezNXb9MdNuTczda2uDkw4BJiLsG28",
                    AuthDomain = "balnature.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[]
                    {
                                    // Add and configure individual providers
                                    new GoogleProvider().AddScopes(),
                                    new EmailProvider()
                        // ...
                    },
                    // WPF
                    UserRepository = new FileUserRepository(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ball.json"))
                };

                // ...and create your FirebaseAuthClient
                var client2 = new FirebaseAuthClient(config2);
                String uid = "kjl";
                try
                {  

                    try
                    {
                        IFirebaseConfig config3 = new FirebaseConfig
                        {
                            AuthSecret = "txG0YPGu6DZWk6KgyWss2qAveKAGhpjlrzEybbda",
                            BasePath = "https://balnature-default-rtdb.firebaseio.com"
                        };

                        IFirebaseClient client3;
                        void Connection3()
                        {
                            client3 = new FireSharp.FirebaseClient(config3);

                            if (client3 != null)
                            {

                                SetResponse response = null;
                                Kullanici result = null;

                                async void Insert()
                                {



                                     uid = File.ReadAllText("C:\\ProgramData\\SEAzer\\BALNature\\uid.txt");
                                 
                                   
                                    dataa.Bildirim.Add(veri);

                                    response = await client3.SetAsync("kullanicilar/" + uid + "/Bildirim/", dataa.Bildirim);
                                    

                                    

                                }
                                Insert();
                            }


                        }
                        Connection3();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("hgbhdghj");
                    }




                }
                catch (Exception x)
                {

                    MessageBox.Show($"dslkajflasdhjfkas  {x.Message.ToString()}");
                }

                sayı1 = 8;
                timer1.Start();
            }
            mlşmAsync(); 
        }
        private void siticoneNumericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            siticoneNumericUpDown10.Value = 0;
            cam = (int)siticoneNumericUpDown6.Value;
            if (sayııııı - (kağıt + metal + cam + plastik) < 0)
            {
                radRadialGauge6.Value = 0;
                siticoneNumericUpDown6.Value = 0;
                cam = 0; radRadialGauge10.Value = 0; radRadialGauge12.Value = 0;
                MessageBox.Show("Lütfen girilen ürünler toplam ürünle orantılı olsun", "Bal NAture Veri Servisi");
            }
            else
            {
                double abcd = 0;
                abcd = (int)siticoneNumericUpDown4.Value;
                double u = abcd;
                double aa = cam / abcd * 100;
                double aj = Math.Round(aa, 0);

                radRadialGauge10.Value = (int)aj;
                int uıo = kağıt + metal + cam + plastik;
                int opp = (int)abcd - uıo;
                double aa1 = opp / abcd * 100;
                double aj1 = Math.Round(aa1, 0);
                radRadialGauge12.Value = (int)aj1;
            }
        }

        private void siticoneNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            siticoneNumericUpDown8.Value = 0;
            kağıt = (int)siticoneNumericUpDown3.Value;
            if (sayııııı - (kağıt + metal + cam + plastik) < 0)
            {
                radRadialGauge9.Value = 0;
                siticoneNumericUpDown3.Value = 0;
                kağıt = 0; radRadialGauge9.Value = 0; radRadialGauge12.Value = 0;
                MessageBox.Show("Lütfen girilen ürünler toplam ürünle orantılı olsun", "Bal NAture Veri Servisi");
            }
            else
            {
                double abcd = 0;
                abcd = (int)siticoneNumericUpDown4.Value;
                double u = abcd;
                double aa = kağıt / abcd * 100;
                double aj = Math.Round(aa, 0);

                radRadialGauge9.Value = (int)aj;
                int uıo = kağıt + metal + cam + plastik;
                int opp = (int)abcd - uıo;
                double aa1 = opp / abcd * 100;
                double aj1 = Math.Round(aa1, 0);
                radRadialGauge12.Value = (int)aj1;
            }
        }

        private void siticoneNumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            siticoneNumericUpDown9.Value = 0;
            metal = (int)siticoneNumericUpDown5.Value;
            if (sayııııı - (kağıt + metal + cam + plastik) < 0)
            {
                radRadialGauge8.Value = 0;
                siticoneNumericUpDown5.Value = 0;
                metal = 0;
                radRadialGauge8.Value = 0; radRadialGauge12.Value = 0;
                MessageBox.Show("Lütfen girilen ürünler toplam ürünle orantılı olsun", "Bal Nature Veri Servisi");
                radRadialGauge8.Value = 0;
            }
            else
            {
                double abcd = 0;
                abcd = (int)siticoneNumericUpDown4.Value;
                double u = abcd;
                double aa = metal / abcd * 100;
                double aj = Math.Round(aa, 0);

                radRadialGauge8.Value = (int)aj;
                int uıo = kağıt + metal + cam + plastik;
                int opp = (int)abcd - uıo;
                double aa1 = opp / abcd * 100;
                double aj1 = Math.Round(aa1, 0);
                radRadialGauge12.Value = (int)aj1;
            }
        }

        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.instagram.com/balnature.erasmus/");
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:balnature.erasmus@gmail.com");
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://goo.gl/maps/AXtDCqVFRxr7HBxk7");
        }

        private void siticoneButton60_Click(object sender, EventArgs e)
        {
            label80.Visible = true;
            label81.Visible = true;
            label79.Visible = false;
            label64.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label68.Visible = false;
            label69.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            siticonePictureBox25.Visible = false;
            linkLabel14.Visible = false;
            label56.Visible = false;
            label57.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
            label60.Visible = false;
            label61.Visible = false;
            label62.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            label54.Visible = false;
            label55.Visible = false;

            label47.Visible = false;
            label48.Visible = false;
            label49.Visible = false;
            siticonePictureBox22.Visible = false;
            siticonePictureBox23.Visible = false;
            siticonePictureBox24.Visible = false;
            linkLabel14.Visible = false;
            linkLabel15.Visible = false;
            label63.Visible = false;
            linkLabel16.Visible = false;
            linkLabel17.Visible = false;
            linkLabel18.Visible = false;
            linkLabel19.Visible = false;
            linkLabel20.Visible = false;
            siticonePictureBox27.Visible = false;
            siticonePictureBox28.Visible = false;
            siticonePictureBox29.Visible = false;
            siticonePictureBox30.Visible = false;
            siticonePictureBox31.Visible = false;
            siticoneGroupBox1.Visible = false;
        }

        private void siticoneButton62_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(siticoneTextBox2.Text) || string.IsNullOrEmpty(siticoneTextBox2.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurun", "Uyarı");


            }
            else if (checkBox1.Checked == false)
            {
                MessageBox.Show("Lütfen Aydınlatma Metnini okuyunuz", "Uyarı");
            }
            else
            {
                MailMessage mesaj = new MailMessage();
                mesaj.From = new MailAddress("balnature.erasmus@outlook.com");
                mesaj.To.Add("balnature.erasmus@gmail.com");
                mesaj.To.Add("balnature.erasmus@outlook.com");
                mesaj.Subject = siticoneTextBox2.Text;
                mesaj.Body = siticoneTextBox3.Text;

                SmtpClient a = new SmtpClient();
                a.Credentials = new System.Net.NetworkCredential("balnature.erasmus@outlook.com", "S234432s");
                a.Port = 587;
                a.Host = "smtp-mail.outlook.com";
                a.EnableSsl = true;
                object userState = mesaj;

                try
                {
                    string değer = DateTime.Now.ToShortTimeString();
                    if (bildirimler == "Boş")
                    {
                        a.SendAsync(mesaj, (object)mesaj);
                       



                        DateTime tarihj = DateTime.Now;
                        //Bu projeye başlarken ne yazdığımı tek Tanrı ve ben biliyordum
                        //Şimdi bir tek o biliyor!!!
                        bild kıy = new bild();
                        kıy.Kısaaçıklama = "Mesaj gönderildi bilgisi";
                        kıy.Tarih = DateTime.Now.ToShortDateString();
                        kıy.Konu = "Mesajınız gönderildi";
                        kıy.Açıklama = $"Saat {değer} te gönderdiğiniz \n Başlığı:{siticoneTextBox2.Text}\n Konusu:{siticoneTextBox3.Text}\n Olan e postanız başarıyla gönderilmiştir";


                       
                        bildirimekle(kıy);
                        SiticoneButton nmm = new SiticoneButton();
                        bildirimlistele();
                    }
                    else
                    {
                        a.SendAsync(mesaj, (object)mesaj);
                        List<Class2> Data3 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class2>>(bildirimler);


                        DateTime tarihj = DateTime.Now;
                        //Bu projeye başlarken ne yazdığımı tek Tanrı ve ben biliyordum
                        //Şimdi bir tek o biliyor!!!
                        bild kıy = new bild();
                        kıy.Kısaaçıklama = "Mesaj gönderildi bilgisi";
                        kıy.Tarih = DateTime.Now.ToShortDateString();
                        kıy.Konu = "Mesajınız gönderildi";
                        kıy.Açıklama = $"Saat {değer} te gönderdiğiniz \n Başlığı:{siticoneTextBox2.Text}\n Konusu:{siticoneTextBox3.Text}\n Olan e postanız başarıyla gönderilmiştir";

                        bildirimekle(kıy);
                        SiticoneButton nmm = new SiticoneButton();
                        bildirimlistele();
                    }




                    notify_Icon2.Visible = true;
                    notify_Icon2.Text = "BAL Nature";

                    notify_Icon2.BalloonTipTitle = "Mesajınız gönderildi";

                    string değer2 = $"Saat {değer} te gönderdiğiniz \n Başlığı:{siticoneTextBox2.Text}\n Konusu:{siticoneTextBox3.Text}\n Olan e postanız başarıyla gönderilmiştir";

                    //Bu projeye başlarken ne yazdığımı tek Tanrı ve ben biliyordum
                    //Şimdi bir tek o biliyor!!!


                    //$"Saat {DateTime.Now.ToShortTimeString()} hala biraz daha puan toplayıp kendini ilerletmen için fırsat var";


                    notify_Icon2.BalloonTipText = değer2;
                    notify_Icon2.BalloonTipIcon = ToolTipIcon.Info;
                    notify_Icon2.ShowBalloonTip(2500);
                }

                catch (SmtpException ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
                }
            }
        }



        private void linkLabel18_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://goo.gl/maps/AXtDCqVFRxr7HBxk7");
        }

        private void siticonePictureBox23_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://erasmus-plus.ec.europa.eu/");
        }

        private void linkLabel17_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://balnatureerasmus.wixsite.com/balnature");
        }

        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel16_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:balnature.erasmus@gmail.com");
        }

        private void linkLabel20_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.instagram.com/balnature.erasmus/");
        }

        private void siticonePictureBox22_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://balnatureerasmus.wixsite.com/balnature");
        }

        private void label49_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://balnatureerasmus.wixsite.com/balnature");
        }

        private void siticonePictureBox24_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://bursaanadolulisesi.meb.k12.tr/");
        }

        private void label49_MouseEnter(object sender, EventArgs e)
        {

        }

        private void siticoneButton29_Click(object sender, EventArgs e)
        {
            siticoneButton29.Checked = false;

        }

        private void siticoneDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Oturum  Açılmış
        private void siticoneButton29_Click_1(object sender, EventArgs e)
        {
            label122.Visible = false;
            label119.Visible = false;
            label120.Visible = false;
            label121.Visible = false;
            siticoneTextBox8.BorderColor = Color.Black;
            siticoneTextBox9.BorderColor = Color.Black;
            siticoneTextBox10.BorderColor = Color.Black;
            siticoneTextBox4.BorderColor = Color.Black;
            siticoneTextBox5.BorderColor = Color.Black;
            label117.Visible = false;
            label118.Visible = false;
            siticoneButton65.Visible = false;
            siticoneButton66.Visible = false;
            siticoneButton64.Visible = false;
            siticoneTextBox6.Visible = true;
            siticoneTextBox5.Visible = true;
            pictureBox28.Visible = false; siticoneButton63.Visible = false; siticoneButton63.Visible = false;
            siticoneTextBox4.Visible = true;
            label82.Visible = true; label83.Visible = true; label84.Visible = true; label86.Visible = true; label85.Visible = true;
            siticoneDateTimePicker1.Visible = true; siticoneToggleSwitch2.Visible = true; siticoneToggleSwitch1.Visible = true; siticoneToggleSwitch3.Visible = true;
            siticoneButton37.Visible = true;
            label45.Text = "Profiliniz";
            label46.Text = "Kendiniz hakkında bilgi ekleyin";
            label88.Visible = false; label90.Visible = false; label89.Visible = false;
            siticoneTextBox7.Visible = false; siticoneTextBox8.Visible = false; siticoneTextBox9.Visible = false; siticoneTextBox10.Visible = false;
            siticoneButton41.Visible = false;

            siticoneCheckBox1.Visible = false;
            label100.Visible = false; siticoneButton42.Visible = false;
            pictureBox27.Visible = false;
            label96.Visible = false; label97.Visible = false; label98.Visible = false; label99.Visible = false;
            label91.Visible = false; label92.Visible = false; label93.Visible = false; label94.Visible = false; label95.Visible = false;
            siticoneButton40.Visible = false;
            siticoneTextBox11.Visible = false; siticoneTextBox12.Visible = false; siticoneTextBox13.Visible = false; siticoneTextBox14.Visible = false; siticoneTextBox16.Visible = false;
            siticonePictureBox26.Visible = false; siticonePictureBox32.Visible = false; siticonePictureBox33.Visible = false; siticonePictureBox34.Visible = false;
            siticoneComboBox3.Visible = false;
            siticoneToggleSwitch6.Visible = false; siticoneToggleSwitch5.Visible = false; siticoneToggleSwitch4.Visible = false;
            label101.Visible = false; label102.Visible = false; label103.Visible = false; label104.Visible = false; label105.Visible = false; label106.Visible = false; label107.Visible = false; label108.Visible = false;
            siticoneComboBox1.Visible = false;
            siticoneNumericUpDown1.Visible = false; siticoneNumericUpDown2.Visible = false;
            siticoneCheckBox2.Visible = false; siticoneCheckBox3.Visible = false; siticoneCheckBox4.Visible = false; siticoneCheckBox5.Visible = false; siticoneCheckBox6.Visible = false;
            siticoneButton67.Visible = false; siticoneButton68.Visible = false; siticoneButton69.Visible = false; siticoneButton70.Visible = false;
            label109.Visible = false; label110.Visible = false; label111.Visible = false; label112.Visible = false; label113.Visible = false; label114.Visible = false; label115.Visible = false; label116.Visible = false;
            siticoneCheckBox7.Visible = false; siticoneCheckBox8.Visible = false; siticoneCheckBox9.Visible = false; siticoneCheckBox10.Visible = false; siticoneCheckBox11.Visible = false; siticoneCheckBox12.Visible = false; siticoneCheckBox13.Visible = false;
            linkLabel22.Visible = false; linkLabel23.Visible = false; linkLabel24.Visible = false; linkLabel26.Visible = false;
        }

        private void siticoneButton30_Click_1(object sender, EventArgs e)
        {
            label122.Visible = false;
            label119.Visible = false;
            label120.Visible = false;
            label121.Visible = false;
            siticoneTextBox8.BorderColor = Color.Black;
            siticoneTextBox9.BorderColor = Color.Black;
            siticoneTextBox10.BorderColor = Color.Black;
            label117.Visible = false;
            label118.Visible = false;
            siticoneButton65.Visible = false;
            siticoneButton66.Visible = false;
            siticoneButton64.Visible = false;
            label96.Visible = false; label97.Visible = false; label98.Visible = false; label99.Visible = false;
            label88.Visible = true; label90.Visible = true; label89.Visible = true;
            siticoneTextBox7.Visible = true; siticoneTextBox8.Visible = true; siticoneTextBox9.Visible = true; siticoneTextBox10.Visible = true;
            siticoneButton41.Visible = true;

            siticoneComboBox3.Visible = false;
            siticoneToggleSwitch6.Visible = false; siticoneToggleSwitch5.Visible = false; siticoneToggleSwitch4.Visible = false;
            siticoneCheckBox1.Visible = true;
            pictureBox27.Visible = true;
            siticoneButton67.Visible = false; siticoneButton68.Visible = false; siticoneButton69.Visible = false; siticoneButton70.Visible = false;
            label100.Visible = false; siticoneButton42.Visible = false;
            siticoneTextBox6.Visible = false;
            pictureBox28.Visible = false; siticoneButton63.Visible = false; siticoneButton63.Visible = false;
            label91.Visible = false; label92.Visible = false; label93.Visible = false; label94.Visible = false; label95.Visible = false;
            siticoneButton40.Visible = false;
            siticoneTextBox11.Visible = false; siticoneTextBox12.Visible = false; siticoneTextBox13.Visible = false; siticoneTextBox14.Visible = false; siticoneTextBox16.Visible = false;
            siticonePictureBox26.Visible = false; siticonePictureBox32.Visible = false; siticonePictureBox33.Visible = false; siticonePictureBox34.Visible = false;
            siticoneTextBox5.Visible = false;
            label101.Visible = false; label102.Visible = false; label103.Visible = false; label104.Visible = false; label105.Visible = false; label106.Visible = false; label107.Visible = false; label108.Visible = false;
            siticoneComboBox1.Visible = false;
            label109.Visible = false; label110.Visible = false; label111.Visible = false; label112.Visible = false; label113.Visible = false; label114.Visible = false; label115.Visible = false; label116.Visible = false;
            siticoneCheckBox7.Visible = false; siticoneCheckBox8.Visible = false; siticoneCheckBox9.Visible = false; siticoneCheckBox10.Visible = false; siticoneCheckBox11.Visible = false; siticoneCheckBox12.Visible = false; siticoneCheckBox13.Visible = false;
            linkLabel22.Visible = false; linkLabel23.Visible = false; linkLabel24.Visible = false; linkLabel26.Visible = false;
            siticoneNumericUpDown1.Visible = false; siticoneNumericUpDown2.Visible = false;
            siticoneCheckBox2.Visible = false; siticoneCheckBox3.Visible = false; siticoneCheckBox4.Visible = false; siticoneCheckBox5.Visible = false; siticoneCheckBox6.Visible = false;

            siticoneTextBox4.Visible = false;
            label82.Visible = false; label83.Visible = false; label84.Visible = false; label86.Visible = false; label85.Visible = false;
            siticoneDateTimePicker1.Visible = false; siticoneToggleSwitch2.Visible = false; siticoneToggleSwitch1.Visible = false; siticoneToggleSwitch3.Visible = false;
            siticoneButton37.Visible = false;
            label45.Text = "Hesap Güvenliği";
            label46.Text = "Hesap ayarlarınızı düzenleme ve şifre değiştirme işlemlerinizi buradan yapabilirsiniz.";
        }

        private void siticoneButton35_Click(object sender, EventArgs e)
        {
            label122.Visible = false;
            label119.Visible = false;
            label120.Visible = false;
            label121.Visible = false;
            siticoneTextBox8.BorderColor = Color.Black;
            siticoneTextBox9.BorderColor = Color.Black;
            siticoneTextBox10.BorderColor = Color.Black;
            label117.Visible = false;
            label118.Visible = false;
            siticoneButton65.Visible = false;
            siticoneButton66.Visible = false;
            siticoneButton64.Visible = false;
            siticoneTextBox6.Visible = false;
            siticoneTextBox5.Visible = false;

            siticoneButton67.Visible = false; siticoneButton68.Visible = false; siticoneButton69.Visible = false; siticoneButton70.Visible = false;
            siticoneComboBox3.Visible = false;
            siticoneToggleSwitch6.Visible = false; siticoneToggleSwitch5.Visible = false; siticoneToggleSwitch4.Visible = false;
            label91.Visible = false; label92.Visible = false; label93.Visible = false; label94.Visible = false; label95.Visible = false;
            siticoneButton40.Visible = false;
            siticoneTextBox11.Visible = false; siticoneTextBox12.Visible = false; siticoneTextBox13.Visible = false; siticoneTextBox14.Visible = false; siticoneTextBox16.Visible = false;
            siticonePictureBox26.Visible = false; siticonePictureBox32.Visible = false; siticonePictureBox33.Visible = false; siticonePictureBox34.Visible = false;
            siticoneCheckBox1.Visible = false;
            label109.Visible = false; label110.Visible = false; label111.Visible = false; label112.Visible = false; label113.Visible = false; label114.Visible = false; label115.Visible = false; label116.Visible = false;
            siticoneCheckBox7.Visible = false; siticoneCheckBox8.Visible = false; siticoneCheckBox9.Visible = false; siticoneCheckBox10.Visible = false; siticoneCheckBox11.Visible = false; siticoneCheckBox12.Visible = false; siticoneCheckBox13.Visible = false;
            linkLabel22.Visible = false; linkLabel23.Visible = false; linkLabel24.Visible = false; linkLabel26.Visible = false;
            pictureBox28.Visible = false; siticoneButton63.Visible = false; siticoneButton63.Visible = false;
            pictureBox27.Visible = false;
            label101.Visible = false; label102.Visible = false; label103.Visible = false; label104.Visible = false; label105.Visible = false; label106.Visible = false; label107.Visible = false; label108.Visible = false;
            siticoneComboBox1.Visible = false;
            siticoneNumericUpDown1.Visible = false; siticoneNumericUpDown2.Visible = false;
            siticoneCheckBox2.Visible = false; siticoneCheckBox3.Visible = false; siticoneCheckBox4.Visible = false; siticoneCheckBox5.Visible = false; siticoneCheckBox6.Visible = false;

            label100.Visible = false; siticoneButton42.Visible = false;
            siticoneTextBox4.Visible = false;
            label88.Visible = false; label90.Visible = false; label89.Visible = false;
            siticoneTextBox7.Visible = false; siticoneTextBox8.Visible = false; siticoneTextBox9.Visible = false; siticoneTextBox10.Visible = false;
            siticoneButton41.Visible = false;
            label82.Visible = false; label83.Visible = false; label84.Visible = false; label86.Visible = false; label85.Visible = false;
            siticoneDateTimePicker1.Visible = false; siticoneToggleSwitch2.Visible = false; siticoneToggleSwitch1.Visible = false; siticoneToggleSwitch3.Visible = false;
            siticoneButton37.Visible = false;
            label45.Text = "Hesaplarını Bağla";
            label46.Text = "Hesaplarını bağlayarak kapsamını genişlet";
            label91.Visible = true; label92.Visible = true; label93.Visible = true; label94.Visible = true; label95.Visible = true; label96.Visible = true; label97.Visible = true; label98.Visible = true; label99.Visible = true;
            siticoneButton40.Visible = true;
            siticoneTextBox11.Visible = true; siticoneTextBox12.Visible = true; siticoneTextBox13.Visible = true; siticoneTextBox14.Visible = true; siticoneTextBox16.Visible = true;
            siticonePictureBox26.Visible = true; siticonePictureBox32.Visible = true; siticonePictureBox33.Visible = true; siticonePictureBox34.Visible = true;

        }

        private void siticoneButton32_Click_1(object sender, EventArgs e)
        {
            label122.Visible = false;
            label119.Visible = false;
            label120.Visible = false;
            label121.Visible = false;
            siticoneTextBox8.BorderColor = Color.Black;
            siticoneTextBox9.BorderColor = Color.Black;
            siticoneTextBox10.BorderColor = Color.Black;
            label117.Visible = false;
            label118.Visible = false;
            siticoneButton65.Visible = false;
            siticoneButton66.Visible = false;
            siticoneButton64.Visible = false;
            label100.Visible = true; siticoneButton42.Visible = true;
            siticoneTextBox6.Visible = false;
            siticoneButton67.Visible = false; siticoneButton68.Visible = false; siticoneButton69.Visible = false; siticoneButton70.Visible = false;
            label88.Visible = false; label90.Visible = false; label89.Visible = false;
            siticoneTextBox7.Visible = false; siticoneTextBox8.Visible = false; siticoneTextBox9.Visible = false; siticoneTextBox10.Visible = false;
            siticoneButton41.Visible = false;

            label91.Visible = false; label92.Visible = false; label93.Visible = false; label94.Visible = false; label95.Visible = false;
            siticoneButton40.Visible = false;
            siticoneTextBox11.Visible = false; siticoneTextBox12.Visible = false; siticoneTextBox13.Visible = false; siticoneTextBox14.Visible = false; siticoneTextBox16.Visible = false;
            siticonePictureBox26.Visible = false; siticonePictureBox32.Visible = false; siticonePictureBox33.Visible = false; siticonePictureBox34.Visible = false;
            siticoneCheckBox1.Visible = false;
            label96.Visible = false; label97.Visible = false; label98.Visible = false; label99.Visible = false;
            pictureBox27.Visible = false;
            label109.Visible = false; label110.Visible = false; label111.Visible = false; label112.Visible = false; label113.Visible = false; label114.Visible = false; label115.Visible = false; label116.Visible = false;
            siticoneCheckBox7.Visible = false; siticoneCheckBox8.Visible = false; siticoneCheckBox9.Visible = false; siticoneCheckBox10.Visible = false; siticoneCheckBox11.Visible = false; siticoneCheckBox12.Visible = false; siticoneCheckBox13.Visible = false;
            linkLabel22.Visible = false; linkLabel23.Visible = false; linkLabel24.Visible = false; linkLabel26.Visible = false;
            siticoneTextBox5.Visible = false;
            pictureBox28.Visible = false; siticoneButton63.Visible = false; siticoneButton63.Visible = false;
            siticoneTextBox4.Visible = false;
            label101.Visible = false; label102.Visible = false; label103.Visible = false; label104.Visible = false; label105.Visible = false; label106.Visible = false; label107.Visible = false; label108.Visible = false;
            siticoneComboBox1.Visible = false;
            siticoneNumericUpDown1.Visible = false; siticoneNumericUpDown2.Visible = false;
            siticoneCheckBox2.Visible = false; siticoneCheckBox3.Visible = false; siticoneCheckBox4.Visible = false; siticoneCheckBox5.Visible = false; siticoneCheckBox6.Visible = false;
            siticoneComboBox3.Visible = false;
            siticoneToggleSwitch6.Visible = false; siticoneToggleSwitch5.Visible = false; siticoneToggleSwitch4.Visible = false;
            label82.Visible = false; label83.Visible = false; label84.Visible = false; label86.Visible = false; label85.Visible = false;
            siticoneDateTimePicker1.Visible = false; siticoneToggleSwitch2.Visible = false; siticoneToggleSwitch1.Visible = false; siticoneToggleSwitch3.Visible = false;
            siticoneButton37.Visible = false;
            label45.Text = "Abonelikler";
            label46.Text = "Bal Nature aboneliklerinizi yönetin";

        }

        private void siticoneButton34_Click(object sender, EventArgs e)
        {
            label122.Visible = false;
            label119.Visible = false;
            label120.Visible = false;
            label121.Visible = false;
            siticoneTextBox8.BorderColor = Color.Black;
            siticoneTextBox9.BorderColor = Color.Black;
            siticoneTextBox10.BorderColor = Color.Black;
            label117.Visible = false;
            label118.Visible = false;
            siticoneButton65.Visible = false;
            siticoneButton66.Visible = false;
            siticoneTextBox6.Visible = false;
            siticoneTextBox5.Visible = false;
            label88.Visible = false; label90.Visible = false; label89.Visible = false;
            siticoneTextBox7.Visible = false; siticoneTextBox8.Visible = false; siticoneTextBox9.Visible = false; siticoneTextBox10.Visible = false;
            siticoneButton41.Visible = false;
            label100.Visible = false; siticoneButton42.Visible = false;

            siticoneButton67.Visible = false; siticoneButton68.Visible = false; siticoneButton69.Visible = false; siticoneButton70.Visible = false;
            siticoneCheckBox1.Visible = false;
            label91.Visible = false; label92.Visible = false; label93.Visible = false; label94.Visible = false; label95.Visible = false;
            siticoneButton40.Visible = false;
            label96.Visible = false; label97.Visible = false; label98.Visible = false; label99.Visible = false;
            siticoneTextBox11.Visible = false; siticoneTextBox12.Visible = false; siticoneTextBox13.Visible = false; siticoneTextBox14.Visible = false; siticoneTextBox16.Visible = false;
            siticonePictureBox26.Visible = false; siticonePictureBox32.Visible = false; siticonePictureBox33.Visible = false; siticonePictureBox34.Visible = false;
            pictureBox27.Visible = false;
            siticoneTextBox4.Visible = false;
            label82.Visible = false; label83.Visible = false; label84.Visible = false; label86.Visible = false; label85.Visible = false;
            siticoneDateTimePicker1.Visible = false; siticoneToggleSwitch2.Visible = false; siticoneToggleSwitch1.Visible = false; siticoneToggleSwitch3.Visible = false;
            siticoneButton37.Visible = false;
            label45.Text = "Bildirimler";
            label46.Text = "Bal Nature den gelen bildirimleri yönetin.";
            label101.Visible = true; label102.Visible = true; label103.Visible = true; label104.Visible = true; label105.Visible = true; label106.Visible = true; label107.Visible = true; label108.Visible = true;
            siticoneComboBox3.Visible = true;
            label109.Visible = false; label110.Visible = false; label111.Visible = false; label112.Visible = false; label113.Visible = false; label114.Visible = false; label115.Visible = false; label116.Visible = false;
            siticoneCheckBox7.Visible = false; siticoneCheckBox8.Visible = false; siticoneCheckBox9.Visible = false; siticoneCheckBox10.Visible = false; siticoneCheckBox11.Visible = false; siticoneCheckBox12.Visible = false; siticoneCheckBox13.Visible = false;
            linkLabel22.Visible = false; linkLabel23.Visible = false; linkLabel24.Visible = false; linkLabel26.Visible = false;
            siticoneToggleSwitch6.Visible = true; siticoneToggleSwitch5.Visible = true; siticoneToggleSwitch4.Visible = true;
            siticoneNumericUpDown1.Visible = true; siticoneNumericUpDown2.Visible = true;
            siticoneCheckBox2.Visible = true; siticoneCheckBox3.Visible = true; siticoneCheckBox4.Visible = true; siticoneCheckBox5.Visible = true; siticoneCheckBox6.Visible = true;
            pictureBox28.Visible = true; siticoneButton63.Visible = true; siticoneButton63.Visible = true;
            siticoneButton64.Visible = true;
        }

        private void siticoneButton31_Click_1(object sender, EventArgs e)
        {
            label122.Visible = false;
            label119.Visible = false;
            label120.Visible = false;
            label121.Visible = false;
            siticoneTextBox8.BorderColor = Color.Black;
            siticoneTextBox9.BorderColor = Color.Black;
            siticoneTextBox10.BorderColor = Color.Black;
            label117.Visible = false;
            label118.Visible = false;
            siticoneButton65.Visible = true;
            siticoneButton66.Visible = true;
            label100.Visible = false; siticoneButton42.Visible = false;
            siticoneTextBox6.Visible = false;
            pictureBox28.Visible = false; siticoneButton63.Visible = false; siticoneButton63.Visible = false;
            siticoneComboBox3.Visible = false;
            siticoneToggleSwitch6.Visible = false; siticoneToggleSwitch5.Visible = false; siticoneToggleSwitch4.Visible = false;
            siticoneTextBox5.Visible = false;
            label96.Visible = false; label97.Visible = false; label98.Visible = false; label99.Visible = false;

            siticoneButton67.Visible = false; siticoneButton68.Visible = false; siticoneButton69.Visible = false; siticoneButton70.Visible = false;
            siticoneCheckBox1.Visible = false;
            label101.Visible = false; label102.Visible = false; label103.Visible = false; label104.Visible = false; label105.Visible = false; label106.Visible = false; label107.Visible = false; label108.Visible = false;
            siticoneComboBox1.Visible = false;
            siticoneNumericUpDown1.Visible = false; siticoneNumericUpDown2.Visible = false;
            siticoneCheckBox2.Visible = false; siticoneCheckBox3.Visible = false; siticoneCheckBox4.Visible = false; siticoneCheckBox5.Visible = false; siticoneCheckBox6.Visible = false;
            siticoneButton64.Visible = false;
            label91.Visible = false; label92.Visible = false; label93.Visible = false; label94.Visible = false; label95.Visible = false;
            siticoneButton40.Visible = false;
            siticoneTextBox11.Visible = false; siticoneTextBox12.Visible = false; siticoneTextBox13.Visible = false; siticoneTextBox14.Visible = false; siticoneTextBox16.Visible = false;
            siticonePictureBox26.Visible = false; siticonePictureBox32.Visible = false; siticonePictureBox33.Visible = false; siticonePictureBox34.Visible = false;
            pictureBox27.Visible = false;
            siticoneTextBox4.Visible = false;
            label88.Visible = false; label90.Visible = false; label89.Visible = false;
            siticoneTextBox7.Visible = false; siticoneTextBox8.Visible = false; siticoneTextBox9.Visible = false; siticoneTextBox10.Visible = false;
            siticoneButton41.Visible = false;
            label82.Visible = false; label83.Visible = false; label84.Visible = false; label86.Visible = false; label85.Visible = false;
            siticoneDateTimePicker1.Visible = false; siticoneToggleSwitch2.Visible = false; siticoneToggleSwitch1.Visible = false; siticoneToggleSwitch3.Visible = false;
            siticoneButton37.Visible = false;
            label45.Text = "Gizlilik";
            label46.Text = "Gizlilik ayarlarınızı buradan değiştirin.";
            label109.Visible = true; label110.Visible = true; label111.Visible = true; label112.Visible = true; label113.Visible = true; label114.Visible = true; label115.Visible = true; label116.Visible = true;
            siticoneCheckBox7.Visible = true; siticoneCheckBox8.Visible = true; siticoneCheckBox9.Visible = true; siticoneCheckBox10.Visible = true; siticoneCheckBox11.Visible = true; siticoneCheckBox12.Visible = true; siticoneCheckBox13.Visible = true;
            linkLabel22.Visible = true; linkLabel23.Visible = true; linkLabel24.Visible = true; linkLabel26.Visible = true;
        }

        private void siticoneButton33_Click(object sender, EventArgs e)
        {
            label122.Visible = false;
            label119.Visible = false;
            label120.Visible = false;
            label121.Visible = false;
            siticoneTextBox8.BorderColor = Color.Black;
            siticoneTextBox9.BorderColor = Color.Black;
            siticoneTextBox10.BorderColor = Color.Black;
            label117.Visible = false;
            label118.Visible = false;
            siticoneButton65.Visible = false;
            siticoneButton67.Visible = false; siticoneButton68.Visible = false; siticoneButton69.Visible = false; siticoneButton70.Visible = false;
            siticoneButton66.Visible = false;
            siticoneTextBox6.Visible = false;

            label100.Visible = false; siticoneButton42.Visible = false;
            siticoneCheckBox1.Visible = false;
            pictureBox28.Visible = false; siticoneButton63.Visible = false; siticoneButton63.Visible = false;
            siticoneComboBox3.Visible = false;
            label109.Visible = false; label110.Visible = false; label111.Visible = false; label112.Visible = false; label113.Visible = false; label114.Visible = false; label115.Visible = false; label116.Visible = false;
            siticoneCheckBox7.Visible = false; siticoneCheckBox8.Visible = false; siticoneCheckBox9.Visible = false; siticoneCheckBox10.Visible = false; siticoneCheckBox11.Visible = false; siticoneCheckBox12.Visible = false; siticoneCheckBox13.Visible = false;
            linkLabel22.Visible = false; linkLabel23.Visible = false; linkLabel24.Visible = false; linkLabel26.Visible = false;
            siticoneToggleSwitch6.Visible = false; siticoneToggleSwitch5.Visible = false; siticoneToggleSwitch4.Visible = false;
            label96.Visible = false; label97.Visible = false; label98.Visible = false; label99.Visible = false;
            pictureBox27.Visible = false;
            label91.Visible = false; label92.Visible = false; label93.Visible = false; label94.Visible = false; label95.Visible = false;
            siticoneButton40.Visible = false;
            siticoneTextBox11.Visible = false; siticoneTextBox12.Visible = false; siticoneTextBox13.Visible = false; siticoneTextBox14.Visible = false; siticoneTextBox16.Visible = false;
            siticonePictureBox26.Visible = false; siticonePictureBox32.Visible = false; siticonePictureBox33.Visible = false; siticonePictureBox34.Visible = false;
            siticoneTextBox5.Visible = false;
            siticoneTextBox4.Visible = false;
            siticoneButton64.Visible = false;
            label101.Visible = false; label102.Visible = false; label103.Visible = false; label104.Visible = false; label105.Visible = false; label106.Visible = false; label107.Visible = false; label108.Visible = false;
            siticoneComboBox1.Visible = false;
            siticoneNumericUpDown1.Visible = false; siticoneNumericUpDown2.Visible = false;
            siticoneCheckBox2.Visible = false; siticoneCheckBox3.Visible = false; siticoneCheckBox4.Visible = false; siticoneCheckBox5.Visible = false; siticoneCheckBox6.Visible = false;

            label88.Visible = false; label90.Visible = false; label89.Visible = false;
            siticoneTextBox7.Visible = false; siticoneTextBox8.Visible = false; siticoneTextBox9.Visible = false; siticoneTextBox10.Visible = false;
            siticoneButton41.Visible = false;
            label82.Visible = false; label83.Visible = false; label84.Visible = false; label86.Visible = false; label85.Visible = false;
            siticoneDateTimePicker1.Visible = false; siticoneToggleSwitch2.Visible = false; siticoneToggleSwitch1.Visible = false; siticoneToggleSwitch3.Visible = false;
            siticoneButton37.Visible = false;
            label45.Text = "Başarımlar ve İlerlemeler";
            label46.Text = "İlerlemelerinizi takip edin ve ona göre ödüller kazanın.";
        }

        private void siticoneButton36_Click(object sender, EventArgs e)
        {
            label122.Visible = false;
            label119.Visible = false;
            label120.Visible = false;
            label121.Visible = false;
            siticoneTextBox8.BorderColor = Color.Black;
            siticoneTextBox9.BorderColor = Color.Black;
            siticoneTextBox10.BorderColor = Color.Black;
            label117.Visible = false;
            label118.Visible = false;
            siticoneButton65.Visible = false;
            siticoneButton66.Visible = false;
            siticoneButton64.Visible = false;
            siticoneTextBox6.Visible = false;
            label88.Visible = false; label90.Visible = false; label89.Visible = false;
            siticoneTextBox7.Visible = false; siticoneTextBox8.Visible = false; siticoneTextBox9.Visible = false; siticoneTextBox10.Visible = false;
            siticoneButton41.Visible = false;

            pictureBox28.Visible = false; siticoneButton63.Visible = false; siticoneButton63.Visible = false;
            label96.Visible = false; label97.Visible = false; label98.Visible = false; label99.Visible = false;
            label91.Visible = false; label92.Visible = false; label93.Visible = false; label94.Visible = false; label95.Visible = false;
            siticoneButton40.Visible = false;
            label101.Visible = false; label102.Visible = false; label103.Visible = false; label104.Visible = false; label105.Visible = false; label106.Visible = false; label107.Visible = false; label108.Visible = false;
            siticoneComboBox1.Visible = false;
            siticoneNumericUpDown1.Visible = false; siticoneNumericUpDown2.Visible = false;
            siticoneCheckBox2.Visible = false; siticoneCheckBox3.Visible = false; siticoneCheckBox4.Visible = false; siticoneCheckBox5.Visible = false; siticoneCheckBox6.Visible = false;
            label109.Visible = false; label110.Visible = false; label111.Visible = false; label112.Visible = false; label113.Visible = false; label114.Visible = false; label115.Visible = false; label116.Visible = false;
            siticoneCheckBox7.Visible = false; siticoneCheckBox8.Visible = false; siticoneCheckBox9.Visible = false; siticoneCheckBox10.Visible = false; siticoneCheckBox11.Visible = false; siticoneCheckBox12.Visible = false; siticoneCheckBox13.Visible = false;
            linkLabel22.Visible = false; linkLabel23.Visible = false; linkLabel24.Visible = false; linkLabel26.Visible = false;
            siticoneTextBox11.Visible = false; siticoneTextBox12.Visible = false; siticoneTextBox13.Visible = false; siticoneTextBox14.Visible = false; siticoneTextBox16.Visible = false;
            siticonePictureBox26.Visible = false; siticonePictureBox32.Visible = false; siticonePictureBox33.Visible = false; siticonePictureBox34.Visible = false;
            siticoneCheckBox1.Visible = false;
            label100.Visible = false; siticoneButton42.Visible = false;
            siticoneComboBox3.Visible = false;
            siticoneToggleSwitch6.Visible = false; siticoneToggleSwitch5.Visible = false; siticoneToggleSwitch4.Visible = false;
            pictureBox27.Visible = false;
            siticoneTextBox5.Visible = false;
            siticoneTextBox4.Visible = false;
            label82.Visible = false; label83.Visible = false; label84.Visible = false; label86.Visible = false; label85.Visible = false;
            siticoneDateTimePicker1.Visible = false; siticoneToggleSwitch2.Visible = false; siticoneToggleSwitch1.Visible = false; siticoneToggleSwitch3.Visible = false;
            siticoneButton37.Visible = false;
            label45.Text = "Hesabı yönet";
            label46.Text = "Hesabınızı silin,sıfırlayın ve yönetin.";
            siticoneButton67.Visible = true; siticoneButton68.Visible = true; siticoneButton69.Visible = true; siticoneButton70.Visible = true;
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox7_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region boş
        void verileriaskıyaalma()
        {

        }
        private void label113_Click(object sender, EventArgs e)
        {

        }

        private void label104_Click(object sender, EventArgs e)
        {

        }

        private void label103_Click(object sender, EventArgs e)
        {

        }

        private void siticoneCheckBox13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void siticoneCheckBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void siticoneCheckBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void siticoneCheckBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void siticoneToggleSwitch5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label100_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton45_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton46_Click(object sender, EventArgs e)
        {
            Form4 fnn = new Form4(2);
            fnn.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form4 fnn = new Form4(1);
            fnn.ShowDialog();
        }

        private void siticoneButton45_DoubleClick(object sender, EventArgs e)
        {
            Form4 fnn = new Form4(1);
            fnn.ShowDialog();
        }

        private void siticoneButton43_Click(object sender, EventArgs e)
        {
            Form4 fnn = new Form4(1);
            fnn.ShowDialog();
        }

        private void siticoneButton44_Click(object sender, EventArgs e)
        {
            Form4 fnn = new Form4(2);
            fnn.ShowDialog();
        }
        #endregion

        #region database
        void KayıtEkleDatabase(string newName, string connString)
        {
            DateTime sayı2 = new DateTime();
            Guid sayı = new Guid();
            int newProdID = 0;
            string newProdID2 = "";
            SqlXml newProdID3 = new SqlXml();
            string sql =
                "select dbo.functionID(@eposta)";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {
                    conn.Open();
                    newProdID = (Int32)cmd.ExecuteScalar();
                    ID = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }


                //---------------------------------------------------------------



                sql =
                   "select dbo.functionID2(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    ID2 = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                sql =
                   "select dbo.functionID3(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    ID3 = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                sql =
                   "select dbo.functionguidid(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    sayı = (Guid)cmd.ExecuteScalar();
                    Guidid = sayı;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                sql =
                  "select dbo.functionkayıttarihi(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    sayı2 = (DateTime)cmd.ExecuteScalar();
                    OluşturmaZamanı = sayı2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }




                //---------------------------------------------------------------



                sql =
                   "select dbo.functionbelgeler(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    belgeler = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }



                //---------------------------------------------------------------



                sql =
                   "select dbo.functionbildirimeposta(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    bildirimeposta = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }



                //---------------------------------------------------------------



                sql =
                   "select dbo.functionbildirimsayısı(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    bildirimsayısı = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                //---------------------------------------------------------------



                sql =
                   "select dbo.functioneklemesayısı(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    eklemesayısı = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionuygulamaaçıkkenbenihatırla(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    uygulamaaçıkkenbenihatırla = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }


                //---------------------------------------------------------------



                sql =
                   "select dbo.functionverilerisakla(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    verilerisakla = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionabonelikler(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    abonelikler = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionmasaüstübildirimler(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();

                    masaüstübildirimler = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionepostabildirimleri(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    epostabildirimleri = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionseazerdinleme(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    seazerdinleme = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functiongünlükbildirimtf(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    günlükbildirimtf = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionuyarıver(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    uyarıver = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionotomatikbildirimtemizleme(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    otomatikbildirimtemizleme = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionbildirimlersanladepodasaklansın(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    bildirimlersanladepodasaklansın = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionbildirimler2güngösterilsin(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    bildirimler2güngösterilsin = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionverilerimkaydedilsin(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    verilerimkaydedilsin = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functiondatabasekoruması(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    databasekoruması = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionverilerimleanalizeedilebilirsin(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    verilerimleanalizeedilebilirsin = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functiondiğerürünleriçiniyileştirmeler(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    diğerürünleriçiniyileştirmeler = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionverilerbizimlepaylaşılsın(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    verilerbizimlepaylaşılsın = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionüçüncütarafveriler(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    üçüncütarafveriler = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionkurumhesabı(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    kurumhesabı = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionsilindi(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    silindi = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------



                sql =
                   "select dbo.functionverileriincelenebilsin(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    verileriincelenebilsin = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                //---------------------------------------------------------------



                sql =
                   "select dbo.functionbaşlat(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID = (Int32)cmd.ExecuteScalar();
                    başlat = newProdID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functionAd(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    Ad = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                sql =
                  "select dbo.functionSoyad(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    Soyad = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------
                EPosta = newName;
                //---------------------------------------------------------------

                sql =
                  "select dbo.functiontelefon(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    telefon = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functionşifre(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    şifre = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functiondoğumgünü(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    doğumgünü = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functiondoğumayı(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    doğumayı = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functiondoğumyılı(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    doğumyılı = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functionaçıklayıcımetin(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    açıklayıcımetin = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functionwebsitesi(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    websitesi = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functiontwitter(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    twitter = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functionfacebook(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    facebook = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------
                sql =
                  "select dbo.functioneklemeler(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    eklemeler = (string)newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------
                sql =
                  "select dbo.functionbildirimler(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    bildirimler = (string)newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functionlinkedin(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    linkedin = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functioninstagram(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    instagram = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functionbildirimsesi(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    bildirimsesi = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                //---------------------------------------------------------------

                sql =
                  "select dbo.functionkaçgündebir(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    kaçgündebir = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                sql =
                  "select dbo.functiongündekaçkere(@eposta)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@eposta", SqlDbType.VarChar);
                cmd.Parameters["@eposta"].Value = newName;
                try
                {

                    newProdID2 = (string)cmd.ExecuteScalar();
                    gündekaçkere = newProdID2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }


            }
        }
        #endregion
    }
    public class CustomLifeSpanHandler : ILifeSpanHandler
    {
        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl,
                                  string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture,
                                  IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings,
                                  ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            // Yeni pencere oluşturulduğunda yapılması istenen işlemler burada gerçekleştirilir

            // Yeni pencereyi mevcut formda açmak için
            newBrowser = null;
            System.Diagnostics.Process.Start(targetUrl);
            // Yeni pencereyi başka bir formda açmak için
            // Form2 newForm = new Form2((ChromiumWebBrowser)chromiumWebBrowser);
            // newForm.Show();

            return true; // false döndürerek CefSharp'e yeni pencereyi otomatik olarak açmasını sağlayabilirsiniz.
        }
        bool ILifeSpanHandler.DoClose(IWebBrowser browserControl, IBrowser browser)
        { return false; }

        void ILifeSpanHandler.OnBeforeClose(IWebBrowser browserControl, IBrowser browser) { }

        void ILifeSpanHandler.OnAfterCreated(IWebBrowser browserControl, IBrowser browser) { }
        // Diğer ILifeSpanHandler metodlarını da uygulayabilirsiniz, ancak burada sadece OnBeforePopup örneği gösterilmektedir.
    }
}
