    public MyClass
    {
        private async Task F1()
        {
            Debug.WriteLine("Begin F1");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Debug.WriteLine("F1 Completed");
        }
        private async Task F2(TimeSpan waitTime)
        {
            Debug.WriteLine("Begin F2");
            await Task.Delay(waitTime);
            Debug.WriteLine("F2 Completed");
        }
        private async Task F3(int count, TimeSpan waitTime)
        {
             Debug.WriteLine("Begin F3");
            for (int i = 0; i < count; ++i)
            {
                await Task.Delay(waitTime);
            }
            Debug.WriteLine("F3 Completed");
        }
    }
    public async Task ExecuteMyFunctions()
    {
        MyClass X = new MyClass();
        IEnumerable<MethodInvoker> myMethodInvokers = new MethodInvoker[]
        {
            () => X.F1(),
            () => X.F2(TimeSpan.FromSeconds(1)),
            () => X.F3(4, TimeSpan.FromSeconds(0.25)),
        }
        await myMethodInvokers.ExecuteDelegates();
    }
