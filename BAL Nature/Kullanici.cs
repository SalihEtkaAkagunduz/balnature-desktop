using System;
using System.Collections.Generic;

namespace BAL_Nature
{
    internal class Kullanici
    {
        public List<veriaktarimi> VeriListesi { get; set; }
        public List<bild> Bildirim { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Aciklama { get; set; }
        public string OlusturmaZamani { get; set; }
        public string Web { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string Email { get; set; }
        public long Tarih { get; set; }
        public int KayitSayisi { get; set; }
        public int ToplamOrtalama { get; set; }
        public int MetalOrtalama { get; set; }
        public int KagitOrtalama { get; set; }
        public int CamOrtalama { get; set; }
        public int PlastikOrtalama { get; set; }

        public Kullanici(
            List<veriaktarimi> veriListesi,
            List<bild> bildirim,
            string isim,
            string soyisim,
            string aciklama,
            string olusturmaZamani,
            string web,
            string twitter,
            string facebook,
            string linkedin,
            string instagram,
            string email,
            long tarih,
            int kayitSayisi,
            int toplamOrtalama,
            int metalOrtalama,
            int kagitOrtalama,
            int camOrtalama,
            int plastikOrtalama)
        {
            VeriListesi = veriListesi;
            Bildirim = bildirim;
            Isim = isim;
            Soyisim = soyisim;
            Aciklama = aciklama;
            OlusturmaZamani = olusturmaZamani;
            Web = web;
            Twitter = twitter;
            Facebook = facebook;
            Linkedin = linkedin;
            Instagram = instagram;
            Email = email;
            Tarih = tarih;
            KayitSayisi = kayitSayisi;
            ToplamOrtalama = toplamOrtalama;
            MetalOrtalama = metalOrtalama;
            KagitOrtalama = kagitOrtalama;
            CamOrtalama = camOrtalama;
            PlastikOrtalama = plastikOrtalama;
        }

        public Kullanici()
        {
        }
    }
}
