    private static void ResolveTypeAndValue(object obj, string name, Dictionary<string, string> storage)
    {
        if (obj == null)
        {
            storage.Add(name, null);
            return;
        }
        var type = obj.GetType();
        foreach (var p in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
        {
            if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
            {
                var currentObj = p.GetValue(obj);
                ResolveTypeAndValue(currentObj, p.Name, storage); // removed this: '+ "."'
            }
            else
            {
                string val = "";
                if (p.GetValue(obj) != null)
                {
                    val = p.GetValue(obj).ToString();
                }
                storage.Add(name + "." + p.Name, val); // added this: '+ "."'
            }
        }
    }
