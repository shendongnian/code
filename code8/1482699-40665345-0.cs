    public static string GetInternalID(Record record)
    {
        return GetProperty<string>(record, "internalId");
    }
    
    public static string GetInternalID(BaseRef recordRef)
    {
        PropertyInfo pi = recordRef.GetType().GetProperty("internalId");
        return (string)pi.GetValue(recordRef, null);
    }
    
    public static CustomFieldRef[] GetCustomFieldList(Record record)
    {
        return GetProperty<CustomFieldRef[]>(record, CustomFieldPropertyName);
    }
