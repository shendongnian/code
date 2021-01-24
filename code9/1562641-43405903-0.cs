    public class MyObject : ReactiveObject {
    
        private bool _Completed;
        public bool Completed {
            get => _Completed;
            set => this.RaiseAndSetIfChanged(ref _Completed, value);
        }
    
    }
