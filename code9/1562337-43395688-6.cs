    class Program
    {
        void Main()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IOne, OneA>("A");
            container.RegisterType<IOne, OneB>("B");
            container.RegisterType<ITwo, TwoA>("A");
            container.RegisterType<ITwo, TwoB>("B");
            container.RegisterType<Func<IOne, ITwo, IApp>>(
                new InjectionFactory(c =>
                    new Func<IOne, ITwo, IApp>((iOne, iTwo) =>
                        c.Resolve<IApp>(
                            new ParameterOverride("iOneInstance", iOne),
                            new ParameterOverride("iTwoInstance", iTwo)))));
            container.RegisterType<Func<string, string, IApp>>(
                new InjectionFactory(c =>
                    new Func<string, string, IApp>((iOneNamedRegistration, iTwoNamedRegistration) =>
                        c.Resolve<IApp>(
                            new ParameterOverride("iOneInstance", c.Resolve<IOne>(iOneNamedRegistration)),
                            new ParameterOverride("iTwoInstance", c.Resolve<ITwo>(iTwoNamedRegistration))))));
            // Alternate writing
            container.RegisterType<Func<string, string, IApp>>(
                new InjectionFactory(c =>
                    new Func<string, string, IApp>((iOneNamedRegistration, iTwoNamedRegistration) =>
                    {
                        IOne iOne = c.Resolve<IOne>(iOneNamedRegistration);
                        ITwo iTwo = c.Resolve<ITwo>(iTwoNamedRegistration);
                        IApp iApp = c.Resolve<IApp>(
                            new ParameterOverride("iOneInstance", iOne),
                            new ParameterOverride("iTwoInstance", iTwo));
                        return iApp;
                    })));
            ClassWithFactoryMethodOne versionOne = container.Resolve<ClassWithFactoryMethodOne>();
            // Somewhere you have logic and end up with instances of IOne and ITwo then you :
            IApp iApp1 = versionOne.Create(iOneInstance, iTwoInstance); // This doesn't compile cause you'd need the instances.
            ClassWithFactoryMethodTwo versionTwo = container.Resolve<ClassWithFactoryMethodTwo>();
            IApp iApp2 = versionTwo.Create("A", "B");
        }
    }
