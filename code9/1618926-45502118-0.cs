    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";
            string stringRepresentation = value.ToString();
            Type T = value.GetType();
            if (!T.IsEnum) return stringRepresentation;
            MemberInfo[] enumMembers = T.GetMember(stringRepresentation);
            if (enumMembers.Length <= 0) return stringRepresentation;
            DescriptionAttribute[] memberAttributes = enumMembers[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (memberAttributes == null) return stringRepresentation;
            if (memberAttributes.Length <= 0) return stringRepresentation;
            return memberAttributes[0].Description;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Or Binding.DoNothing, or throw an Exception, whichever you prefer
            return DependencyProperty.UnsetValue;
        }
    }
