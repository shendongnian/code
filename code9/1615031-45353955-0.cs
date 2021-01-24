    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(ViewportCommands.ZoomFit, (o, e) => ZoomFit(), (o, e) => e.CanExecute = true));
            CommandBindings.Add(new CommandBinding(ViewportCommands.ResetView, (o, e) => Reset(), (o, e) => e.CanExecute = true));
        }
        public void ZoomFit()
        {
        }
        public void Reset()
        {
        }
       
    }
     public static class ViewportCommands
        {
            public static RoutedCommand ResetView { get; } = new RoutedCommand(nameof(ResetView), typeof(ViewportCommands));
            public static RoutedCommand ZoomFit { get; } = new RoutedCommand(nameof(ZoomFit), typeof(ViewportCommands));
        }
