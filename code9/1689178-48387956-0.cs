    public partial class SvcCodes
    {
        public List<SvcCodeReport> Report { get; set; }
        public List<SvcCodesCheck> TestList { get; set; }
    	
    	public SvcCodes()
    	{
    		Report = new List<SvcCodeReport>();
    	}
    }
