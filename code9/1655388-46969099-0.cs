    using System;
    using System.Web.Script.Serialization;
    
    public class myClass
    {
        // The JavaScriptSerializer ignores this field.
        [ScriptIgnore]
        public int ID{ get; set; }     
    
        // The JavaScriptSerializer serializes this field.
        public string name{ get; set; }
        public string surname{ get; set; }
    }
