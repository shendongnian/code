    public static void GetDates(this object value)
    {
        if(value == null) //if this object is null, you need to stop
        {
            return;
        }
        var properties = value.GetType().GetProperties();
        foreach(PropertyInfo property in properties)
        {
            //if the property is a datetime, do your conversion
            if(property.GetType() == typeof(DateTime))
            {
                //do your conversion here
            }
            //otherwise get the value of the property and run the same logic on it
            else
            {
                property.GetValue(value).GetDates(); // here is your recursion
            }
        }
    }
