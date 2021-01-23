    public bool TestZipcodeIsNotNull(string zip) {
	    if (zip == null)
              return false;
    }
    public bool TestZipcodeIsValid(string zip) {
 	     if (zip == null) 
		      return true; // The other test will have failed!
	
	     return (zip.Length == 5 || zip.Length == 9));
    }
