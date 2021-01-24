    public class DisallowSerializationBindingBinder : ISerializationBinder
    {
     #region ISerializationBinder Members
     public void BindToName(Type serializedType, out string assemblyName, out string typeName)
     {
      throw new JsonSerializationException("Binding of subtypes has been disabled");
     }
     public Type BindToType(string assemblyName, string typeName)
     {
      throw new JsonSerializationException("Binding of subtypes has been disabled");
     }
      #endregion
    }
