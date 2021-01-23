     Class1 c = new Class1();
     PropertyInfo[] listPI = c.GetType().GetProperties();
     Dictionary<string, string> dictDisplayNames = new Dictionary<string, string>();
     string displayName = string.Empty;
     foreach (PropertyInfo pi in listPI)
     {
         displayName = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single().DisplayName;
         dictDisplayNames.Add(pi.Name, displayName);
     }
