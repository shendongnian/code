        [Test]
        public void TestProxy()
        {
            var generator = new ProxyGenerator();
            var proxy = generator.CreateClassProxy<Doer>(new LogInterceptor());
            proxy.Do();
            Assert.True(_wasCalled);
        }
        private static bool _wasCalled = false;
        public class LogInterceptor : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                Log(invocation.Method.Name);
                invocation.Proceed();
            }
            private void Log(string name)
            {
                _wasCalled = true;
            }
        }
