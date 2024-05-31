using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BAL_Nature
{
    public partial class Form12 : Form
    {
        List<kayıtsınıfı> aa;
        public Form12(string a)
        {
            InitializeComponent();
            List<kayıtsınıfı> Data2 =  Newtonsoft.Json.JsonConvert.DeserializeObject<List<kayıtsınıfı>>(a);
            aa = Data2;
            List<kayıtsınıfı> empList = new List<kayıtsınıfı>();
            foreach (var item in Data2)
            {
                empList.Add(item);
            }
            
            

           
                var xEle = new XElement("Kayıt",
                            from emp in empList
                            select new XElement("Veri",
                                         new XAttribute("KayıtBaşlığı", emp.kayıtbaşlıkx),
                                           new XElement("Kayıt-Açıklaması", emp.kayıtaçıklamax),
                                           new XElement("Kayıt-Türü", emp.kayıttürx),
                                           new XElement("Konum", emp.kayıtalanıx),
                                           new XElement("Toplam-Atık-kg", emp.toplamatıkx),
                                           new XElement("Metal-Atık-kg", emp.metalatıkx),
                                           new XElement("Cam-Atık-kg", emp.camatıkx),
                                           new XElement("Kağıt-Atık-kg", emp.kağıtatıkx),
                                           new XElement("Plastik-Atık-kg", emp.plastikatıkx),
                                           new XElement("Toplam-Atık-Oran", emp.toplamatıkoranx),
                                           new XElement("Evsel-Atık-Oran", emp.evselatıkorax),
                                           new XElement("Metal-Atık-Oran", emp.metalatıkoranx),
                                           new XElement("Kağıt-Atık-Oran", emp.kağıtatıkoranx),
                                           new XElement("Cam-Atık-Oran", emp.camatıkoranx),
                                           new XElement("Plastik-Atık-Oran", emp.plastikatıkoranx),
                                           new XElement("GD-Oran", emp.geridönüştürülenatığıntoplamatığaoranıx),
                                           new XElement("GD-Metal", emp.gdmetal),
                                           new XElement("GD-Cam", emp.gdcam),
                                           new XElement("GD-Kağıt", emp.gdkağıt),
                                           new XElement("GD-Plastik", emp.gdplastik),
                                           new XElement("GD-Metal-Oranı", emp.gdmetaloran),
                                           new XElement("GD-Cam-Oran", emp.gdcamoran),
                                           new XElement("GD-Kağıt-Oranı", emp.gdkağıtoran),
                                           new XElement("GD-Plastik-Oranı", emp.gdplastikoran),
                                           new XElement("Değer", emp.kayıtdeğerlendirme),
                                           new XElement("Tarih", emp.zamanx)
                                           

                                       ));

                richTextBox1.Text = xEle.ToString();
                 
           
            
        }
    

         
    }
}
