//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarkodSatışSistemi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kullanici
    {
        public int Id { get; set; }
        public string adSoyad { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public Nullable<bool> Satis { get; set; }
        public Nullable<bool> Rapor { get; set; }
        public Nullable<bool> Stok { get; set; }
        public Nullable<bool> UrunGiris { get; set; }
        public Nullable<bool> ayarlar { get; set; }
        public Nullable<bool> Fiyatguncelleme { get; set; }
        public Nullable<bool> Yedekleme { get; set; }
    }
}
