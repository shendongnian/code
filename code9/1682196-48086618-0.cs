    public static class ObjectExtensionMethods
    {
        static public Dictionary<string, object> ToPropertyDictionary(this object o)
        {
            var d = new Dictionary<string, object>();
            foreach (var p in o.GetType().GetProperties())
            {
                d.Add(p.Name, p.GetValue(o));
            }
            return d;
        }
    }
