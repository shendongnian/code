    public class BarSomeService<TA> : SomeService<TA, Bar>
    {
        public BarSomeService([dependencies]) : base([dependencies]) { }
    }
    containerBuilder.RegisterGeneric(typeof(BarSomeService<>))
        .As(typeof(ISomeService<>))
        .InstancePerLifetimeScope();
