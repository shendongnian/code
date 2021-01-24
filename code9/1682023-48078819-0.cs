        [Test]
        public void AssertThatDependenciesCorrectlyMap()
        {
            Assert.DoesNotThrow(() => 
            {
                var container = new UnityContainer();
                container.RegisterType<IMyType, MyImpl1>(nameof(MyImpl1));
                container.RegisterType<IMyType, MyImpl2>(nameof(MyImpl2));
                container.RegisterType<IMyType, MyImpl3>(nameof(MyImpl3));
                container.RegisterType<MyFactory>(
                        new InjectionConstructor(new ResolvedArrayParameter<IMyType>(
                            new ResolvedParameter<IMyType>(nameof(MyImpl1)),
                            new ResolvedParameter<IMyType>(nameof(MyImpl2)),
                            new ResolvedParameter<ISomeOtherType>(nameof(MyImpl3)),
                        ));
            }
        }
