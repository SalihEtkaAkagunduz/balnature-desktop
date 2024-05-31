using System;

namespace BAL_Nature
{
    internal class bild
    {
        public int Id { get; set; }
        public string Açıklama { get; set; }
        public string Kısaaçıklama { get; set; }
        public string Konu { get; set; }
        public string Tarih { get; set; }
        public int Tür { get; set; }
        public int Durum { get; set; }
        public int Sil { get; set; }

        public bild(int id, string açıklama, string kısaaçıklama, string konu, string tarih, int tür, int durum, int sil)
        {
            Id = id;
            Açıklama = açıklama;
            Kısaaçıklama = kısaaçıklama;
            Konu = konu;
            Tarih = tarih;
            Tür = tür;
            Durum = durum;
            Sil = sil;
        }

        public bild()
        {
        }
    }
}
