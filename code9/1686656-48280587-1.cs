    public class BarUniqueForFoo : IInstancePolicy
    {
        public void Apply(Type pluginType, Instance instance)
        {
            if (pluginType == typeof(IBar) && instance.ReturnedType == typeof(Bar)
            {
                instance.SetLifecycleTo<UniquePerRequestLifecycle>();
            }
        }
    }
