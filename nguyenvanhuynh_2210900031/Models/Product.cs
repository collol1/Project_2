//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nguyenvanhuynh_2210900031.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public string ProductID { get; set; }
        public string MemberID { get; set; }
        public string CategoryID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Condition { get; set; }
        public string ImageURl { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdateAt { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Member Member { get; set; }
        public virtual Order Order { get; set; }
        public virtual Review Review { get; set; }
    }
}
