    public static Dictionary<string,T> CheckEnumValue<T>(string value)
        {
            Dictionary<string,T> DicEnum = new Dictionary<string, T>();
            if (!string.IsNullOrEmpty(value))
            {
                Type type = typeof(T);
                MemberInfo[] memberInfo;
                foreach (T b in Enum.GetValues(typeof(T)))
                {
                    memberInfo = type.GetMember(b.ToString());
                    object[] attributes = memberInfo[0].GetCustomAttributes(typeof(System.Xml.Serialization.XmlEnumAttribute), false);
                    if (attributes.Length == 1)
                    {
                        XmlEnumAttribute attribute = attributes[0] as System.Xml.Serialization.XmlEnumAttribute;
                        if (attribute != null && !string.IsNullOrEmpty(attribute.Name) && attribute.Name.Equals(value))
                            DicEnum.Add(attribute.Name, b);                            
                    }
                    else
                    {
                        if (b.ToString().Equals(value))
                            DicEnum.Add(b.ToString(), b);
                    }
                }
                return DicEnum;
            }
            return null;
        }
