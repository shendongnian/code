    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Collection.Add(new Work
            {
                Name = "Clean my place",
                WorkItems = new ObservableCollection<Work>()
                {
                    new Work { Name = "Today", IsFinalItem =true  },
                    new Work { Name = "Tomorrow", IsFinalItem =true  },
                    new Work { Name = "Monday", IsFinalItem =true  },
                }
            });
            Collection.Add(new Work { Name = "Clean Jim's place" });
            Collection.Add(new Work { Name = "Fix pc" });
            Collection.Add(new Work
            {
                Name = "Free",
                WorkItems = new ObservableCollection<Work>()
                {
                    new Work { Name = "Today", IsFinalItem =true  },
                    new Work { Name = "Tomorrow", IsFinalItem =true  },
                    new Work { Name = "Monday", IsFinalItem =true  },
                }
            });
        }
        public ObservableCollection<Work> Collection { get; set; } = new ObservableCollection<Work>();
    }
