    public static void SetValue(this MemberInfo mi, object targetObject, object value)
    {
        switch (mi.MemberType)
        {
            case MemberTypes.Field:
                try
                {
                    (mi as FieldInfo).SetValue(targetObject, value);
                }
                catch(Exception e)
                {
                    throw new GeneralSerializationException($"Could not set field {mi.Name} on object of type {targetObject.GetType()}.", e);
                }
                break;
    
            case MemberTypes.Property:
                try
                {
                    (mi as PropertyInfo).SetValue(targetObject, value);
                }
                catch(Exception e)
                {
                    throw new GeneralSerializationException($"Could not set property {mi.Name} on object of type {targetObject.GetType()}.", e);
                }
                
                break;
            default:
                throw new GeneralSerializationException($"MemberInfo must be a subtype of FieldInfo or PropertyInfo.");
        }
    }
