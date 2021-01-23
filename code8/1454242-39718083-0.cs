    public class StackOverFlowObject
    {
        ...
        
        [TypeConverter(typeof(UIntTypeConverter))]
        public uint Questions {
            get {}  //This can be a normal property or an accessor for a bindable one
            set {}
        }
        ...
    }
