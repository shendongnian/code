    public partial class MainWindow : Window
    {
        public class ExampleItem
        {
            public int Value { get; set; }
            public bool IsSelected { get; set; }
        }
        public class Example
        {
            public List<ExampleItem> Items { get; } = new List<ExampleItem>();
            public Example()
            {
                for (var i = 0; i < 10; i++)
                {
                    Items.Add(new ExampleItem { Value = i });
                }
            }
        }
        public List<Example> Examples { get; } = new List<Example>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Examples.Add(new Example());
            Examples.Add(new Example());
        }
    }
