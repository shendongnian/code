    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int x = 0; x < 32; x++)
            {
                buttonGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });
                buttonGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = new GridLength(1, GridUnitType.Star)
                });
                for (int y = 0; y < 32; y++)
                {
                    var bt = new Button();
                    bt.Content = x + "" + y;
                    Grid.SetRow(bt, x);
                    Grid.SetColumn(bt, y);
                    buttonGrid.Children.Add(bt);
                    bt.Click += Bt_Click;
                }
            }
        }
        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Background = Brushes.Black;
        }
    }
