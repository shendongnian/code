    static public void PrintProperties(object obj, int indent)
    {
        if (obj == null) return;
        string indentString = new string(' ', indent);
        Type objType = obj.GetType();
        PropertyInfo[] properties = objType.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            object propValue = property.GetValue(obj, null);
            if (property.PropertyType.Assembly == objType.Assembly && !property.PropertyType.IsEnum)
            {
                Console.WriteLine("{0}{1}:", indentString, property.Name);
                PrintProperties(propValue, indent + 2);
            }
            else
            {
                if (null != propValue)
                {
                    var asDict = propValue as IDictionary;
                    if (asDict != null)
                    {
                        foreach (DictionaryEntry kvp in asDict)
                        {
                            Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
                        }
                    }
                }
                Console.WriteLine("{0}{1}: {2}", indentString, property.Name, propValue);
            }
        }
    }
