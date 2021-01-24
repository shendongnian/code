    string str1 = new Object().GetType().ToString();  //System.Object
    string str2 = typeof(Object).ToString();  //System.Object
    string str3 = typeof(Object).GetType().ToString();  //System.RuntimeType
    string str4 = typeof(Type).ToString();  //System.Type
    string str5 = typeof(Type).GetType().ToString();  //System.RuntimeType
