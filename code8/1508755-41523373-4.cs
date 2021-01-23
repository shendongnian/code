    public class ClassOneToNumberOneBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            typeName = typeName.Replace(
                "oldNamespace.OutputInformation",
                "newNamespace.OutputInformation");
            return Type.GetType(typeName);
        }
    }
