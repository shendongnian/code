    public class BarUniqueForFoo : IInstancePolicy
    {
        public void Apply(Type pluginType, Instance instance)
        {
            if (pluginType == typeof(IFoo) && instance.ReturnedType == typeof(IBar)
            {
                instance.SetLifecycleTo<AlwaysUnique>();
            }
        }
    }
