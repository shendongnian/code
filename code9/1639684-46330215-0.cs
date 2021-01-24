    using System.ComponentModel;
    
    namespace WpfTestTypeConverter
    {
        [TypeConverter(typeof(DeviceTypeConverter))]
        public enum DeviceType
        {
            Computer,
            Car,
            Bike,
            Boat,
            TV
        }
    }
