    public class HomeViewModel : ReactiveObject
    {
        private string ModelString;
    
        public string EnteredText
        {
            get { return ModelString; }
            set { this.RaiseAndSetIfChanged(ref ModelString, value); }
        }
    
        private string statusString = string.Empty;
    
        public string Status
        {
            get { return statusString; }
            set { this.RaiseAndSetIfChanged(ref statusString, value); }
        }
    
        public ReactiveCommand<System.Reactive.Unit, bool> OKCmd { get; private set; }
    
        public HomeViewModel()
        {
            var OkCmdObs = this.WhenAny(vm => vm.EnteredText,
                s => !string.IsNullOrWhiteSpace(s.Value));
            OKCmd = ReactiveCommand.CreateFromObservable(() =>
            {
                Status = EnteredText + " is saved.";
                return Observable.Return(true);
            }, OkCmdObs);
        }
    }
