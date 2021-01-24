    public class Header
    {
    	List<Line> _lines = new List<Line>();
        public int HeaderId { get; set; }
        public ReadOnlyCollection<Line> Lines { get {return _lines.AsReadOnly(); }
    	
    	
    	public void AddLine(Line line)
    	{   			
    		line.HeaderId = HeaderId;
    		_lines.Add(line);
    	}
    }
