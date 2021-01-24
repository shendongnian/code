    public class singleString {
        public string ss { get; set; }
    	
    	public static implicit operator singleString(string s) {
    		return new singleString { ss = s };
    	}
    }
