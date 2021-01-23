    public class ActionFilterRegisteryClass : StructureMap.Registry
    {
        public ActionFilterRegisteryClass(Func<StructureMap.IContainer> containerFactory)
        {
            For<IFilterProvider>().Use(
                new StructurMapFilterProvider(containerFactory));
    
            Policies.SetAllProperties(x =>
            {
                x.Matching(p =>
                    p.DeclaringType.CanBeCastTo(
                    !p.PropertyType.IsPrimitive &&
                    !p.PropertyType.IsEnum &&
                    p.PropertyType != typeof(string));
            });
        }
    }
