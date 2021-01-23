    public class MyClassViewModel : INotifyPropertyChanged, IDisposable
    {
        private BaseClass myClassBase;
        public void Dispose()
        {
            if (myClassBase != null) myClassBase.PropertyChanged -= OnBaseClassPropertyChanged;
        }
    
        public BaseClass MyClassBase {
            get {
                return myClassBase;
            }
            set {
                if (myClassBase != null) myClassBase.PropertyChanged -= OnBaseClassPropertyChanged;
                myClassBase = value;
                myClassBase.PropertyChanged += OnBaseClassPropertyChanged;
            }
        }
        private void OnBaseClassPropertyChanged(object sender, PropertyChangedEventArgs args) {
            RaisePropertyChanged(args.PropertyName);
        }
        // forwarded properties (Title and Description) go here
    }
