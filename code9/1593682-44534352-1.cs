    public class MyViewModel : ViewModelBase
        {
            private RelayCommand _refreshCommand;
            public TimeSpan Duree { get; set; }
    
            public RelayCommand RefreshCommand => _refreshCommand ??
                                                  (_refreshCommand = new RelayCommand(async () => { await Refresh(); }));
    
            private Task Refresh()
            {
                return Task.Run(() =>
                {
                    var current = Process.GetCurrentProcess();
                    Duree = DateTime.Now.Subtract(current.StartTime);
                    RaisePropertyChanged(() => Duree);
                });
            }
        }
