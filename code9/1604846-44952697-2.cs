    public class ViewModel : ReactiveObject, ISupportsActivation
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
        public ReactiveCommand<Unit, IReactiveList<IJob>> RefreshJobList { get; }
        public Interaction<Exception, Unit> RefreshError { get; } = new Interaction<Exception, Unit>();
        ...
        public ViewModel(){
            RefreshJobList = ReactiveCommand.CreateFromTask(() => DoNetworkRequest());
            RefreshJobList.ThrownExceptions.Subscribe(ex =>
            {
                log.Error("Failed to retrieve job list from server.", ex);
                RefreshError.Handle(ex).Subscribe();
            });
            this.WhenActivated(d => d(
                Observable.Interval(TimeSpan.FromMilliseconds(300)).Select(x => Unit.Default).InvokeCommand(RefreshJobList)
            ));
        }
    }
