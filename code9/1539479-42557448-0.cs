    public partial class Stock_On_Hand_File
    {
        private Nullable<double>[] _weeks = new Nullable<double>[52];
        public string Product { get; set; }
        public Nullable<double> PastDue { get; set; }
        public Nullable<double> WK_001 
        {
            get { return _weeks[0]; }
            set { _weeks[0] = value; }
        }
        public Nullable<double> WK_002 
        {
            get { return _weeks[1]; }
            set { _weeks[1] = value; }
        }
        //etc...
    	public Nullable<double> this[int index]
    	{
    		get { return _weeks[index]; }
    		set { _weeks[index] = value; }
    	}
        //snip
    }
