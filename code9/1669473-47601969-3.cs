    public class ViewModel : Notifier
    {
        private Tile _tile;
        public ObservableCollection<Tile> Tiles { get; } = new ObservableCollection<Tile> {
            new Tile(), new Tile(), new Tile(), 
            new Tile(), new Tile(), new Tile(), 
            new Tile(), new Tile(), new Tile()
        };
        public Tile SelectedTile
        {
            get
            {
                return _tile;
            }
            set
            {
                _tile = value;
                Notify();
                UpdateName(value);
            }
        }
        private void UpdateName(Tile value)
        {
            if(value.Name == "Click me")
                value.Name = "Woot!";
            else
                value.Name = "Click me";
        }
    }
