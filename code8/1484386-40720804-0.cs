    public class Rootobject
    {
        public B2b[] b2b { get; set; }
    }
    
    public class B2b
    {
        public string ctin { get; set; }
        public Inv[] inv { get; set; }
    }
    
    public class Inv
    {
        public string inum { get; set; }
        public string idt { get; set; }
        public float val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string pro_ass { get; set; }
        public Itm[] itms { get; set; }
        public string chksum { get; set; }
    }
    
    public class Itm
    {
        public int num { get; set; }
        public Itm_Det itm_det { get; set; }
    }
    
    public class Itm_Det
    {
        public string ty { get; set; }
        public string hsn_sc { get; set; }
        public float txval { get; set; }
        public float irt { get; set; }
        public float iamt { get; set; }
        public float crt { get; set; }
        public float camt { get; set; }
        public float srt { get; set; }
        public float samt { get; set; }
    }
