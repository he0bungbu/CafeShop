//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CafeShop.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MUSTER
    {
        public string userName { get; set; }
        public string displayName { get; set; }
        public string muster1 { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual ACCOUNT ACCOUNT { get; set; }
    }
}
