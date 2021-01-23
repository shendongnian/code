     public class YourViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public ObservableCollection<Tour> Tours { get; set; }
        }
    
        public class Tour : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public ObservableCollection<Partie> Parties
            {
                get;
                set;
            }
    
            //...
        }
    
        public class Partie : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public ObservableCollection<Equipe> Equipes { get; set; }
    
            //...
        }
    
        public class Equipe
        {
            //...          
        }
