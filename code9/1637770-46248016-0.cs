    public class Header
    {
    	private List<Lines> _lines
        public int HeaderId { get; set; }
        public List<Line> Lines 
    	{ 
    		get { return _lines; }
    		set 
    		{ 
    			_lines = value;
    			if(_lines != null)
    			{
    				foreach(var line in _lines)
    					line.HeaderId = HeaderId;
    			}
    		}
    	}
    }
        
    public class Line
    {
        public int LineId { get; set; }
        public int HeaderId { get; set; }  
    }
