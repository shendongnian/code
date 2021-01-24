    public class TestViewModel : INotifyPropertyChanged
    {
        public TestViewModel ()
        {
            Pokémons = new ObservableCollection<Pokémon>
            {
                new Pokémon {Id = 1, Name = "Bulbasaur", Types= Types.Grass },
                new Pokémon {Id = 4, Name = "Charmander",Types=  Types.Fire},
                new Pokémon {Id = 7, Name = "Squirtle", Types= Types.Water},
                new Pokémon {Id = 25, Name = "Pikachu",Types=  Types.Electric},
                new Pokémon {Id = 2, Name = "Ivysaur", Types= Types.Grass}
            };
    
        }
    
        private ObservableCollection<Pokémon> _pokémons;
    
        public ObservableCollection<Pokémon> Pokémons
        {
            get { return _pokémons; }
            set
            {
                _pokémons = value;
                OnPropertyChanged(nameof(Pokémons));
            }
        }
        
    
        private Pokémon _selectedPokemon;
    
        public Pokémon SelectedPokemon
        {
            get { return _selectedPokemon; }
            set
            {
                _selectedPokemon = value;
                OnPropertyChanged();
            }
        }
    
    
    
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
    }
