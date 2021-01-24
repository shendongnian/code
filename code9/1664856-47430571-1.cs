    public class PropertyOrFieldInfo<T>
    {
        MemberInfo internalInfo;
        PropertyInfo internalProperty;
        FieldInfo internalField;
        public PropertyOrFieldInfo(string memberName)
        {
            internalProperty = typeof(T).GetProperty(memberName);
            if (internalProperty == null)
            {
                internalField = typeof(T).GetField(memberName);
                if (internalField == null)
                    throw new MissingMemberException(typeof(T).FullName, memberName);
            }
        }
        public object GetValue(T source)
        {
            if (internalProperty != null)
                return internalProperty.GetValue(source);
            else
                return internalField.GetValue(source);
        }
    }
