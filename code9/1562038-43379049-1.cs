    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Collection.Add(new Work
            {
                Name = "Dude",
                WorkItems = new ObservableCollection<Work>()
                {
                    new Work { Name = "123" },
                    new Work { Name = "897" },
                    new Work { Name = "25" },
                    new Work { Name = "98" },
                }
            });
            Collection.Add(new Work { Name = "Random" });
            Collection.Add(new Work { Name = "One" });
            Collection.Add(new Work { Name = "Say" });
        }
        public ObservableCollection<Work> Collection { get; set; } = new ObservableCollection<Work>();
    }
