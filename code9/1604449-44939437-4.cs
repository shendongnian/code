    [Serializable]
    public class PluginConfiguration : System.Runtime.Serialization.ISerializable
    {
        public string Name { get; set; }
        public PluginConfiguration()
        {
        }
        protected PluginConfiguration(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            Name = (string)info.GetValue("Name", typeof(string));
           
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
        }
    }
    [Serializable]
    public class MyPluginConfiguration : PluginConfiguration
    {
        public string AccessToken { get; set; }
        public MyPluginConfiguration()
        {
        }
        protected MyPluginConfiguration(SerializationInfo info, StreamingContext context) :base(info, context)
        {
           
        }
    }
    private class PluginBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            return typeof(PluginConfiguration);
        }
    }
