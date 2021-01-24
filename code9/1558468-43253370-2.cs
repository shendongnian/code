    namespace MainProject {
        class MainWindowVM : INotifyPropertyChanged {
            private BackgroundWorker _counterWorker;
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            private ClassLibrary.HeavyWorkerClass _heavyWorker;
            public ClassLibrary.HeavyWorkerClass HeavyWorker {
                get { return _heavyWorker; }
            }
            public MainWindowVM() {
                _heavyWorker = new ClassLibrary.HeavyWorkerClass();
                _counterWorker = new BackgroundWorker();
                _counterWorker.DoWork += new DoWorkEventHandler(_counterWorker_DoWork);
                _counterWorker.RunWorkerAsync(_heavyWorker);
            }
            private void _counterWorker_DoWork(object sender, DoWorkEventArgs e) {
                var heavyWorker = (ClassLibrary.HeavyWorkerClass)e.Argument;
                heavyWorker.StartWork();
                System.Windows.MessageBox.Show("Work completed!");
            }
        }
    }
