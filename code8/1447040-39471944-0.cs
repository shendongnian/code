    class MySerializable : Object, Java.IO.ISerializable
    	{
    		public string Value {get; private set;}
    
    		public MySerializable (IntPtr handle, JniHandleOwnership transfer)
    			: base (handle, transfer)
    		{
    		}
    
    		public MySerializable ()
    		{
    		}
    
    		public MySerializable (string value)
    		{
    			Value = value;
    		}
    }
