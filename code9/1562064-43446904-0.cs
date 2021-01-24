    public static string GetEnumValueDescription(this object enumValue, EnumDescriptionType descriptionType = EnumDescriptionType.withEnumTypeDescriptionAtt)
        {
            if (enumValue == null)
                throw new ArgumentNullException("enumValue");
            var enumType = enumValue.GetType();
            if (enumValue.GetType().IsEnum == false)
                throw new ArgumentException("enumValue must be an Enum.");
            var fieldInfo = enumType.GetField(enumValue.ToString());
            var customAttributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var attribute = customAttributes.FirstOrDefault() as DescriptionAttribute;
            string att = attribute != null ? attribute.Description : enumValue.ToString();
            switch (descriptionType)
            {
                case EnumDescriptionType.withEnumTypeDescriptionAtt:
                    if (enumType.EnumTypeDescriptionExist())
                        return $"{enumType.GetEnumTypeDescription()} {att}";
                    else
                        return att;
                case EnumDescriptionType.withEnumTypeDescription:
                    return $"{enumType.GetEnumTypeDescription()} {att}";
                case EnumDescriptionType.withoutEnumtypeDescription:
                default:
                    return att;
            }
        }
