         var container = new WindsorContainer();
            Mapper.Initialize(m =>
            {
                m.ConstructServicesUsing(container.Resolve);
                m.CreateMap<Test3, ITest>().ConstructUsingServiceLocator(); // This is important!
 
            });
            
            container.Register(Component.For<ITest>().ImplementedBy<Test>());
            container.Register(Component.For<ITest2>().ImplementedBy<Test2>());
            container.Register(Component.For<ITest3>().ImplementedBy<Test3>());
            var test3 = new Test3();
            var test1 = Mapper.Instance.Map<Test3, ITest>(test3);
