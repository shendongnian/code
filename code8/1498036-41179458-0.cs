        [Fact]
        public void WhenInjectedIntoHeirarchyShouldWork()
        {
            var k = new StandardKernel();
            k.Bind<IData>()
             .To<Data0>().WhenInjectedIntoRequestChain(typeof(Params),typeof(Target0));
            k.Bind<IData>()
             .To<Data1>().WhenInjectedIntoRequestChain(typeof(Params),typeof(Target1));
            k.Bind<IData>()
             .To<Data2>().WhenInjectedIntoRequestChain(typeof(Params),typeof(Target1));
            var target0 = k.Get<Target0>();
            var target1 = k.Get<Target1>();
            target0.P.Data.Count.Should().Be(1);
            target1.P.Data.Count.Should().Be(2);
        }
