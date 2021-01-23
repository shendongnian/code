            foreach (string propName in map.GetUnmappedPropertyNames())
            {
                expr.ForMember(propName, opt => opt.Ignore());
            }
   
