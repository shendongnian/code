    [TestFixture]
    public class Test
    {
        public class ExceptionFoo : IFoo
        {
            public void DoStuff()
            {
                throw new Exception();
            }
        }
        [Test]
        public void ShouldReturn0WhenExceptionEncountered()
        {
            AutofacConfig.OverridenRegistrations = builder =>
            {
                builder.RegisterType<ExceptionFoo>().AsImplementedInterfaces();
            };
            var result = Program.Main();
    
            Assert(0, result);
        }
    }
