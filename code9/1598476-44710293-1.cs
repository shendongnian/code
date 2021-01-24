    private static fsSerializer sm_Serializer = new fsSerializer();
    [fsObject(Converter = typeof(CustomConverter))]
    public class SomeClass
    {
        string MyProp { get; set; }
    }
    public class CustomConverter : fsConverter
    {
        private static fsSerializer sm_Serializer = new fsSerializer();
        public override bool CanProcess(Type type)
        {
            return type == typeof(SomeClass);
        }
        public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
        {
            throw new NotImplementedException();
        }
        public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
        {
            SomeClass someClass = (SomeClass)instance;
            serialized = null;
            Dictionary<string, fsData> serialization = new Dictionary<string, fsData>();
            fsData tempData = null;
            if (someClass.MyProp != null)
            {
                sm_Serializer.TrySerialize(someClass.MyProp, out tempData);
                serialization.Add("myProp", tempData);
            }
            serialized = new fsData(serialization);
            return fsResult.Success;
        }
    }
