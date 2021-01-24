    int myValue1 = GetValue<int>("your key", your Dictionary);
    bool myValue2 = GetValue<bool>("your key", your Dictionary);
    string myValue3 = GetValue("your key", your Dictionary);
    
    
      public static T GetValue<T>(String paramName, Dictionary<string, string> param = null) where T : new()
            {
                Type myTypeObj = null;
                T MyT = new T();
                if (MyT == null)
                {
                    myTypeObj = typeof(T);
                    myTypeObj = myTypeObj.GetProperty("Value").PropertyType;
                }
                else
                {
                    myTypeObj = MyT.GetType();
                }
    
                MethodInfo myMethodInfo = myTypeObj.GetMethod("Parse", new[] { typeof(string) });
                string value = "";
                if (param.ContainsKey(paramName))
                {
                    value = param[paramName];
                    if (!string.IsNullOrEmpty(value))
                    {
                        object[] reflParm = { value };
                        return (T)myMethodInfo.Invoke(MyT, reflParm);
                    }
                }
                return default(T);
            }
    
            public static String GetValue(String paramName, Dictionary<string, string> param = null)
            {
                string value = "";
                if (param.ContainsKey(paramName))
                {
                    value = param[paramName];
                    if (!string.IsNullOrEmpty(value))
                        return value;
                }
                return String.Empty;
            }
