        public class TokenExtent
        {
        	public string Name { get; set; }
    	    public int Start { get; set; }
        	public int Length { get; set; }
        	public TokenExtent(string name, int start, int stop)
    	    {
        		Name = name;
         		Start = start;
    	    	Length = stop - start + 1;
        	}
         }
