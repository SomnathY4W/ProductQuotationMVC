//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductQuotationMVC.EFDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quotation
    {
        public int QuotationID { get; set; }
        public int ProductID { get; set; }
        public int RequestedQuantity { get; set; }
        public int RequestUserID { get; set; }
        public System.DateTime RequestDate { get; set; }
    }
}