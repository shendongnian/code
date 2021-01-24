    public class CastleWindsorPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            runtimePluginEvents.CustomizeScenarioDependencies += (sender, args) =>
            {
                args.ObjectContainer.RegisterTypeAs<CastleWindsorBindingInstanceResolver, IBindingInstanceResolver>();
            };
        }
    }
