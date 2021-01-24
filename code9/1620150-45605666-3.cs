    [PluginExport(Name = "PluginOne", Code = "Key")]
    public class PluginOne : IPlugin
    {
         public void Do()
         {
           Console.WriteLine("I'm PluginOne");
         } 
    }
