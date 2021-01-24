    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MyClass() { Name = "Name0", Value = true, Names = new string[2] { "Name1", "Name2" } };
    }
    public class MyClass
    {
        public string Name { get; set; }
        public bool Value { get; set; }
        public string[] Names { get; set; }
    }
