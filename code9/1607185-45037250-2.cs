    List<string> values = new List<string>();
    
    foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key.StartsWith("someValuestoReturn"))
                {
                    string value = ConfigurationManager.AppSettings[key].Split(',');
                    values.Add(value);
                }
    
            }
    
    string[] myValuesfromWebConfig = values.ToArray();
