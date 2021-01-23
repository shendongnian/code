     Class1 c = new Class1();
     PropertyInfo[] listPI = c.GetType().GetProperties();
     Dictionary<string, string> dictDisplayNames = new Dictionary<string, string>();
     string displayName = string.Empty;
     foreach (PropertyInfo pi in listPI)
     {
        DisplayNameAttribute dp = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();
                if (dp != null)
                {
                    displayName = dp.DisplayName;
                    dictDisplayNames.Add(pi.Name, displayName);
                }
     }
