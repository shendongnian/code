    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    ...
    
-
    public ObservableCollection<HistoryLog> Audits
    {
        get
        {
            return audits;
        }
        set
        {
            audits = value;
            OnPropertyChanged("Audits");
        }
    }
    ObservableCollection<HistoryLog> audits;
