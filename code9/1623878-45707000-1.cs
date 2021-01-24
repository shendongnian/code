    public class MainViewModel: ReactiveObject
    {
        // Message to be shown.
        private ObservableAsPropertyHelper<string> message;
        public string Message => message.Value;
        // Command that runs async process, the result is the message to be shown.
        public ReactiveCommand<Unit, string> Run { get; private set; }  
        public MainViewModel()
        {   
            Run = ReactiveCommand.CreateFromObservable(() => Observable.StartAsync(Process));
            // Merge various message sources and set message property.
            message = Observable.Merge(Run, Run.ThrownExceptions.Select(x => x.Message))
                .Select(msg => Observable.Return(msg).Concat(Observable.Return("").Delay(4, RxApp.MainThreadScheduler))) // 1
                .Switch() // 2
                .ToProperty(this, x => x.Message);
        }
    }
