    public static void GetDates(this object value)
    {
        var properties = value.GetType().GetProperties();
        foreach (var property in properties)
        {
            if (typeof(IHasDateProperty).IsAssignableFrom(property.PropertyType))
            {
                property.SetDatesToUtc();
            }
            else
            {
                if (property.GetType() == typeof(DateTime))
                {
                    //Do something...
                }
            }
        }
    }
