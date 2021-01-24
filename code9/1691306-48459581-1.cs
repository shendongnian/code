    public class EnumWithValuesFromEnumMember<T> : NHib.Type.EnumStringType where T : struct
    {
        public EnumWithValuesFromEnumMember()
            : base(typeof(T))
        {
        }
        public override object GetInstance(object enumCode)
        {
            var codeString = (string)enumCode;
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                {
                    if (attribute.Value == codeString)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == codeString)
                        return (T)field.GetValue(null);
                }
            }
            return default(T);
        }
        public override object GetValue(object enumCode)
        {
            var type = enumCode.GetType();
            var memberInfo = type.GetMember(enumCode.ToString());
            var attr = memberInfo[0].GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
            return attr != null ? attr.Value : enumCode;
        }
    }
