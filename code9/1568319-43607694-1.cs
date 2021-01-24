    public interface IPlugin
    {
        void Initialize();
    }
    public class PluginLoader
    {
        public List<IPlugin> LoadPlugins()
        {
            List<IPlugin> plugins = new List<IPlugin>();
            IEnumerable<string> files = Directory.EnumerateFiles(Path.Combine(Directory.GetCurrentDirectory(), "Plugins"),
                "*.dll",
                SearchOption.TopDirectoryOnly);
            
            foreach (var dllFile in files)
            {
                Assembly loaded = Assembly.LoadFile(dllFile);
                IEnumerable<Type> reflectedType =
                    loaded.GetExportedTypes().Where(p => p.IsClass && p.GetInterface(nameof(IPlugin)) != null);
                plugins.AddRange(reflectedType.Select(p => (IPlugin) Activator.CreateInstance(p)));
            }
            return plugins;
        }
    }
