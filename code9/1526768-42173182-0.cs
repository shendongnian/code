    private Event clone(Event eventToClone)
    {
        Event result = new Event();
    
        foreach (PropertyInfo property in typeof(Event).GetProperties())
        {
            if (property.CanRead)
                property.SetValue(result, property.GetValue(eventToClone, null));
        }
    
        return result;
    }
