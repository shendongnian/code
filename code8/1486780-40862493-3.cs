        public class MyJob
        {
            private readonly Factory Factory;
            private readonly Func<IFooRepository> RepositoryFunc;
            public MyJob(Factory factory, Func<IFooRepository> repositoryFunc)
            {
                Factory = factory;
                RepositoryFunc= repositoryFunc;
            }
            public void Execute(IJobExecutionContext context)
            {
                using (Factory.BeginScope())
                {
                    var repo = RepositoryFunc();
                    // Do Stuff
                }
            }
        }
