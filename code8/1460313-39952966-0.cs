    public class AlertViewModel : INotifyPropertyChanged
    {
        public RelayCommand CmdStop { get; set; }
        public AlertViewModel()
        {
             ...
             CmdStop = new RelayCommand(() => {
                if (Timer != null)
                {
                    Timer.Stop();
                }
            });
        }
    }
