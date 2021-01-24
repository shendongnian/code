    public class UnitConverter : TypeConverter
    {
        public UnitConverter()
        {
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string) || destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
            {
                return null;
            }
            string str = value as string;
            if (str == null)
            {
                return base.ConvertFrom(context, culture, value);
            }
            string str1 = str.Trim();
            if (str1.Length == 0)
            {
                return Unit.Empty;
            }
            if (culture != null)
            {
                return Unit.Parse(str1, culture);
            }
            return Unit.Parse(str1, CultureInfo.CurrentCulture);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value == null || ((Unit)value).IsEmpty)
                {
                    return string.Empty;
                }
                return ((Unit)value).ToString(culture);
            }
            if (destinationType != typeof(InstanceDescriptor) || value == null)
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
            Unit unit = (Unit)value;
            MemberInfo constructor = null;
            object[] objArray = null;
            if (!unit.IsEmpty)
            {
                Type type = typeof(Unit);
                Type[] typeArray = new Type[] { typeof(double), typeof(UnitType) };
                constructor = type.GetConstructor(typeArray);
                object[] objArray1 = new object[] { unit.Value, unit.Type };
                objArray = objArray1;
            }
            else
            {
                constructor = typeof(Unit).GetField("Empty");
            }
            if (constructor == null)
            {
                return null;
            }
            return new InstanceDescriptor(constructor, objArray);
        }
    }
