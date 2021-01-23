    public class ItmDet
    {
        public string ty { get; set; }
        public string hsn_sc { get; set; }
        public double txval { get; set; }
        public double irt { get; set; }
        public double iamt { get; set; }
        public double crt { get; set; }
        public double camt { get; set; }
        public double srt { get; set; }
        public double samt { get; set; }
    }
    
    public class Itm
    {
        public int num { get; set; }
        public ItmDet itm_det { get; set; }
    }
    
    public class Inv
    {
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string pro_ass { get; set; }
        public List<Itm> itms { get; set; }
        public string chksum { get; set; }
    }
    
    public class B2b
    {
        public string ctin { get; set; }
        public List<Inv> inv { get; set; }
    }
    
    public class RootObject
    {
        public List<B2b> b2b { get; set; }
    }
