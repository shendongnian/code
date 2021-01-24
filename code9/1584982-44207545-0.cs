    public class MyCustomSerializationBinder : ISerializationBinder
    {
        public Type BindToType(string assemblyName, string typeName)
        {
            switch(typeName)
            {
                case "BooleanParameter":
                    return typeof(BooleanParameter);
                case "AnalogParameter":
                    return typeof(AnalogParameter);
                case "SerialParameter":
                    return typeof(SerialParameter);
                case "CommandTrigger":
                    return typeof(CommandTrigger);
            }
            return null;
        }
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }
    }
