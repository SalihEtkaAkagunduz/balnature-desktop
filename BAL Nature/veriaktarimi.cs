using System;

namespace BAL_Nature
{
    internal class veriaktarimi
    {
        public string Ad { get; set; }
        public string Açiklama { get; set; }
        public int Tur { get; set; }
        public float Kaydıdegerlendir { get; set; }
        public long Tarih { get; set; }
        public string Faliyetalanı { get; set; }
        public int Toplamatık { get; set; }
        public int Metala { get; set; }
        public int Cama { get; set; }
        public int Kağıta { get; set; }
        public int Plastika { get; set; }
        public int Metalg { get; set; }
        public int Camg { get; set; }
        public int Kağıtg { get; set; }
        public int Platikg { get; set; }

        public veriaktarimi()
        {
        }

        public veriaktarimi(string ad, string açiklama, int tur, long tarih, string faliyetalanı, int toplamatık, int metala, int cama, int kağıta, int plastika, int metalg, int camg, int kağıtg, int platikg, float kaydıdegerlendir)
        {
            Ad = ad;
            Açiklama = açiklama;
            Tur = tur;
            Tarih = tarih;
            Faliyetalanı = faliyetalanı;
            Toplamatık = toplamatık;
            Metala = metala;
            Cama = cama;
            Kağıta = kağıta;
            Plastika = plastika;
            Metalg = metalg;
            Camg = camg;
            Kağıtg = kağıtg;
            Platikg = platikg;
            Kaydıdegerlendir = kaydıdegerlendir;
        }
    }
}
