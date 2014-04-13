//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KU.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zlecenie
    {
        public int ZlecenieID { get; set; }
        public string Miejsce_nadania { get; set; }
        public string Miejsce_dostawy { get; set; }
        public string Odbiorca { get; set; }
        public string Zleceniodawca { get; set; }
        public Nullable<int> Ilosc_opakowan { get; set; }
        public bool Materialy_niebezpieczne { get; set; }
        public bool Pobranie_za_przesylke { get; set; }
        public bool Priorytet { get; set; }
        public string Kategoria_zlecenia { get; set; }
        public string Kurier { get; set; }
        public int Status { get; set; }
        public string Komentarz_kuriera { get; set; }
        public string Komentarz_nadawcy { get; set; }
        public int RodzajOpakowaniaId { get; set; }
        public int ZawartoscId { get; set; }
        public Nullable<int> PowodOdrzuceniaId { get; set; }
        public Nullable<int> PowodPrzelozeniaId { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual StatusZlecenie StatusZlecenie { get; set; }
        public virtual RodzajOpakowania RodzajOpakowania { get; set; }
        public virtual Zawartosc Zawartosc { get; set; }
        public virtual PowodOdrzucenia PowodOdrzucenia { get; set; }
        public virtual PowodPrzelozenia PowodPrzelozenia { get; set; }
    }
}
