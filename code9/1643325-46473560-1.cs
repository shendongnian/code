    public class RequiresDependency
    {
        public RequiresDependency(Dependency dependency)
        {
            Dependency = dependency;
        }
        public Dependency Dependency { get; }
    }
    public class Dependency
    {}
    [TestClass]
    public class AutofacTest
    {
        [TestMethod]
        public void ResolvesWithSpecifiedParameters()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RequiresDependency>();
            builder.RegisterType<Dependency>();
            var myDependency = new Dependency();
            using (var container = builder.Build())
            {
                var resolved =
                    container.Resolve<RequiresDependency>(new NamedParameter("dependency", myDependency));
                Assert.AreSame(myDependency, resolved.Dependency);
            }
        }
        [TestMethod]
        public void ResolvesWithRegisteredTypeIfParameterNameDoesntMatch()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RequiresDependency>();
            builder.RegisterType<Dependency>();
            var myDependency = new Dependency();
            using (var container = builder.Build())
            {
                var resolved =
                    container.Resolve<RequiresDependency>(new NamedParameter("x", myDependency));
                Assert.AreNotSame(myDependency, resolved.Dependency);
            }
        }
    }
