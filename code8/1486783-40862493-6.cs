        public class MyJob
        {
            private readonly Factory Factory;
            public MyJob(Factory factory)
            {
                Factory = factory;
            }
            public void Execute(IJobExecutionContext context)
            {
                using (Factory.BeginScope())
                {
                    var repo = Factory.Create<IFooRepository>();
                    // Do stuff
                    Factory.Release(repo);
                }
            }
        }
