//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace madurativas.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class mchat_monitor_quest_7
    {
        public long estudioId { get; set; }
        public Nullable<bool> quest1 { get; set; }
        public Nullable<bool> quest2 { get; set; }
        public Nullable<bool> quest3 { get; set; }
        public Nullable<bool> quest4 { get; set; }
        public Nullable<bool> quest5 { get; set; }
        public Nullable<bool> quest6 { get; set; }
        public Nullable<bool> quest7 { get; set; }
        public Nullable<bool> pasa { get; set; }
    
        public virtual mchat mchat { get; set; }
    }
}
