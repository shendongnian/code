    public partial class MainWindow : Window
    {
        private ListBox listBox;
        private Button myButton;
        private Grid dummyGrid;
        public MainWindow()
        {
            InitializeComponent();
            listBox = new ListBox();
            Content = listBox;
            myButton = new Button { Content = "Click me" };
            myButton.Click += (sender, args) =>
            {
                myButton.Content = "Lorem ipsum dolor sit amet.";
                myButton.FontSize = 24;
            };
            dummyGrid = new Grid();
            dummyGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            dummyGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            dummyGrid.Children.Add(myButton);
            var frameworkElement =
                FrameworkElementAdapters.ContractToViewAdapter(
                    FrameworkElementAdapters.ViewToContractAdapter(dummyGrid));
            listBox.Items.Add(frameworkElement);
            // Automatically adjust HwndHost's size when the grid changes
            dummyGrid.SizeChanged += (sender, args) =>
            {
                frameworkElement.Width = args.NewSize.Width;
                frameworkElement.Height = args.NewSize.Height;
            };            
        }
    }
