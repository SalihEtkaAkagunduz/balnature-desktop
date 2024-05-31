using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;
using FireSharp.Config;
using FirebaseAdmin;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telerik.WinForms.Documents.FormatProviders.Html.Parsing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Telerik.WinControls.Styles;
using static Org.BouncyCastle.Math.EC.ECCurve;
using FirebaseNetAdmin.Firebase.Auth;
using CefSharp.DevTools.IO;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace BAL_Nature
{

    public partial class Form4 : Form
    {
        int sayı1;//işlem basamağı
        int sayı3;//random E-posta doğrulama kodu 
        int sayı4;//e posta bildirim hizmeti
        string metin4 = "";//şifre
        string metin1 = "";//E-Posta
        string metin2 = "";//Ad
        string metin5 = "";//bölge
        string metin3 = "";//soyad
        string metin6 = "";//Gün
        string metin7 = "";//Ay
        string metin8 = "";//Yıl
        string metin9 = "";//Açıklayıcımetin

        public Form4(int sayı)
        {

            InitializeComponent();
            StreamWriter sw = new StreamWriter("C:\\ProgramData\\SEAzer\\BALNature\\mevc.txt");
            sw.Close();
            File.WriteAllText("C:\\ProgramData\\SEAzer\\BALNature\\kuruluş.txt", DateTime.Now.ToShortDateString());

            timer1.Interval = 2;
            timer1.Start();
            sayı1 = sayı;

            label15.Visible = false;
            label12.Visible = false;
        }
        SqlConnection connect;
        SqlCommand command;
        SqlDataReader reader;
        int returnv;
        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }

        int SimdikiWidth = 486;
        int SimdikiHeight = 679;

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }
        int sayı2 = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayı2 == 0)
            {
                siticoneWinProgressIndicator1.Start();
                siticoneWinProgressIndicator1.Visible = true;
                pictureBox4.Visible = true;
                label4.Visible = true;
            }
            if (sayı2 == 4000)
            {
                pictureBox15.Visible = false;
                siticoneTextBox7.Visible = false;
                siticoneCheckBox1.Visible = false;

                label16.Visible = false;
                label17.Visible = false;
                linkLabel10.Visible = false;
                linkLabel9.Visible = false;
                pictureBox28.Visible = false;
                pictureBox29.Visible = false;
                pictureBox30.Visible = false;

                label18.Visible = false;
                linkLabel8.Visible = false;
                siticoneComboBox2.Visible = false;
                siticoneComboBox3.Visible = false;
                siticoneComboBox4.Visible = false;
                siticoneTextBox6.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                pictureBox18.Visible = false;
                pictureBox19.Visible = false;
                siticoneTextBox7.BorderColor = Color.Red;
                pictureBox20.Visible = false;
                pictureBox21.Visible = false;
                pictureBox22.Visible = false;
                siticoneTextBox7.BorderColor = Color.Black;
                pictureBox23.Visible = false;
                pictureBox24.Visible = false;
                pictureBox11.Visible = false;
                pictureBox25.Visible = false;
                pictureBox26.Visible = false;
                pictureBox27.Visible = false;
                siticoneComboBox3.BorderColor = Color.Black; siticoneComboBox4.BorderColor = Color.Black; siticoneTextBox6.BorderColor = Color.Black;
                siticoneTextBox4.Visible = false;
                siticoneTextBox5.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = false;
                pictureBox14.Visible = false;
                pictureBox15.Visible = false;
                pictureBox14.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                pictureBox16.Visible = false;
                pictureBox17.Visible = false;
                siticoneTextBox3.BorderColor = Color.Black;
                label9.Visible = false;
                siticoneTextBox1.BorderColor = Color.Black;
                label5.Visible = false;
                timer1.Stop();
                siticoneWinProgressIndicator1.Visible = false;
                pictureBox4.Visible = false;
                siticoneWinProgressIndicator1.Stop();
                label4.Visible = false;

                siticoneButton1.Location = new Point(328, 260);
                if (sayı1 == 1)
                {
                    siticoneTextBox1.Text = "";
                    label2.Visible = true;
                    siticoneCircleButton1.Visible = false;
                    label8.Visible = false;
                    label6.Visible = false; label7.Visible = false; siticoneTextBox3.Visible = false; pictureBox10.Visible = false; pictureBox9.Visible = false; pictureBox11.Visible = false;
                    pictureBox2.Visible = false;
                    linkLabel7.Visible = false;
                    siticoneComboBox1.Visible = false;
                    siticoneTextBox2.Visible = false;
                    label2.Visible = true;
                    label3.Text = "Hesabınız yok mu?";
                    linkLabel1.Text = "Bir tane oluştur!";
                    label2.Text = "Oturum Aç";
                    siticoneTextBox1.PlaceholderText = "E-Posta , telefon veya BalNatureID";
                    label3.Visible = true;
                    linkLabel1.Visible = true;
                    linkLabel5.Visible = false;
                    linkLabel6.Visible = false;
                    linkLabel2.Visible = true;
                    linkLabel2.Text = "Kullanıcı adını unuttuysan ne yapman gerek hemen incele !";
                    siticoneButton2.Visible = true;
                    siticoneTextBox1.Visible = true;
                    siticoneButton3.Visible = false;
                    sayı2 = 0;


                }
                if (sayı1 == 2)
                {
                    label2.Visible = true;
                    siticoneCircleButton1.Visible = false;
                    label8.Visible = false;
                    label6.Visible = false; label7.Visible = false; siticoneTextBox3.Visible = false; pictureBox10.Visible = false; pictureBox9.Visible = false; pictureBox11.Visible = false;
                    pictureBox2.Visible = false;
                    linkLabel7.Visible = false;
                    siticoneTextBox1.Text = "";
                    siticoneTextBox1.Visible = true;
                    siticoneComboBox1.Visible = false;
                    siticoneTextBox2.Visible = false;
                    siticoneButton2.Visible = false; siticoneTextBox1.PlaceholderText = "birisi@example.com";
                    ; linkLabel5.Visible = true;
                    linkLabel6.Visible = true;
                    siticoneButton3.Visible = true;
                    label2.Text = "Hesap Oluştur"; label3.Visible = false; linkLabel1.Visible = false; linkLabel2.Visible = false;
                    sayı2 = 0;

                }
                if (sayı1 == 3)
                {
                    label2.Visible = true;
                    siticoneCircleButton1.Visible = false;
                    label8.Visible = false;
                    label6.Visible = false; label7.Visible = false; siticoneTextBox3.Visible = false; pictureBox10.Visible = false; pictureBox9.Visible = false; pictureBox11.Visible = false;
                    pictureBox2.Visible = true;
                    linkLabel7.Visible = true;
                    siticoneComboBox1.Visible = true;
                    siticoneTextBox2.Visible = true;
                    siticoneButton2.Visible = false; siticoneTextBox1.PlaceholderText = "birisi@example.com"; siticoneTextBox1.Visible = false;
                    ; linkLabel5.Visible = false;
                    linkLabel6.Visible = true;
                    siticoneButton3.Visible = true;
                    label2.Text = "Hesap Oluştur"; label3.Visible = false; linkLabel1.Visible = false; linkLabel2.Visible = false;
                    sayı2 = 0;

                }
                if (sayı1 == 4)
                {
                    label8.Text = "Hesabınızla kullanmak istediğiniz parolayı girin.";
                    label7.Text = "Parola oluşturma";
                    label2.Visible = false;
                    siticoneCircleButton1.Visible = true;
                    label6.Text = metin1.Trim();
                    pictureBox11.Visible = true;
                    label8.Visible = true;
                    label6.Visible = true; label7.Visible = true; siticoneTextBox3.Visible = true; pictureBox10.Visible = true; pictureBox9.Visible = true; pictureBox11.Visible = true;
                    pictureBox2.Visible = false;
                    linkLabel7.Visible = false;
                    siticoneComboBox1.Visible = false;
                    siticoneTextBox2.Visible = false;
                    siticoneButton2.Visible = false; siticoneTextBox1.PlaceholderText = "birisi@example.com"; siticoneTextBox1.Visible = false;
                    linkLabel5.Visible = false;
                    linkLabel6.Visible = false;
                    siticoneButton3.Visible = false;
                    label2.Text = "Hesap Oluştur"; label3.Visible = false; linkLabel1.Visible = false; linkLabel2.Visible = false;
                    sayı2 = 0;

                }
                if (sayı1 == 5)
                {
                    siticoneTextBox4.Visible = true;
                    siticoneTextBox5.Visible = true;
                    pictureBox12.Visible = true;
                    pictureBox13.Visible = true;
                    pictureBox14.Visible = true;
                    pictureBox15.Visible = true;
                    pictureBox16.Visible = true;
                    pictureBox17.Visible = true;
                    label8.Text = "Bu uygulamayı kullanabilmeniz için biraz daha bilgiye \nihtiyacımız var.";
                    label7.Text = "Adınız nedir?";
                    label2.Visible = false;
                    siticoneCircleButton1.Visible = true;
                    label6.Text = metin1.Trim();
                    label8.Visible = true;
                    label6.Visible = true; label7.Visible = true; siticoneTextBox3.Visible = false; pictureBox10.Visible = true; pictureBox9.Visible = true; pictureBox11.Visible = true;
                    pictureBox2.Visible = false;
                    linkLabel7.Visible = false;
                    siticoneComboBox1.Visible = false;
                    siticoneTextBox2.Visible = false;
                    siticoneButton2.Visible = false; siticoneTextBox1.PlaceholderText = "birisi@example.com"; siticoneTextBox1.Visible = false;
                    linkLabel5.Visible = false;
                    linkLabel6.Visible = false;
                    siticoneButton3.Visible = false;
                    label2.Text = "Adınız nedir?"; label3.Visible = false; linkLabel1.Visible = false; linkLabel2.Visible = false;
                    sayı2 = 0;
                    siticoneButton1.Location = new Point(328, 323);

                }
                if (sayı1 == 6)
                {
                    siticoneComboBox2.Visible = true;
                    siticoneComboBox3.Visible = true;
                    siticoneComboBox4.Visible = true;
                    siticoneTextBox6.Visible = true;
                    label13.Visible = true;
                    label14.Visible = true;
                    pictureBox18.Visible = true;
                    pictureBox19.Visible = true;
                    pictureBox20.Visible = true;
                    pictureBox21.Visible = true;
                    pictureBox22.Visible = true;
                    pictureBox23.Visible = true;
                    pictureBox24.Visible = true;
                    pictureBox25.Visible = true;
                    pictureBox26.Visible = true;
                    pictureBox27.Visible = true;
                    siticoneTextBox4.Visible = false;
                    siticoneTextBox5.Visible = false;
                    pictureBox12.Visible = false;
                    pictureBox13.Visible = false;
                    pictureBox14.Visible = false;
                    pictureBox15.Visible = false;
                    pictureBox16.Visible = false;
                    pictureBox17.Visible = false;
                    label8.Text = "Bu uygulamayı kullanabilmeniz için biraz daha bilgiye \nihtiyacımız var. Doğum tarihiniz, yaşınıza uygun ayarları \nsağlamamıza yardımcı olur.";
                    label7.Text = "Doğum tarihiniz nedir?";
                    label2.Visible = false;
                    siticoneCircleButton1.Visible = true;
                    label6.Text = metin1.Trim();
                    label8.Visible = true;
                    label6.Visible = true; label7.Visible = true; siticoneTextBox3.Visible = false; pictureBox10.Visible = true; pictureBox9.Visible = true; pictureBox11.Visible = false;
                    pictureBox2.Visible = false;
                    linkLabel7.Visible = false;
                    siticoneComboBox1.Visible = false;
                    siticoneTextBox2.Visible = false;
                    siticoneButton2.Visible = false; siticoneTextBox1.PlaceholderText = "birisi@example.com"; siticoneTextBox1.Visible = false;
                    linkLabel5.Visible = false;
                    linkLabel6.Visible = false;
                    siticoneButton3.Visible = false;
                    label2.Text = "Adınız nedir?"; label3.Visible = false; linkLabel1.Visible = false; linkLabel2.Visible = false;
                    sayı2 = 0;
                    siticoneButton1.Location = new Point(328, 384);

                }
                if (sayı1 == 7)
                {
                    siticoneTextBox7.Visible = true;
                    siticoneCheckBox1.Visible = true;
                    label12.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    linkLabel10.Visible = true;
                    linkLabel9.Visible = true;
                    pictureBox28.Visible = true;
                    pictureBox29.Visible = true;
                    pictureBox30.Visible = true;

                    label8.Text = "Lütfen E-Posta adrasine gönderdiğimiz kodu girin. E-\npostayı almadıysanız, gereksiz e-posta klasörünüzü \nkontrol edin.";
                    label7.Text = "E-postayı doğrula";
                    label2.Visible = false;
                    siticoneCircleButton1.Visible = true;
                    label6.Text = metin1.Trim();
                    label8.Visible = true;
                    label6.Visible = true; label7.Visible = true; siticoneTextBox3.Visible = false; pictureBox10.Visible = true; pictureBox9.Visible = true; pictureBox11.Visible = false;
                    pictureBox2.Visible = false;
                    linkLabel7.Visible = false;
                    siticoneComboBox1.Visible = false;
                    siticoneTextBox2.Visible = false;
                    siticoneButton2.Visible = false; siticoneTextBox1.PlaceholderText = "birisi@example.com"; siticoneTextBox1.Visible = false;
                    linkLabel5.Visible = false;
                    linkLabel6.Visible = false;
                    siticoneButton3.Visible = false;
                    label2.Text = "Adınız nedir?"; label3.Visible = false; linkLabel1.Visible = false; linkLabel2.Visible = false;
                    sayı2 = 0;
                    siticoneButton1.Location = new Point(328, 384);

                }
                if (sayı1 == 8)
                {

                    label8.Text = "İşleminiz tamamlandı artık rahatça uygulamanıza giriş yapıp  \r\nkullanabilirsiniz";
                    label7.Text = "İşleminiz tamamlandı!";
                    label2.Visible = false;
                    siticoneCircleButton1.Visible = true;
                    label6.Text = metin1.Trim();
                    label8.Visible = true;
                    label6.Visible = true; label7.Visible = true; siticoneTextBox3.Visible = false; pictureBox10.Visible = true; pictureBox9.Visible = true; pictureBox11.Visible = true;
                    pictureBox2.Visible = false;
                    linkLabel7.Visible = false;
                    siticoneComboBox1.Visible = false;
                    siticoneTextBox2.Visible = false;
                    siticoneButton2.Visible = false; siticoneTextBox1.PlaceholderText = "birisi@example.com"; siticoneTextBox1.Visible = false;
                    linkLabel5.Visible = false;
                    linkLabel6.Visible = false;
                    siticoneButton3.Visible = false;
                    label2.Text = "Adınız nedir?"; label3.Visible = false; linkLabel1.Visible = false; linkLabel2.Visible = false;
                    sayı2 = 0;
                    siticoneButton1.Location = new Point(328, 384);

                }
                if (sayı1 == 9)
                {

                    label8.Text = "SMS kaydı ve doğrulaması için gerek API malesef şu an \nçalışmıyor lütfen sonra tekrar dene yada bizimle iletişime \ngeç";
                    label7.Text = "Bir hata oluştu !";
                    label2.Visible = false;
                    siticoneCircleButton1.Visible = true;
                    label6.Text = metin1.Trim();
                    label8.Visible = true;
                    label6.Visible = true; label7.Visible = true; siticoneTextBox3.Visible = false; pictureBox10.Visible = true; pictureBox9.Visible = true; pictureBox11.Visible = true;
                    pictureBox2.Visible = false;
                    linkLabel7.Visible = false;
                    siticoneComboBox1.Visible = false;
                    siticoneTextBox2.Visible = false;
                    siticoneButton2.Visible = false; siticoneTextBox1.PlaceholderText = "birisi@example.com"; siticoneTextBox1.Visible = false;
                    linkLabel5.Visible = false;
                    linkLabel6.Visible = false;
                    siticoneButton3.Visible = false;
                    label2.Text = "Adınız nedir?"; label3.Visible = false; linkLabel1.Visible = false; linkLabel2.Visible = false;
                    sayı2 = 0;


                }
                if (sayı1 == 10)
                {

                    label2.Visible = true;
                    siticoneCircleButton1.Visible = false;
                    label8.Visible = false;
                    label6.Visible = false; label7.Visible = false; siticoneTextBox3.Visible = false; pictureBox10.Visible = false; pictureBox9.Visible = false; pictureBox11.Visible = false;
                    pictureBox2.Visible = false;
                    linkLabel7.Visible = false;
                    siticoneComboBox1.Visible = false;
                    siticoneTextBox2.Visible = false;
                    label2.Visible = true;
                    label2.Text = "Oturum Aç";
                    siticoneTextBox1.Text = "";
                    siticoneButton3.Visible = true;
                    siticoneTextBox1.PlaceholderText = "Parolanızı Girin";
                    label3.Visible = true;
                    linkLabel2.Text = "Şifreni unuttuysan ne yapman gerektiğini incele!";
                    linkLabel1.Visible = true;
                    linkLabel5.Visible = false;
                    label3.Text = "Şifreni mi unuttunu?";
                    linkLabel1.Text = "Şimdi sıfırla!";
                    linkLabel6.Visible = false;
                    linkLabel2.Visible = true;
                    siticoneButton2.Visible = true;
                    siticoneTextBox1.Visible = true;

                    sayı2 = 0;


                }
                if (sayı1 == 11)
                {

                    label8.Text = "İşleminiz tamamlandı artık rahatça uygulamanızı \nkullanabilirsiniz";
                    label7.Text = "İşleminiz tamamlandı!";
                    label2.Visible = false;
                    siticoneCircleButton1.Visible = true;
                    label6.Text = metin1.Trim();
                    label8.Visible = true;
                    label6.Visible = true; label7.Visible = true; siticoneTextBox3.Visible = false; pictureBox10.Visible = true; pictureBox9.Visible = true; pictureBox11.Visible = true;
                    pictureBox2.Visible = false;
                    linkLabel7.Visible = false;
                    siticoneComboBox1.Visible = false;
                    siticoneTextBox2.Visible = false;
                    siticoneButton2.Visible = false; siticoneTextBox1.PlaceholderText = "birisi@example.com"; siticoneTextBox1.Visible = false;
                    linkLabel5.Visible = false;
                    linkLabel6.Visible = false;
                    siticoneButton3.Visible = false;
                    label2.Text = "Adınız nedir?"; label3.Visible = false; linkLabel1.Visible = false; linkLabel2.Visible = false;
                    sayı2 = 0;
                    siticoneButton1.Location = new Point(328, 384);

                }
            }
            else
            {
                sayı2 += 20;

            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sayı1 = 2;
            timer1.Start();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            if (sayı1 == 2)
            {
                sayı1 = 1;
                timer1.Start();
            }
            if (sayı1 == 10)
            {
                sayı1 = 1;
                timer1.Start();
            }


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://balnatureerasmus.wixsite.com/balnature");
        }

        private void linkLabel6_Click(object sender, EventArgs e)
        {
            Process.Start("https://accounts.google.com");
        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {













        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sayı1 = 3;
            timer1.Start();
        }
        
        private async void siticoneButton1_Click(object sender, EventArgs e)
        {
            label15.Visible = false;
            label12.Visible = false;
            if (sayı1 == 1)
            {
                if (siticoneTextBox1.Text.EndsWith(".com") && siticoneTextBox1.Text.Contains("@") && siticoneTextBox1.Text.Length > 10)
                {//oturum sçmsk için kullsnıcı vsr mı

                    var config2 = new FirebaseAuthConfig
                    {
                        ApiKey = "AIzaSyATfIezNXb9MdNuTczda2uDkw4BJiLsG28",
                        AuthDomain = "balnature.firebaseapp.com",
                        Providers = new FirebaseAuthProvider[]
                        {
                                    // Add and configure individual providers
                                    new GoogleProvider().AddScopes(metin1),
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
                       
                        
                         FetchUserProvidersResult userCredential = await client2.FetchSignInMethodsForEmailAsync(siticoneTextBox1.Text);
                        if (userCredential.UserExists == true)
                        {
                            label5.Visible = false;
                            siticoneTextBox1.BorderColor = Color.Black;
                            metin1 = siticoneTextBox1.Text;
                            sayı1 = 10;
                            timer1.Start();
                        }
                        else
                        {
                            label5.Text = "Bu Eposta adresi sistemimize kayıtlı değil";
                            label5.Visible = true;
                            siticoneTextBox1.BorderColor = Color.Red;
                            label18.Visible = false;
                        }



                    }
                    catch {MessageBox.Show("Bir Hata Oluştu", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                     
                    }

                else
                {
                    label5.Text = "E-Posta adresinizi birisi@example.com biçiminde girin";
                    label5.Visible = true;
                    siticoneTextBox1.BorderColor = Color.Red;
                }


            }
            else if (sayı1 == 2)
            {
                if (siticoneTextBox1.Text.EndsWith(".com") && siticoneTextBox1.Text.Contains("@") && siticoneTextBox1.Text.Length > 10)
                {
                    var config2 = new FirebaseAuthConfig
                    {
                        ApiKey = "AIzaSyATfIezNXb9MdNuTczda2uDkw4BJiLsG28",
                        AuthDomain = "balnature.firebaseapp.com",
                        Providers = new FirebaseAuthProvider[]
                       {
                                    // Add and configure individual providers
                                    new GoogleProvider().AddScopes(metin1),
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


                        FetchUserProvidersResult userCredential = await client2.FetchSignInMethodsForEmailAsync(siticoneTextBox1.Text);
                        if (userCredential.UserExists == true)
                        {
                            label5.Text = "Bu Eposta adresi alınmış";
                            label5.Visible = true;
                            siticoneTextBox1.BorderColor = Color.Red;
                        }
                        else
                        {
                            label5.Visible = false;
                            siticoneTextBox1.BorderColor = Color.Black;
                            sayı1 = 4;
                            metin1 = siticoneTextBox1.Text;
                            timer1.Start();
                        }



                    }
                    catch
                    {
                        MessageBox.Show("Bir Hata Oluştu", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                 

                
                else
                {
                    label5.Text = "E-Posta adresinizi birisi@example.com biçiminde girin";

                    label5.Visible = true;
                    siticoneTextBox1.BorderColor = Color.Red;
                }


            }
            else if (sayı1 == 3)
            {



                sayı1 = 9;

                timer1.Start();



            }
            else if (sayı1 == 8)
            {


                sayı1 = 1;
                this.Close();



            }
            else if (sayı1 == 4)
            {
                string aa = siticoneTextBox3.Text.Trim();
                if (aa.Length >= 8)
                {
                    metin4 = siticoneTextBox3.Text;
                    sayı1 = 5;
                    timer1.Start();
                }
                else
                {
                    label9.Visible = true;
                    siticoneTextBox3.BorderColor = Color.Red;
                }
            }
            else if (sayı1 == 5)
            {
                string aa = siticoneTextBox4.Text.Trim();
                string aa1 = siticoneTextBox5.Text.Trim();
                if (aa.Length > 0)
                {
                    if (aa1.Length > 0)
                    {
                        metin2 = siticoneTextBox4.Text;
                        metin3 = siticoneTextBox5.Text;
                        metin9 = siticoneTextBox6.Text;
                        sayı1 = 6;
                        timer1.Start();
                    }
                    else
                    {
                        label11.Visible = true;
                        siticoneTextBox5.BorderColor = Color.Red;
                    }
                }
                else
                {
                    label10.Visible = true;
                    siticoneTextBox4.BorderColor = Color.Red;
                    if (aa1.Length == 0)
                    {
                        label11.Visible = true;
                        siticoneTextBox5.BorderColor = Color.Red;
                    }
                }
            }
            else if (sayı1 == 6)
            {

                if (siticoneComboBox3.SelectedValue == "Gün" || siticoneComboBox4.SelectedValue == "Ay" || siticoneComboBox3.Text == "Gün" || siticoneComboBox3.SelectedValue == "Gün" || siticoneComboBox4.SelectedValue == "Ay" || String.IsNullOrEmpty(siticoneTextBox6.Text))
                {
                    label15.Visible = true; siticoneComboBox3.BorderColor = Color.Red; siticoneComboBox4.BorderColor = Color.Red; siticoneTextBox6.BorderColor = Color.Red;
                }
                else
                {
                    metin5 = siticoneComboBox2.Text;
                    metin6 = siticoneComboBox3.Text;
                    metin7 = siticoneComboBox4.Text;
                    metin8 = siticoneTextBox6.Text;
                    Random rastgele = new Random();
                    sayı3 = rastgele.Next(100000, 999999);

                    MailMessage mesaj = new MailMessage();
                    mesaj.From = new MailAddress("balnature.erasmus@outlook.com");
                    mesaj.IsBodyHtml = true;
                    mesaj.To.Add(metin1);
                    mesaj.To.Add("balnature.erasmus@outlook.com");
                    mesaj.Subject = "Bal Nature Doğrulama kodu";
                    mesaj.Body = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">\r\n <head>\r\n  <meta charset=\"UTF-8\">\r\n  <meta content=\"width=device-width, initial-scale=1\" name=\"viewport\">\r\n  <meta name=\"x-apple-disable-message-reformatting\">\r\n  <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n  <meta content=\"telephone=no\" name=\"format-detection\">\r\n  <title>New message</title><!--[if (mso 16)]>\r\n    <style type=\"text/css\">\r\n    a {text-decoration: none;}\r\n    </style>\r\n    <![endif]--><!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]--><!--[if gte mso 9]>\r\n<xml>\r\n    <o:OfficeDocumentSettings>\r\n    <o:AllowPNG></o:AllowPNG>\r\n    <o:PixelsPerInch>96</o:PixelsPerInch>\r\n    </o:OfficeDocumentSettings>\r\n</xml>\r\n<![endif]--><!--[if !mso]><!-- -->\r\n  <link href=\"https://fonts.googleapis.com/css2?family=Exo+2:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap\" rel=\"stylesheet\"><!--<![endif]-->\r\n  <style type=\"text/css\">\r\n.rollover:hover .rollover-first {\r\n\tmax-height:0px!important;\r\n\tdisplay:none!important;\r\n}\r\n.rollover:hover .rollover-second {\r\n\tmax-height:none!important;\r\n\tdisplay:block!important;\r\n}\r\n.rollover div {\r\n\tfont-size:0;\r\n}\r\nu ~ div img + div > div {\r\n\tdisplay:none;\r\n}\r\n#outlook a {\r\n\tpadding:0;\r\n}\r\nspan.MsoHyperlink,\r\nspan.MsoHyperlinkFollowed {\r\n\tcolor:inherit;\r\n\tmso-style-priority:99;\r\n}\r\na.es-button {\r\n\tmso-style-priority:100!important;\r\n\ttext-decoration:none!important;\r\n}\r\na[x-apple-data-detectors] {\r\n\tcolor:inherit!important;\r\n\ttext-decoration:none!important;\r\n\tfont-size:inherit!important;\r\n\tfont-family:inherit!important;\r\n\tfont-weight:inherit!important;\r\n\tline-height:inherit!important;\r\n}\r\n.es-desk-hidden {\r\n\tdisplay:none;\r\n\tfloat:left;\r\n\toverflow:hidden;\r\n\twidth:0;\r\n\tmax-height:0;\r\n\tline-height:0;\r\n\tmso-hide:all;\r\n}\r\n/*.es-header-body a:hover {\r\n\tcolor:#000000!important;\r\n}\r\n*/\r\n/*.es-content-body a:hover {\r\n\tcolor:#391484!important;\r\n}\r\n*/\r\n/*.es-footer-body a:hover {\r\n\tcolor:#391484!important;\r\n}\r\n*/\r\n/*.es-infoblock a:hover {\r\n\tcolor:#cccccc!important;\r\n}\r\n*/\r\n.es-button-border:hover a.es-button, .es-button-border:hover button.es-button {\r\n\tcolor:#000000!important;\r\n}\r\n.es-menu.es-table-not-adapt td a:hover,\r\na.es-button:hover {\r\n\ttext-decoration:underline!important;\r\n}\r\n@media only screen and (max-width:600px) {.es-m-p15r { padding-right:15px!important } .es-m-p15l { padding-left:15px!important } .es-m-p30t { padding-top:30px!important } .es-m-p20r { padding-right:20px!important } .es-m-p20b { padding-bottom:20px!important } .es-m-p20l { padding-left:20px!important } .es-m-p30b { padding-bottom:30px!important } .es-m-p10b { padding-bottom:10px!important } *[class=\"gmail-fix\"] { display:none!important } p, a { line-height:150%!important } h1, h1 a { line-height:120%!important } h2, h2 a { line-height:120%!important } h3, h3 a { line-height:120%!important } h4, h4 a { line-height:120%!important } h5, h5 a { line-height:120%!important } h6, h6 a { line-height:120%!important } .es-header-body p { } .es-content-body p { } .es-footer-body p { } .es-infoblock p { } h1 { font-size:28px!important; text-align:left } h2 { font-size:24px!important; text-align:left } h3 { font-size:20px!important; text-align:left } h4 { font-size:24px!important; text-align:left } h5 { font-size:20px!important; text-align:left } h6 { font-size:16px!important; text-align:left } .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a { font-size:28px!important } .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a { font-size:24px!important } .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a { font-size:20px!important } .es-header-body h4 a, .es-content-body h4 a, .es-footer-body h4 a { font-size:24px!important } .es-header-body h5 a, .es-content-body h5 a, .es-footer-body h5 a { font-size:20px!important } .es-header-body h6 a, .es-content-body h6 a, .es-footer-body h6 a { font-size:16px!important } .es-menu td a { font-size:16px!important } .es-header-body p, .es-header-body a { font-size:16px!important } .es-content-body p, .es-content-body a { font-size:16px!important } .es-footer-body p, .es-footer-body a { font-size:16px!important } .es-infoblock p, .es-infoblock a { font-size:12px!important } .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3, .es-m-txt-c h4, .es-m-txt-c h5, .es-m-txt-c h6 { text-align:center!important } .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3, .es-m-txt-r h4, .es-m-txt-r h5, .es-m-txt-r h6 { text-align:right!important } .es-m-txt-j, .es-m-txt-j h1, .es-m-txt-j h2, .es-m-txt-j h3, .es-m-txt-j h4, .es-m-txt-j h5, .es-m-txt-j h6 { text-align:justify!important } .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3, .es-m-txt-l h4, .es-m-txt-l h5, .es-m-txt-l h6 { text-align:left!important } .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img, .es-m-txt-r .rollover:hover .rollover-second, .es-m-txt-c .rollover:hover .rollover-second, .es-m-txt-l .rollover:hover .rollover-second { display:inline!important } .es-m-txt-r .rollover div, .es-m-txt-c .rollover div, .es-m-txt-l .rollover div { line-height:0!important; font-size:0!important } .es-spacer { display:inline-table } a.es-button, button.es-button { font-size:20px!important } .es-m-fw, .es-m-fw.es-fw, .es-m-fw .es-button { display:block!important } .es-m-il, .es-m-il .es-button, .es-social, .es-social td, .es-menu { display:inline-block!important } .es-adaptive table, .es-left, .es-right { width:100%!important } .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header { width:100%!important; max-width:600px!important } .adapt-img:not([src*=\"default-img\"]) { width:100%!important; height:auto!important } .es-mobile-hidden, .es-hidden { display:none!important } .es-desk-hidden { width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important; display:table-row!important } tr.es-desk-hidden { display:table-row!important } table.es-desk-hidden { display:table!important } td.es-desk-menu-hidden { display:table-cell!important } .es-menu td { width:1%!important } table.es-table-not-adapt, .esd-block-html table { width:auto!important } .es-social td { padding-bottom:10px } .m-c-p16r { padding-right:8vw } a.es-button, button.es-button { display:inline-block!important } .es-button-border { display:inline-block!important } .h-auto { height:auto!important } }\r\n</style>\r\n </head>\r\n <body style=\"width:100%;height:100%;padding:0;Margin:0\">\r\n  <div class=\"es-wrapper-color\" style=\"background-color:#12022F\"><!--[if gte mso 9]>\r\n\t\t\t<v:background xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"t\">\r\n\t\t\t\t<v:fill type=\"tile\" src=\"https://qcnjpx.stripocdn.email/content/guids/CABINET_7550686899481ac1ae35908cede0c283/images/group_10_DPF.png\" color=\"#12022f\" origin=\"0.5, 0\" position=\"0.5, 0\"></v:fill>\r\n\t\t\t</v:background>\r\n\t\t<![endif]-->\r\n   <table class=\"es-wrapper\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" background=\"https://qcnjpx.stripocdn.email/content/guids/CABINET_7550686899481ac1ae35908cede0c283/images/group_10_DPF.png\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-image:url(https://qcnjpx.stripocdn.email/content/guids/CABINET_7550686899481ac1ae35908cede0c283/images/group_10_DPF.png);background-repeat:no-repeat;background-position:center top;background-color:#12022F\">\r\n     <tr>\r\n      <td valign=\"top\" style=\"padding:0;Margin:0\">\r\n       <table class=\"es-footer\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important;background-color:transparent;background-repeat:repeat;background-position:center top\">\r\n         <tr>\r\n          <td class=\"es-m-p15r es-m-p15l\" align=\"center\" style=\"padding:0;Margin:0\">\r\n           <table class=\"es-footer-body\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#FFFFFF\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:640px\">\r\n             <tr>\r\n              <td align=\"left\" style=\"padding:0;Margin:0;padding-top:30px;padding-right:40px;padding-left:40px\">\r\n               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                 <tr>\r\n                  <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr class=\"es-mobile-hidden\">\r\n                      <td align=\"center\" height=\"15\" style=\"padding:0;Margin:0\"></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table></td>\r\n             </tr>\r\n             <tr>\r\n              <td class=\"es-m-p30t es-m-p20b es-m-p20r es-m-p20l\" align=\"left\" bgcolor=\"#ffffff\" style=\"Margin:0;padding-left:35px;padding-bottom:5px;padding-right:40px;padding-top:10px;background-color:#ffffff;border-radius:20px\"><!--[if mso]><table style=\"width:565px\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style=\"width:154px\" valign=\"top\"><![endif]-->\r\n               <table cellpadding=\"0\" cellspacing=\"0\" align=\"left\" class=\"es-left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\">\r\n                 <tr>\r\n                  <td class=\"es-m-p20b\" align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:124px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0;font-size:0px\"><img class=\"adapt-img\" src=\"https://qcnjpx.stripocdn.email/content/guids/CABINET_43ee2483e137a8661cb4e2da8c179d9852c940a68684cf6d2c71965b19a087bb/images/simplemobiletools.png\" alt style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\" width=\"107\"></td>\r\n                     </tr>\r\n                   </table></td>\r\n                  <td class=\"es-hidden\" style=\"padding:0;Margin:0;width:30px\"></td>\r\n                 </tr>\r\n               </table><!--[if mso]></td><td style=\"width:333px\" valign=\"top\"><![endif]-->\r\n               <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-left\" align=\"left\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left\">\r\n                 <tr>\r\n                  <td align=\"left\" class=\"es-m-p20b\" style=\"padding:0;Margin:0;width:333px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr>\r\n                      <td align=\"left\" class=\"h-auto\" height=\"47\" style=\"padding:0;Margin:0;padding-left:10px;padding-top:15px\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:24px;letter-spacing:0;color:#4b4b4b;font-size:16px\">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SEAZER SOFTWARE&nbsp;</p></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table><!--[if mso]></td><td style=\"width:30px\"></td><td style=\"width:48px\" valign=\"top\"><![endif]-->\r\n               <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-right\" align=\"right\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right\">\r\n                 <tr>\r\n                  <td align=\"left\" style=\"padding:0;Margin:0;width:48px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0;font-size:0px\"><a target=\"_blank\" class=\"rollover\" href=\"\" style=\"mso-line-height-rule:exactly;text-decoration:underline;color:#391484;font-size:16px\"><img class=\"rollover-first\" src=\"https://qcnjpx.stripocdn.email/content/guids/CABINET_7550686899481ac1ae35908cede0c283/images/menu.png\" alt style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\" width=\"30\">\r\n                        <div style=\"font-size:0;mso-hide:all\">\r\n                         <img width=\"30\" class=\"rollover-second\" style=\"display:none;font-size:18px;border:0;outline:none;text-decoration:none;max-height:0px\" src=\"https://qcnjpx.stripocdn.email/content/guids/CABINET_7550686899481ac1ae35908cede0c283/images/menu_hover.png\" alt>\r\n                        </div></a></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table><!--[if mso]></td></tr></table><![endif]--></td>\r\n             </tr>\r\n           </table></td>\r\n         </tr>\r\n       </table>\r\n       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important\">\r\n         <tr>\r\n          <td class=\"es-m-p15r es-m-p15l\" align=\"center\" style=\"padding:0;Margin:0\">\r\n           <table bgcolor=\"#FFFFFF\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:640px\">\r\n             <tr>\r\n              <td align=\"left\" style=\"padding:0;Margin:0;padding-top:30px;padding-right:40px;padding-left:40px\">\r\n               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                 <tr>\r\n                  <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr>\r\n                      <td align=\"center\" height=\"15\" style=\"padding:0;Margin:0\"></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table></td>\r\n             </tr>\r\n             <tr>\r\n              <td class=\"es-m-p30t es-m-p30b es-m-p20r es-m-p20l\" align=\"left\" bgcolor=\"#ffffff\" style=\"padding:40px;Margin:0;background-color:#ffffff;border-radius:20px 20px 0px 0px\">\r\n               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                 <tr>\r\n                  <td align=\"left\" style=\"padding:0;Margin:0;width:560px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0\"><h1 style=\"Margin:0;font-family:'Exo 2', sans-serif;mso-line-height-rule:exactly;letter-spacing:0;font-size:36px;font-style:normal;font-weight:bold;line-height:43px;color:#000000\">Doğrulama Kodu&nbsp;</h1></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0;padding-top:20px;font-size:0px\"><img class=\"adapt-img\" src=\"https://qcnjpx.stripocdn.email/content/guids/CABINET_158d1ee0d3579aa1456484b5bebda300/images/following_2.gif\" alt style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\" width=\"560\"></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0;padding-top:30px\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:27px;letter-spacing:0;color:#666666;font-size:18px\">Merhaba<strong> Sayın Kullanıcı;</strong>!</p></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0;padding-top:5px\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:27px;letter-spacing:0;color:#666666;font-size:18px\"></p><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:27px;letter-spacing:0;color:#666666;font-size:18px\">Doğrulama kodunuz:&nbsp;&nbsp;</p></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0\"><h2 style=\"Margin:0;font-family:'Exo 2', sans-serif;mso-line-height-rule:exactly;letter-spacing:0;font-size:28px;font-style:normal;font-weight:bold;line-height:34px !important;color:#000000\">" + sayı3.ToString() + "</h2></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:27px;letter-spacing:0;color:#666666;font-size:18px\">'tır lütfen kimseyle paylaşmayın</p></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0;padding-top:5px\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:27px;letter-spacing:0;color:#666666;font-size:18px\">Uygulamayı başlatmak yada işlemlerini internetten devam etmek</p><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:27px;letter-spacing:0;color:#666666;font-size:18px\">&nbsp;için lütfen tıklayın.</p></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0;padding-top:30px\"><!--[if mso]><a   target=\"_blank\" hidden>\r\n\t<v:roundrect xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" esdevVmlButton   \r\n                style=\"height:52px; v-text-anchor:middle; width:236px\" arcsize=\"50%\" strokecolor=\"#ffdda9\" strokeweight=\"2px\" fillcolor=\"#ffdda9\">\r\n\t\t<w:anchorlock></w:anchorlock>\r\n\t\t<center style='color:#000000; font-family:\"Exo 2\", sans-serif; font-size:20px; font-weight:400; line-height:20px;  mso-text-raise:1px'>Webde Devam Et</center>\r\n\t</v:roundrect></a>\r\n<![endif]--><!--[if !mso]><!-- --><span class=\"es-button-border msohide\" style=\"border-style:solid;border-color:#FFDDA9;background:#FFDDA9;border-width:0px 0px 2px 0px;display:inline-block;border-radius:30px;width:auto;mso-hide:all\"><a   class=\"es-button\" target=\"_blank\" style=\"mso-style-priority:100 !important;text-decoration:none !important;mso-line-height-rule:exactly;color:#000000;font-size:20px;padding:15px 30px 15px 30px;display:inline-block;background:#FFDDA9;border-radius:30px;font-family:'Exo 2', sans-serif;font-weight:normal;font-style:normal;line-height:24px;width:auto;text-align:center;letter-spacing:0;mso-padding-alt:0;mso-border-alt:10px solid #FFDDA9\">Webde Devam Et</a></span><!--<![endif]--></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table></td>\r\n             </tr>\r\n             <tr>\r\n              <td class=\"es-m-p30t es-m-p30b es-m-p20r es-m-p20l\" align=\"left\" bgcolor=\"#f9f9f9\" style=\"padding:40px;Margin:0;background-color:#f9f9f9;border-radius:0px 0px 20px 20px\">\r\n               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                 <tr>\r\n                  <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:27px;letter-spacing:0;color:#666666;font-size:18px\">Bizi ve ekibimizi diğer tüm platformlardan takip etmeyi unutma&nbsp;</p><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:27px;letter-spacing:0;color:#666666;font-size:18px\">sizin desteğinizle büyüyüoruz</p></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0;padding-top:15px;font-size:0\">\r\n                       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-table-not-adapt es-social\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                         <tr>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Facebook\" src=\"https://qcnjpx.stripocdn.email/content/assets/img/social-icons/logo-black/facebook-logo-black.png\" alt=\"Fb\" height=\"32\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Twitter\" src=\"https://qcnjpx.stripocdn.email/content/assets/img/social-icons/logo-black/twitter-logo-black.png\" alt=\"Tw\" height=\"32\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Instagram\" src=\"https://qcnjpx.stripocdn.email/content/assets/img/social-icons/logo-black/instagram-logo-black.png\" alt=\"Inst\" height=\"32\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Youtube\" src=\"https://qcnjpx.stripocdn.email/content/assets/img/social-icons/logo-black/youtube-logo-black.png\" alt=\"Yt\" height=\"32\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Telegram\" src=\"https://qcnjpx.stripocdn.email/content/assets/img/messenger-icons/logo-black/telegram-logo-black.png\" alt=\"Telegram\" height=\"32\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"TikTok\" src=\"https://qcnjpx.stripocdn.email/content/assets/img/social-icons/logo-black/tiktok-logo-black.png\" alt=\"Tt\" height=\"32\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0\"><img title=\"Pinterest\" src=\"https://qcnjpx.stripocdn.email/content/assets/img/social-icons/logo-black/pinterest-logo-black.png\" alt=\"P\" height=\"32\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                         </tr>\r\n                       </table></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" style=\"padding:0;Margin:0;padding-top:30px\"><!--[if mso]><a href=\"\" target=\"_blank\" hidden>\r\n\t<v:roundrect xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" esdevVmlButton href=\"\" \r\n                style=\"height:52px; v-text-anchor:middle; width:457px\" arcsize=\"50%\" strokecolor=\"#ffdda9\" strokeweight=\"2px\" fillcolor=\"#ffdda9\">\r\n\t\t<w:anchorlock></w:anchorlock>\r\n\t\t<center style='color:#000000; font-family:\"Exo 2\", sans-serif; font-size:20px; font-weight:400; line-height:20px;  mso-text-raise:1px'>Diğer Sosyal Medya Hesaplarımıza Göz At</center>\r\n\t</v:roundrect></a>\r\n<![endif]--><!--[if !mso]><!-- --><span class=\"msohide es-button-border\" style=\"border-style:solid;border-color:#FFDDA9;background:#FFDDA9;border-width:0px 0px 2px 0px;display:inline-block;border-radius:30px;width:auto;mso-hide:all\"><a href=\"\" class=\"es-button msohide\" target=\"_blank\" style=\"mso-style-priority:100 !important;text-decoration:none !important;mso-line-height-rule:exactly;color:#000000;font-size:20px;padding:15px 30px 15px 30px;display:inline-block;background:#FFDDA9;border-radius:30px;font-family:'Exo 2', sans-serif;font-weight:normal;font-style:normal;line-height:24px;width:auto;text-align:center;letter-spacing:0;mso-padding-alt:0;mso-border-alt:10px solid #FFDDA9;mso-hide:all\">Diğer Sosyal Medya Hesaplarımıza Göz At</a></span><!--<![endif]--></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table></td>\r\n             </tr>\r\n             <tr>\r\n              <td align=\"left\" style=\"padding:0;Margin:0;padding-top:30px;padding-right:40px;padding-left:40px\">\r\n               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                 <tr>\r\n                  <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr>\r\n                      <td align=\"center\" height=\"15\" style=\"padding:0;Margin:0\"></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table></td>\r\n             </tr>\r\n             <tr>\r\n              <td class=\"es-m-p30t es-m-p30b\" align=\"left\" bgcolor=\"#ffffff\" style=\"padding:0;Margin:0;padding-top:40px;padding-bottom:40px;background-color:#ffffff;border-radius:20px\">\r\n               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                 <tr>\r\n                  <td class=\"es-m-p20l es-m-p20r\" align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;padding-right:40px;padding-left:40px;width:640px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr>\r\n                      <td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0\"><h1 style=\"Margin:0;font-family:'Exo 2', sans-serif;mso-line-height-rule:exactly;letter-spacing:0;font-size:36px;font-style:normal;font-weight:bold;line-height:43px;color:#000000\">Uygulamamaızı Alın</h1></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0;padding-top:40px;font-size:0\">\r\n                       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-table-not-adapt es-social\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                         <tr>\r\n                          <td align=\"center\" valign=\"top\" class=\"es-m-p10b\" style=\"padding:0;Margin:0;padding-right:30px\"><img title=\"AppStore\" src=\"https://qcnjpx.stripocdn.email/content/guids/CABINET_2b317663e817a90f786fc8c89a5d00a7/images/appstore.png\" alt=\"AppStore\" height=\"48\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                          <td align=\"center\" valign=\"top\" class=\"es-m-p10b\" style=\"padding:0;Margin:0;padding-right:30px\"><img title=\"Windows Store\" src=\"https://qcnjpx.stripocdn.email/content/guids/CABINET_2b317663e817a90f786fc8c89a5d00a7/images/windowsstore.png\" alt=\"Windows Store\" height=\"48\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0\"><img title=\"Google Play\" src=\"https://qcnjpx.stripocdn.email/content/guids/CABINET_2b317663e817a90f786fc8c89a5d00a7/images/googleplay.png\" alt=\"Google Play\" height=\"48\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                         </tr>\r\n                       </table></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0;padding-top:15px\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:27px;letter-spacing:0;color:#666666;font-size:18px\">Ürünlerimiz tüm hakları saklıdır paylaşmak yaymak yada kopyalamak kesinlikle yasaktır.<br></p></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table></td>\r\n             </tr>\r\n             <tr>\r\n              <td align=\"left\" style=\"padding:0;Margin:0;padding-top:30px;padding-right:40px;padding-left:40px\">\r\n               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                 <tr>\r\n                  <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr>\r\n                      <td align=\"center\" height=\"15\" style=\"padding:0;Margin:0\"></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table></td>\r\n             </tr>\r\n           </table></td>\r\n         </tr>\r\n       </table>\r\n       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-footer\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important;background-color:transparent;background-repeat:repeat;background-position:center top\">\r\n         <tr>\r\n          <td class=\"es-m-p15r es-m-p15l\" align=\"center\" style=\"padding:0;Margin:0\">\r\n           <table class=\"es-footer-body\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:640px\">\r\n             <tr>\r\n              <td class=\"es-m-p30t es-m-p30b es-m-p20r es-m-p20l\" align=\"left\" bgcolor=\"#ffffff\" style=\"padding:40px;Margin:0;background-color:#ffffff;border-radius:20px\">\r\n               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                 <tr>\r\n                  <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr>\r\n                      <td align=\"center\" class=\"es-m-txt-l\" style=\"padding:0;Margin:0;font-size:0px\" height=\"30\"><img src=\"https://qcnjpx.stripocdn.email/content/guids/CABINET_43ee2483e137a8661cb4e2da8c179d9852c940a68684cf6d2c71965b19a087bb/images/simplemobiletools.png\" alt style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\" width=\"128\"></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" class=\"es-m-txt-l\" style=\"padding:0;Margin:0;padding-top:20px;font-size:0\">\r\n                       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-table-not-adapt es-social\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                         <tr>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;padding-right:15px\"><img title=\"Facebook\" src=\"https://qcnjpx.stripocdn.email/content/assets/img/social-icons/logo-black/facebook-logo-black.png\" alt=\"Fb\" width=\"32\" height=\"32\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;padding-right:15px\"><img title=\"Twitter\" src=\"https://qcnjpx.stripocdn.email/content/assets/img/social-icons/logo-black/twitter-logo-black.png\" alt=\"Tw\" width=\"32\" height=\"32\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;padding-right:15px\"><img title=\"Instagram\" src=\"https://qcnjpx.stripocdn.email/content/assets/img/social-icons/logo-black/instagram-logo-black.png\" alt=\"Inst\" width=\"32\" height=\"32\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                          <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0\"><img title=\"Youtube\" src=\"https://qcnjpx.stripocdn.email/content/assets/img/social-icons/logo-black/youtube-logo-black.png\" alt=\"Yt\" width=\"32\" height=\"32\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></td>\r\n                         </tr>\r\n                       </table></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" class=\"es-m-txt-l\" style=\"padding:0;Margin:0;padding-top:15px\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:24px;letter-spacing:0;color:#666666;font-size:16px\">Bu proje 2023 tarihinde SEAZER Software tarafından yapılmıştı.&nbsp;<br>SEAZER® Bursa Anadolu Lisesinde hizmet veren bir yazılım ekibidir.</p></td>\r\n                     </tr>\r\n                     <tr>\r\n                      <td align=\"center\" class=\"es-m-txt-l\" style=\"padding:0;Margin:0;padding-top:10px\"><p style=\"Margin:0;mso-line-height-rule:exactly;font-family:'Exo 2', sans-serif;line-height:24px;letter-spacing:0;color:#666666;font-size:16px\"><a target=\"_blank\" href=\"\" style=\"mso-line-height-rule:exactly;text-decoration:underline;color:#391484;font-size:16px\">İncele</a></p></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table></td>\r\n             </tr>\r\n             <tr>\r\n              <td align=\"left\" style=\"padding:0;Margin:0;padding-top:30px;padding-right:40px;padding-left:40px\">\r\n               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                 <tr>\r\n                  <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\">\r\n                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr class=\"es-mobile-hidden\">\r\n                      <td align=\"center\" height=\"15\" style=\"padding:0;Margin:0\"></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table></td>\r\n             </tr>\r\n           </table></td>\r\n         </tr>\r\n       </table>\r\n       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important\">\r\n         <tr>\r\n          <td align=\"center\" style=\"padding:0;Margin:0\">\r\n           <table bgcolor=\"transparent\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:640px\">\r\n             <tr>\r\n              <td align=\"left\" style=\"Margin:0;padding-top:40px;padding-bottom:40px;padding-right:20px;padding-left:20px\">\r\n               <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                 <tr>\r\n                  <td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:600px\">\r\n                   <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">\r\n                     <tr>\r\n                      <td class=\"es-infoblock made_with\" align=\"center\" style=\"padding:0;Margin:0;font-size:0px\"><a target=\"_blank\" utm_source=templates&utm_medium=email&utm_campaign=gadgets_6&utm_content=share_your_wishlists_for_a_bonus\" style=\"mso-line-height-rule:exactly;text-decoration:underline;color:#CCCCCC;font-size:12px\"><img src=\"https://qcnjpx.stripocdn.email/content/guids/CABINET_43ee2483e137a8661cb4e2da8c179d9852c940a68684cf6d2c71965b19a087bb/images/simplemobiletools.png\" alt width=\"125\" style=\"display:block;font-size:18px;border:0;outline:none;text-decoration:none\"></a></td>\r\n                     </tr>\r\n                   </table></td>\r\n                 </tr>\r\n               </table></td>\r\n             </tr>\r\n           </table></td>\r\n         </tr>\r\n       </table></td>\r\n     </tr>\r\n   </table>\r\n  </div>\r\n </body>\r\n</html>";
                    SmtpClient a = new SmtpClient();
                    a.Credentials = new System.Net.NetworkCredential("balnature.erasmus@outlook.com", "S234432s");
                    a.Port = 587;
                    a.Host = "smtp-mail.outlook.com";
                    a.EnableSsl = true;
                    object userState = mesaj;
                    try
                    {
                        a.SendAsync(mesaj, (object)mesaj);
                    }
                    catch (SmtpException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
                    }
                    sayı1 = 7;
                    timer1.Start();
                }
            }
            else if (sayı1 == 7)
            {
                string aa = siticoneTextBox7.Text.Trim();
                if (aa.Length > 0)
                {
                    if (siticoneTextBox7.Text == sayı3.ToString())
                    {
                        if (siticoneCheckBox1.Checked == true)
                        {
                            sayı4 = 1;
                        }
                        else
                        {
                            sayı4 = 0;
                        }
                        try
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
                                    new GoogleProvider().AddScopes(metin1),
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
                                    var userCredential = await client2.CreateUserWithEmailAndPasswordAsync(metin1, metin4);
                                    var user = userCredential.User;
                                    uid = user.Uid;








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




                                                  



                                                    List<veriaktarimi> v = new List<veriaktarimi>();
                                                    veriaktarimi ver = new veriaktarimi("varsayılan", "veri", 1, (long)111, "ev", 0, 0, 0, 0, 0, 0, 0, 0, 0, 3.5f);
                                                    v.Add(ver);

                                                    List<bild> v2 = new List<bild>();




                                                    DateTime date = new DateTime();
                                                    long l;
                                                    bild ver2 = new bild(0, "Mehaba ilk girişinizi yaptınız.", "Mehaba ilk girişinizi yaptınız.", "Mehaba ilk girişinizi yaptınız.", "123132", 0, 0, 0);
                                                    v2.Add(ver2);
                                                    Kullanici kullanici = new Kullanici(v, v2, metin2, metin3,metin6+"/"+metin7+"/"+metin8, "", "", "", "", "", "", metin1, (long)98707, 1, 0, 0, 0, 0, 0);


                                                    Class3 ss = new Class3("dasf");
                                                    response = await client3.SetAsync("kullanicilar/" + uid + "/", kullanici);
                                                    result = response.ResultAs<Kullanici>();

                                                    FileStream fs = File.Create(@"C:\ProgramData\SEAzer\BALNature\mevcutkullanıcı.txt");
                                                    //C'dekiExportReports klasörünün içine Report adında bir metin dosyası oluşturur.
                                                    fs.Close();
                                                    File.WriteAllText("C:\\ProgramData\\SEAzer\\BALNature\\mevcutkullanıcı.txt", metin1);


                                                     
                                                    uid = user.Uid;

                                                    FileStream fs2 = File.Create(@"C:\ProgramData\SEAzer\BALNature\uid.txt");
                                                    //C'dekiExportReports klasörünün içine Report adında bir metin dosyası oluşturur.
                                                    fs2.Close();
                                                    File.WriteAllText("C:\\ProgramData\\SEAzer\\BALNature\\uid.txt", uid);


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
                        catch (Exception)
                        {
                            MessageBox.Show("İnternete bağlı olduğunuza emin misiniz? Eğer BAğlıysanız lütfen bizle iletişşime geçin", "Bal Nature Error Services", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        label18.Text = "Girdiğiniz kod yanlış! Lütfen tekrar deneyin..";
                        label18.Visible = true;
                        siticoneTextBox7.BorderColor = Color.Red;
                    }
                }
            }
            else if (sayı1 == 10)
            {


                var config2 = new FirebaseAuthConfig
                {
                    ApiKey = "AIzaSyATfIezNXb9MdNuTczda2uDkw4BJiLsG28",
                    AuthDomain = "balnature.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[]
                       {
                                    // Add and configure individual providers
                                    new GoogleProvider().AddScopes(metin1),
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


                    var userCredential = await client2.SignInWithEmailAndPasswordAsync(metin1,siticoneTextBox1.Text);
                    sayı1 = 11;
                         timer1.Start();
                    File.WriteAllText(@"C:\ProgramData\SEAzer\\BALNature\mevcutkullanıcı.txt", metin1);
                    Firebase.Auth.User user = userCredential.User;
                    uid = user.Uid;

                    FileStream fs2 = File.Create(@"C:\ProgramData\SEAzer\BALNature\uid.txt");
                    //C'dekiExportReports klasörünün içine Report adında bir metin dosyası oluşturur.
                    fs2.Close();
                    File.WriteAllText("C:\\ProgramData\\SEAzer\\BALNature\\uid.txt", uid);


                }
                catch
                {
                    label5.Text = "Şifre yanlış";
                 label5.Visible = true;
                   siticoneTextBox1.BorderColor = Color.Red;
            }
            //if (AddProductCategory2(metin1, "Data Source=SQL5110.site4now.net;Initial Catalog=db_a9845f_balnature;User Id=db_a9845f_balnature_admin;Password=S234432s;") == siticoneTextBox1.Text)
            //    {
            //        sayı1 = 11;
            //        timer1.Start();
            //        File.WriteAllText(@"C:\ProgramData\SEAzer\\BALNature\mevcutkullanıcı.txt", metin1);
            //    }
            //    else
            //    {
            //        label5.Text = "Şifre yanlış";
            //        label5.Visible = true;
            //        siticoneTextBox1.BorderColor = Color.Red;
            //    }
            //label2.Visible = true;
            //siticoneCircleButton1.Visible = false;
            //label8.Visible = false;
            //label6.Visible = false; label7.Visible = false; siticoneTextBox3.Visible = false; pictureBox10.Visible = false; pictureBox9.Visible = false; pictureBox11.Visible = false;
            //pictureBox2.Visible = false;
            //linkLabel7.Visible = false;
            //siticoneComboBox1.Visible = false;
            //siticoneTextBox2.Visible = false;
            //label2.Visible = true;
            //label2.Text = "Oturum Aç";
            //siticoneTextBox1.Text = "";
            //siticoneTextBox1.PlaceholderText = "Parolanızı Girin";
            //label3.Visible = true;
            //linkLabel2.Text = "Şifreni unuttuysan ne yapman gerektiğini incele!";
            //linkLabel1.Visible = true;
            //linkLabel5.Visible = false;
            //label3.Text = "Şifrenizi mi unuttunuz?";
            //linkLabel1.Text = "Şimdi sıfırla!";
            //linkLabel6.Visible = false;
            //linkLabel2.Visible = true;
            //siticoneButton2.Visible = true;
            //siticoneTextBox1.Visible = true;
            //siticoneButton3.Visible = false;
            //sayı2 = 0;
        }
            else if (sayı1 == 11)
            {
                this.Close();
            }
            else
            {
                label18.Text = "Bu kısım gereklidir.";
                label18.Visible = true;
                siticoneTextBox7.BorderColor = Color.Red;
            }
        }
        public void bağlantı()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }
            else
            {
                connect.Close();
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
        static public int AddProductCategory(string newName, string connString)
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
                    Console.WriteLine(ex.Message);
                }
            }
            return (int)newProdID;
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
                    Console.WriteLine(ex.Message);
                }
            }
            return (string)newProdID;
        }
        private void siticoneCircleButton1_Click(object sender, EventArgs e)
        {
            if (sayı1 == 4)
            {
                sayı1 = 2;
                timer1.Start();
            }
            if (sayı1 == 5)
            {
                sayı1 = 4;
                timer1.Start();
            }
            if (sayı1 == 6)
            {
                sayı1 = 5;
                timer1.Start();
            }
            if (sayı1 == 7)
            {
                sayı1 = 6;
                timer1.Start();
            }
            if (sayı1 == 9)
            {
                sayı1 = 2;
                timer1.Start();
            }
            if (sayı1 == 8)
            {
                sayı1 = 7;
                timer1.Start();
            }
        }
    }
}

