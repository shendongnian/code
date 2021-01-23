     public class Country {
    
            public Country() {
                this.Leagues = new ObservableCollection<League>();
            }
            public string Name { get; set; }
    
            public ObservableCollection<League> Leagues { get; }
    
        }
    
        public class League {
    
            public League() {
                this.Events = new ObservableCollection<Event>();
            }
            public string Name { get; set; }
    
            public ObservableCollection<Event> Events { get; }
        }
    
        public class Event : INotifyPropertyChanged {
            private string _matchName;
            public string MatchName {
                get { return _matchName; }
                set {
                    _matchName = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
            }
        }
