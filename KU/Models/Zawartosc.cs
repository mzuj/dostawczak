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
    
    public partial class Zawartosc
    {
        public Zawartosc()
        {
            this.Zlecenie = new HashSet<Zlecenie>();
        }
    
        public int Id { get; set; }
        public string Zawartość { get; set; }
    
        public virtual ICollection<Zlecenie> Zlecenie { get; set; }
    }
}
