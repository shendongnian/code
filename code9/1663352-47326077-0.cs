    public MainWindow()
    {
        InitializeComponent();
        var skip = new[] { Key.None, Key.DeadCharProcessed };
        foreach (Key value in Enum.GetValues(typeof(Key)))
            if (!skip.Contains(value))
                InputBindings.Add(new KeyBinding { Command = new MyCommand(value.ToString()), Key = value });
    }
    public class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public string Text { get; }
        public MyCommand(string text) { Text = text; }
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => MessageBox.Show(Text);
    }
