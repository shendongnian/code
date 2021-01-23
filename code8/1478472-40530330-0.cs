        enum MyName { AA,BB,CC};
    
    //Call this in one of your methods
        
        string [] strVal= Enum.GetNames(typeof(MyName));
                    int x = CallFunction(strVal[0], "A");
                    int y = CallFunction(strVal[1], "h");
                    int z = CallFunction(strVal[1], "C");
    
    //End Call this in one of your methods
        
        
         int CallFunction(string strName,string strValue)
                {
                    return Convert.ToInt32(this.GetType().InvokeMember(strName, BindingFlags.Public | BindingFlags.InvokeMethod|BindingFlags.Instance, null, this, new object[] { strValue }));
                }
        
         public int AA(string s)
                {
                    return 1;
                }
        
               public int BB(string s)
                {
                    return 2;
                }
        
               public int CC(string s)
                {
                    return 3;
                }
