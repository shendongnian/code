    public class Header
    {
    	
        public int HeaderId { get; set; }
        public List<Line> Lines { get; set; }
    }
    
    public class Line
    {
    	public Header ParentHeader { get; }
        public int LineId { get; set; }
        public int? HeaderId { get { return ParentHeader?.HeaderId; }  
    	
    	public Line(Header header)
    	{
    		ParentHeader = header;
    	}
    }
