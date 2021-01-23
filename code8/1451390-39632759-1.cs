        public sealed class PluginAdapter_v1_v2 : IPlugin_v2
        {
            private readonly IPlugin_v1 _pluginV1;
    
            public PluginAdapter_v1_v2(IPlugin_v1 pluginV1)
            {
                _pluginV1 = pluginV1;
            }
    
            public string Name => _pluginV1.Name;
    
            public string Version => "Unknown";
        }
