    public static class ExtensionMethods
    {
        public static void changeSysTemHeader(this HttpWebRequest request, string key, string value)
        {
            WebHeaderCollection wHeader = new WebHeaderCollection();
            wHeader[key] = value;
    
    
            FieldInfo fildInfo = request.GetType().GetField("webHeaders",
                                                    System.Reflection.BindingFlags.NonPublic
                                                       | System.Reflection.BindingFlags.Instance
                                                       | System.Reflection.BindingFlags.GetField);
    
            fildInfo.SetValue(request, wHeader);
        }
    
        public static void changeReflectionField(this HttpWebRequest request, string fieldName, object value)
        {
            FieldInfo fildInfo = request.GetType().GetField(fieldName, System.Reflection.BindingFlags.NonPublic
                                                       | System.Reflection.BindingFlags.Instance
                                                       | System.Reflection.BindingFlags.GetField);
    
            fildInfo.SetValue(request, value);
        }
    }
