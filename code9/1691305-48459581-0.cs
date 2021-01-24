    public class AppraisalRatingEnumType : NHibernate.Type.EnumStringType
    {
        public AppraisalRatingEnumType()
            : base(typeof(AppraisalRating))
        {
        }
        public override object GetInstance(object code)
        {
            var str = (string)code;
            var type = typeof(AppraisalRating);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                {
                    if (attribute.Value == str)
                        return (AppraisalRating)field.GetValue(null);
                }
                else
                {
                    if (field.Name == str)
                        return (AppraisalRating)field.GetValue(null);
                }
            }
            return default(AppraisalRating);
        }
        public override object GetValue(object enumVal)
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attr = memInfo[0].GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
            return attr != null ? attr.Value : enumVal;
        }
    }
