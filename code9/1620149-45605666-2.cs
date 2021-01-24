    public interface IPlugin
    {
         void Do();
    }
    public interface IPluginMetaData 
    {
         string Name { get; }
         string Code { get; }
         //[... more attribute ...]
    }
    
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PluginExportAttribute : ExportAttribute, IPluginMetaData
    {
        public string Name { get; set; }
        public string Code { get; set; }   
         
        //[... more attribute ...]
        public PluginExportAttribute() : base(typeof(IPlugin)) { }
    }
