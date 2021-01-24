    public class MainViewModel : ReactiveObject
    {
        private bool canExecute;
        public MainViewModel()
        {
            this.CanExecute = true;
            var canExecAsyncProcess = this.WhenAnyValue(x => x.CanExecute);
            this.AsyncProcess = ReactiveCommand.CreateFromTask(AsyncProcessImpl, canExecAsyncProcess);
        }
        public bool CanExecute
        {
            get { return this.canExecute; }
            set { this.RaiseAndSetIfChanged(ref this.canExecute, value); }
        }
        public ReactiveCommand<Unit, Unit> AsyncProcess { get; } 
        private async Task AsyncProcessImpl()
        {
            this.CanExecute = false;
            await Task.Delay(TimeSpan.FromSeconds(5)); // just for testing
            this.CanExecute = true;
        }
    }
