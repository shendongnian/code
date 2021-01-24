    public class ComplexEnumConverter : EnumConverter
            {
                public bool IsFlagged { get; }
    
                public ComplexEnumConverter(Type type)
                    : base(type)
                {
                    IsFlagged = TypeDescriptor.GetAttributes(type).OfType<FlagsAttribute>().Any();
                }
    
                public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
                {
                    return sourceType == typeof(string);
                }
    
                public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
                {
                    return destinationType == typeof(string);
                }
    
                public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
                {
                    var str = value as string;
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        var values = str.Split(',').Select(s => s.Trim());
                        var enumValue = Enum.Parse(EnumType, values.First());
                        if (IsFlagged)
                        {
                            var temp = (int)enumValue;
                            foreach (var item in values.Skip(1))
                            {
                                temp |= (int)Enum.Parse(EnumType, item);
                            }
    
                            enumValue = temp;
                        }
    
                        return enumValue;
                    }
    
                    return base.ConvertFrom(context, culture, value);
                }
    
                public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
                {
                    var type = value?.GetType();
                    if (type == EnumType)
                    {
                        var list = new List<string>();
                        int k = (int)value;
                        foreach (var item in Enum.GetNames(type))
                        {
                            var current = (int)Enum.Parse(type, item);
                            if ((k & current) == current)
                            {
                                list.Add(item);
                            }
                        }
    
                        return list.Aggregate((c, n) => $"{c}, {n}");
                    }
    
                    return base.ConvertTo(context, culture, value, destinationType);
                }
    
                public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
                {
                    return true;
                }
    
                public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
                {
                    return true;
                }
    
                public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
                {
                    var type = context.PropertyDescriptor.PropertyType;
                    if (type.IsEnum)
                    {
                        var svc =
                               new StandardValuesCollection(Enum.GetNames(type));
                    }
    
                    return base.GetStandardValues(context);
                }
            }
