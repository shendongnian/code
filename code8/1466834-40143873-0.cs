        public static string ToStringWithCulture(this object self, CultureInfo targetCulture)
        {
            PropertyInfo[] propertyInfos  = self.GetType().GetProperties();
            var sb = new StringBuilder();
            foreach (var prop in propertyInfos)
            {
                var value = prop.GetValue(self, null) ?? "null";
                var formattable = value as IFormattable;
                var stringValue = formattable != null ? formattable.ToString(null, targetCulture) : value.ToString();
                sb.AppendLine(prop.Name + " : " +stringValue);
            }
            return sb.ToString();
        }
