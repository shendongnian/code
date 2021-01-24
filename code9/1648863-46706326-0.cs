    class MyClass {
        public int field1;
        public int field2;
    }
    
    class MyClassComparer: EqualityComparer<MyClass>
    {
    	public override bool Equals(MyClass x, MyClass y)
    	{
    		if (x == null && y == null)
                return true;
            else if (x == null || x == null)
                return false;
    
    		if (x.field1 == y.field1 && x.field2 == y.field2)
    		{
    			return true;
    		}
    		else
    		{
    			return false;
    		}
    	}
    
    	public override int GetHashCode(MyClass x)
    	{
    		int hCode = x.field1.GetHashCode() ^ x.field2.GetHashCode();
    		return hCode.GetHashCode();
    	}
    }
