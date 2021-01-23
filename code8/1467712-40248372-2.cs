            [Test]
        public void TestProxy()
        {
            var generator = new ProxyGenerator();
            var proxy = generator.CreateClassProxy<Doer>(new LogInterceptor());
            proxy.Do();
            Assert.AreEqual(1, _totalDoCount);
        }
        private static int _currentDoCount = 0;
        private static int _totalDoCount = 0;
        public class LogInterceptor : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                if (invocation.Method.Name == "Do")
                {
                    var result = Interlocked.Increment(ref _currentDoCount);
                    Interlocked.Increment(ref _totalDoCount);
                    if(result > 1) throw new Exception("thread safe violation");
                }
                
                
                invocation.Proceed();
                Interlocked.Decrement(ref _currentDoCount);
            }
        }
