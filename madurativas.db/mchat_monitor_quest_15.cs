//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace madurativas.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class mchat_monitor_quest_15
    {
        public long estudioId { get; set; }
        public Nullable<bool> quest1 { get; set; }
        public Nullable<bool> quest2 { get; set; }
        public Nullable<bool> quest3 { get; set; }
        public Nullable<bool> quest4 { get; set; }
        public Nullable<bool> quest5 { get; set; }
        public Nullable<bool> quest6 { get; set; }
        public Nullable<bool> quest7 { get; set; }
        public Nullable<bool> quest8 { get; set; }
        public string quest9 { get; set; }
        public Nullable<bool> pasa { get; set; }
    
        public virtual mchat mchat { get; set; }
    }
}
