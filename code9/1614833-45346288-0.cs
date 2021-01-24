    Assembly assembly = Assembly.GetEntryAssembly();
            Type[] typ = assembly.GetTypes();
            foreach (Type t in typ)
            {
                IList<CustomAttributeData> m = t.GetCustomAttributesData();
                if(m.Count>0)
                animals.Add(t.Name, m[0].NamedArguments[0].TypedValue.Value.ToString());
                
            }
