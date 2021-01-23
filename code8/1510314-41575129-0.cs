    public partial class MainWindow : MetroWindow
    {
        public List<UIElement> LeftWindowCommands { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            LeftWindowCommands = new List<UIElement>();
            var StackPanelForTab1 = new StackPanel() { Orientation = Orientation.Horizontal };
            var StackPanelForTab2 = new StackPanel() { Orientation = Orientation.Horizontal };
            var StackPanelForTab3 = new StackPanel() { Orientation = Orientation.Horizontal };
            // You can add as many children as you want
            StackPanelForTab1.Children.Add(new Button { Content = "MyButton #1", Foreground = Brushes.Red });
            StackPanelForTab2.Children.Add(new Button { Content = "MyButton #2", Foreground = Brushes.Black });
            StackPanelForTab3.Children.Add(new Button { Content = "MyButton #3", Foreground = Brushes.Blue });
            // MUST add items in the right order on the list
            // MUST have the sabe amount of tabs on the TabControl and items on the list
            LeftWindowCommands.Add(StackPanelForTab1);
            LeftWindowCommands.Add(StackPanelForTab2);
            LeftWindowCommands.Add(StackPanelForTab3);
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                MyContentControl.Content = LeftWindowCommands[MyTabControl.SelectedIndex];
            }
        }
    }
