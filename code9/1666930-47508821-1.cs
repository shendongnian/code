    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            // Create map that is concidered to being a model that defines the content
            // of the map
            var map = new Map();
            // Add your layers to the map
            var testServicePath = "https://services.arcgisonline.com/ArcGIS/rest/services/World_Topo_Map/MapServer";
            map.Layers.Add(new ArcGISTiledMapServiceLayer(new Uri(testServicePath)));
            // map.Layers.Add(new ArcGISLocalTiledLayer("add your path here"));
            Map = map;
        }
        private Map _map;
        public Map Map
        {
            get
            {
                return _map;
            }
            set
            {
                _map = value;
                NotifyPropertyChanged(nameof(Map));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
