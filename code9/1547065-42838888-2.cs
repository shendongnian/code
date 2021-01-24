    public sealed class RefBool
    {
        public static implicit operator bool( RefBool value )
	    {
		    return value != null;
	    }
	
	    public static implicit operator RefBool( bool value )
	    {
		    return value ? RefBool.True : RefBool.False;
	    }
	
	    public static bool operator true( RefBool value )
	    {
		    return value != null;
	    }
	
	    public static bool operator false( RefBool value )
	    {
		    return value == null;
	    }
	    public static readonly RefBool True = new RefBool();
	    public static readonly RefBool False = null;
	    private RefBool()
	    {
        }
    }
