    public class MainViewModel : ReactiveObject
    {
        private bool canExecute;
        public MainViewModel()
        {
            this.CanExecute = true;
            // the command creation, this.WhenAnyValue(x => x.CanExecute) is an observable that will change the enabled/disabled command when CanExecute changes
            this.AsyncProcess = ReactiveCommand.CreateFromTask(AsyncProcessImpl, this.WhenAnyValue(x => x.CanExecute));
        }
        public bool CanExecute
        {
            get { return this.canExecute; }
            set { this.RaiseAndSetIfChanged(ref this.canExecute, value); }
        }
        public ReactiveCommand<Unit, Unit> AsyncProcess { get; } 
        private async Task AsyncProcessImpl()
        {
            // changing CanExecute to false will disable the button
            this.CanExecute = false;
            await Task.Delay(TimeSpan.FromSeconds(5)); // just for testing
            // CanExecute back to true, the button will be enabled
            this.CanExecute = true;
        }
    }
