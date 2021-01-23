    interface Itest {}
    
    class BusinessBase<T> {
    
    }
    
    class Test<T> : BusinessBase<T>, Itest where T : Test<T>, Itest {
    	public int Digit() {
    		return 30;
    	}
    }
    
    class IT : Test<IT>, Itest {
    
    }
    
    class Program {
    	public static int Main() {
    	
    		var t = new Test<IT>();
    		t.Digit();
    		return 0;
    	}
    }
