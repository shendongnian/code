    public static object GetValue(this MemberInfo member, object srcObject) {
        if (member.MemberType == MemberTypes.Property)
            return ((PropertyInfo)member).GetValue(srcObject, null);
        else if (member.MemberType == MemberTypes.Field)
            return ((FieldInfo)member).GetValue(srcObject);
        else
            throw new Exception("Property must be of type FieldInfo or PropertyInfo");
    }
    public static void SetValue<T>(this MemberInfo member, object destObject, T value) {
        if (member.MemberType == MemberTypes.Property)
            ((PropertyInfo)member).SetValue(destObject, value);
        else if (member.MemberType == MemberTypes.Field)
            ((FieldInfo)member).SetValue(destObject, value);
        else
            throw new Exception("Property must be of type FieldInfo or PropertyInfo");
    }
    public static Type GetMemberType(this MemberInfo member) {
        switch (member.MemberType) {
            case MemberTypes.Field:
                return ((FieldInfo)member).FieldType;
            case MemberTypes.Property:
                return ((PropertyInfo)member).PropertyType;
            case MemberTypes.Event:
                return ((EventInfo)member).EventHandlerType;
            default:
                throw new ArgumentException("MemberInfo must be if type FieldInfo, PropertyInfo or EventInfo", "member");
        }
    }
