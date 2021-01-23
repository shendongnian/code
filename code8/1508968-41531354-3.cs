    class SomeClass {
    	System.Timers.Timer personalTimer = null; //Timer is now garbage collected after the object of SomeClass goes out of scope!
    
    	SomeClass() {
    		personalTimer = new Syste.Timers.Timer(30000) // Now every 30 seconds!
    	}
    	//your stuff
    	....
    }
