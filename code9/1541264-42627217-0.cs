            public static RouteValueDictionary Merge(dynamic item1, dynamic item2)
            {
                var result = new ExpandoObject();
                var d = new RouteValueDictionary();
    
                foreach (System.Reflection.PropertyInfo fi in item1.GetType().GetProperties())
                {
                    d[fi.Name] = fi.GetValue(item1, null);
    
                }
                foreach (System.Reflection.PropertyInfo fi in item2.GetType().GetProperties())
                {
                    d[fi.Name] = fi.GetValue(item2, null);
    
                }
    
                return d;
    }
