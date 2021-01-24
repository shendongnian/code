    private int GridRow = 2;
    private int GridColumn = 2;
    Label labelTimer=null;
            public GameWindow()
            {
            InitializeComponent();
            Grid TheGrid = GameGridOfficial;
            for(var rij = 0; rij < 5; rij++)
            {
                GridColumn = 2;
                for(var kolom = 0; kolom < 2; kolom++)
                {
                    StackPanel sp = new StackPanel();
                    sp.SetValue(Grid.RowProperty, GridRow);
                    sp.SetValue(Grid.ColumnProperty, GridColumn);
                    sp.SetValue(Grid.RowSpanProperty, 2);
                    sp.SetValue(Grid.ColumnSpanProperty, 2);
                    sp.HorizontalAlignment = HorizontalAlignment.Center;
                    sp.VerticalAlignment = VerticalAlignment.Center;
                    sp.Loaded += Sp_Loaded;
                    TheGrid.Children.Add(sp);                    
                    GridColumn += 2;
                }
                GridRow += 2;
            }
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += timer_Tick;
        timer.Start();
        }
        private void Sp_Loaded(object sender, RoutedEventArgs e)
        {
        StackPanel sp = new StackPanel();
        if (sender is StackPanel)
            sp = (StackPanel)sender;
        labelTimer = new Label();
        labelTimer.Width = GridOfficial.ColumnDefinitions[3].ActualWidth / 2;
        labelTimer.Height = GridOfficial.RowDefinitions[2].ActualHeight;
        labelTimer.Content = "00:00:00";
        labelTimer.FontFamily = new FontFamily("Impact");
        labelTimer.FontSize = 32;
        labelTimer.Background = new SolidColorBrush(Colors.Aquamarine);
        labelTimer.HorizontalContentAlignment = HorizontalAlignment.Center;
        labelTimer.VerticalContentAlignment = VerticalAlignment.Center;
        labelTimer.Name = "labelTickTimer";
        sp.Children.Add(labelTimer);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            labelTimer.Content = DateTime.Now.ToLongTimeString();
        }
