    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Bestellung> Bestellungen {get; set;} = new ObservableCollection<Bestellung>();
        
        //Implement INotifyPropertyChanged here
    }
