using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace BAL_Nature
{
    public partial class Form5 : Form
    {

        Form1 fff = new Form1();
        Timer p = new Timer();
        public Form5()
        {
            InitializeComponent();

            bool kontrol = InternetKontrol(); // Kontrol fonksiyonumuzu çağırdık
                                              // Eğer internet varsa true yoksa false değeri gelecek. Bunu if ile kontrol edelim
            if (kontrol == true)
            {

                IFirebaseConfig config = new FirebaseConfig
                {
                    AuthSecret = "txG0YPGu6DZWk6KgyWss2qAveKAGhpjlrzEybbda",
                    BasePath = "https://balnature-default-rtdb.firebaseio.co"
                };
                IFirebaseClient client;
                void Connection()
                {
                    client = new FireSharp.FirebaseClient(config);

                    if (client != null)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Maalesef Bal Nature'nin 2.13.22.1 sürümü internetsiz işlemleri desteklememektedir lütfen internete bağlanın.", "Bal Nature Connection Services");
                        this.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Maalesef Bal Nature'nin 2.13.22.1 sürümü internetsiz işlemleri desteklememektedir lütfen internete bağlanın.", "Bal Nature Connection Services");
                this.Close();
            }
            fff.Hide();

            p.Interval = 5000;
            p.Start();
            p.Tick += P_Tick;

        }

        private void P_Tick(object sender, EventArgs e)
        {

            p.Stop();
            this.Hide();
            fff.ShowDialog();


            Environment.Exit(0);

        }
        public bool InternetKontrol()
        {
            try
            {
                WebRequest request = WebRequest.Create("https://google.com");
                WebResponse response = request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}