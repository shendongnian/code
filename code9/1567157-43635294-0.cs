    public class Foo
    {
        private AutoResetEvent AutoReset { get; }
        private IBar CurrentBar { get; set; }
        public event EventHandler<MoveEventArgs> OnValueInjected;
        public Foo()
        {
            AutoReset = new AutoResetEvent(false);
            StartFoo();
        }
        private async void StartFoo()
        {
            await Task.Factory.StartNew(() =>
            {
                while (State != FooState.Finished)
                {
                    IResult result = CurrentBar.WaitForValue(); // This is blocking function, wait for a value
                    OnValueInjected?.Invoke(this, new ResultEventArgs(result));
                    AutoReset.Set();
                    // .. rest of the loop
                }
            });
        }
        public async void InjectValue(int a, int b)
        {
            if (CurrentBar.Inject(a,b))
            {
                AutoReset.WaitOne();
            }
        }
    }
