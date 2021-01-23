    public static class AppSettings{
	    public static _value Value { get; set; }
	
	    //static setter
	    static AppSettings(){
		    Value = new _value();
	    }
    }
    public class _value{
	    public string this[string nodeName]{
		    get{
		    	//get code here
		    }
		    set{
			    //set code here
		    }
	    }
    }
       
