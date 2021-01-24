        public static Dictionary<string, System.Reflection.PropertyInfo> ToPropertyDictionary(object o)
        {
            var d = new Dictionary<string, System.Reflection.PropertyInfo>();
            foreach (var p in o.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                d.Add(p.Name, p);
            }
            return d;
        }
    
