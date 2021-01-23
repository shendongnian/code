    public static TType GetProperty<TType>(object record, string propertyID)
    {
        PropertyInfo pi = record.GetType().GetProperty(propertyID);
        return (TType)pi.GetValue(record, null);
    }
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
