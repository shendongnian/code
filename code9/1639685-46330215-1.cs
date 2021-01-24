    using System;
    using System.ComponentModel;
    using System.Globalization;
    
    namespace WpfTestTypeConverter
    {
        public class DeviceTypeConverter : EnumConverter
        {
            public DeviceTypeConverter(Type type) : base(type)
            {
            }
    
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                return (destinationType == typeof(string));
            }
 
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                if (value is DeviceType)
                {
                    DeviceType x = (DeviceType)value;
    
                    switch (x)
                    {
                        case DeviceType.Computer:
                            return "This is a computer";
                        case DeviceType.Car:
                            return "A big car";
                        case DeviceType.Bike:
                            return "My red bike";
                        case DeviceType.Boat:
                            return "Boat is a goat";
                        case DeviceType.TV:
                            return "Television";
                        default:
                            throw new NotImplementedException("{x} is not translated. Add it!!!");
                    }
                }
                return base.ConvertFrom(context, culture, value);
            }
        }
    }
