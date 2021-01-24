    public static class Namespaces
    {
        // The data contract namespace for your project.
        public const string ProjectNamespace = "http://www.Question45412824.com"; 
    }
    // common base class
    [DataContract(Namespace = Namespaces.ProjectNamespace)]
    public class ModuleData : IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }
    }
    [DataContract(Namespace = Namespaces.ProjectNamespace)]
    public class AData : ModuleData
    {
        [DataMember]
        public string A { get; set; }
    }
    [DataContract(Namespace = Namespaces.ProjectNamespace)]
    public class BData : ModuleData
    {
        [DataMember]
        public string B { get; set; }
    }
    [DataContract(Namespace = Namespaces.ProjectNamespace)]
    [KnownType(typeof(AData))]
    [KnownType(typeof(BData))]
    public class Project
    {
        [DataMember]
        public List<ModuleData> Data { get; set; }
    }
    [DataContract(Namespace = Namespaces.ProjectNamespace)]
    public class CData : ModuleData
    {
        [DataMember]
        public string C { get; set; }
    }
    namespace Dummies
    {
        [DataContract(Namespace = Namespaces.ProjectNamespace)]
        public class CData : ModuleData
        {
        }
    }
