    public class LoaderViewModel 
    {
        public LoaderViewModel()
        {
            loader.DataLoaded += Loader_DataLoaded;
        }
        public Dispatcher Dispatcher {get;  set; } 
        public ObservableCollection<DataViewModel> Values { get; } = new ObservableCollection<DataViewModel>();
        ModelLoader loader = new ModelLoader();
        public void LoadData()
        {
            loader.LoadData();
        }
        private void Loader_DataLoaded(object sender, IEnumerable<DataModel> e)
        {
            Dispatcher.Invoke(() => Values.Clear());
            foreach (var item in e)
            {
                Dispatcher.Invoke(()=>Values.Add(new DataViewModel( item)));
            }
        }
    }
    public class DataViewModel : INotifyPropertyChanged
    {
        public DataViewModel(DataModel model)
        {
            Model = model;
            Model.ValueLoaded += Model_ValueLoaded;
        }
        private void Model_ValueLoaded(object sender, EventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public DataModel Model { get;private set; }
        public string Text
        {
            get { return Model.Value; }
        }
    }
    public class DataModel
    {
        public DataModel(int id)
        {
            ID = id;
            backgroundLoad = Task.Run(async() =>
                {
                    Value =await Server.GetDataValues(ID);
                }
            );
        }
        public int ID { get; set; }
        private string _Value;
        Task backgroundLoad;
        public string Value
        {
            get { return _Value; }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    ValueLoaded?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public event EventHandler ValueLoaded;
    }
    public class ModelLoader
    {
        public void LoadData()
        {
            loading = Task.Run(async()=>
            {
                var results = (await Server.GetDataIDs()).Select(i => new DataModel(i));
                DataLoaded?.Invoke(this, results);
            });
        }
        private Task loading;
        public event EventHandler<IEnumerable<DataModel>> DataLoaded;
    }
    public static class Server
    {
        private static Random rnd = new Random();
        public static async Task<IEnumerable<int>> GetDataIDs()
        {
            await Task.Delay(5000);
            return Enumerable.Range(1, 15);
        }
        public static async Task<string> GetDataValues(int id)
        {
            await Task.Delay(rnd.Next(100,6000));
            return $"Values {id}";
        }
    }
