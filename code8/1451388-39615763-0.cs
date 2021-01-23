    public interface IPlugin
    {
        void InstallSelf(IPluginManager pluginManager);
    }
    public interface IPlugin2 : IPlugin
    {
        string PluginName { get; }
    }
