    public class ItmDet
    {
        public double samt { get; set; }
        public int csamt { get; set; }
        public int rt { get; set; }
        public double txval { get; set; }
        public double camt { get; set; }
    }
    public class Itm
    {
        public int num { get; set; }
        public ItmDet itm_det { get; set; }
    }
    public class Inv
    {
        public int val { get; set; }
        public List<Itm> itms { get; set; }
        public string inv_typ { get; set; }
        public string pos { get; set; }
        public string idt { get; set; }
        public string rchrg { get; set; }
        public string inum { get; set; }
    }
    public class B2b
    {
        public List<Inv> inv { get; set; }
        public string error_msg { get; set; }
        public string ctin { get; set; }
        public string error_cd { get; set; }
    }
    public class ErrorReport
    {
        public List<B2b> b2b { get; set; }
    }
    public class RootObject
    {
        public string status_cd { get; set; }
        public string fp { get; set; }
        public ErrorReport error_report { get; set; }
        public string gstin { get; set; }
    }
