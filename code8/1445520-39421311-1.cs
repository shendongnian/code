    public override async Task Invoke(IOwinContext context)
        {
            var testService = ServiceLocator.Current.GetInstance<ITestService>();
            testService.DoSomething();
            await Next.Invoke(context);
        }
