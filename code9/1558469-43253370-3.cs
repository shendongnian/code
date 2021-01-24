    namespace ClassLibrary {
        public class HeavyWorkerClass : INotifyPropertyChanged {
            private int _progress;
            public int Progress {
                get { return _progress; }
                set {
                    _progress = value;
                    NotifyPropertyChanged();
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            public void StartWork() {
                for (int i = 0; i <= 100; i++) {
                    Progress = i;
                    Thread.Sleep(50);
                }
            }
        }
    }
