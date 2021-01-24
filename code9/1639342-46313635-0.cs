    public class TBL_CUSTPACKINGSLIPVERSION
    {
        public int CUSTPACKINGSLIPVERSION_ID { get; set; }
        public int INTERNALPACKINGSLIPID { get; set; }
        public DateTime VERSIONDATETIME { get; set; }
    }
    public class TBL_CUSTPACKINGSLIPJOUR
    {
        public int RECID { get; set; }
        public int PACKINGSLIPID { get; set; }
    }
    public class TBL_CUSTPACKINGSLIPTRANS
    {
        public int PACKINGSLIPID { get; set; }
        public int LINENUM { get; set; }
        public int RECID { get; set; }
    }
    var CUSTPACKINGSLIPVERSION = new List<TBL_CUSTPACKINGSLIPVERSION>();
    var CUSTPACKINGSLIPJOUR = new List<TBL_CUSTPACKINGSLIPJOUR>();
    var CUSTPACKINGSLIPTRANS = new List<TBL_CUSTPACKINGSLIPTRANS>();
