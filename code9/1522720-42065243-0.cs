    public void ParseAmpersand()
    {
        foreach (PropertyInfo pi in this.GetType().GetProperties())
        {
            if (pi.PropertyType == typeof(string)
            {
                ((string)pi.GetValue(this)).Replace("&", "%26");
            }
        }               
    }
