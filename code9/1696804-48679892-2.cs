    public class UserTypeEnumConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var userTypeType = typeof(UserType);
            if (objectType == userTypeType)
            {
                var value = reader.Value.ToString().ToLower();
                foreach (var item in Enum.GetNames(userTypeType))
                {
                    var memberValue = GetEnumMemberValue(userTypeType.GetMember(item)[0]);
                    if (memberValue != null && memberValue.ToLower() == value)
                    {
                        return Enum.Parse(userTypeType, item);
                    }
                }
            }
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
    private static string GetEnumMemberValue(MemberInfo memberInfo)
    {
        var attributes = memberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), inherit: false);
        if (attributes.Length == 0) return null;
        return ((EnumMemberAttribute)attributes[0]).Value;
    }
