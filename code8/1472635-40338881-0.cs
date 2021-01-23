     public Strangelaout()
     {
         this.InitializeComponent();
         Window.Current.SizeChanged += Current_SizeChanged;
     }
     private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
     {
         g1.Width = mainGrid.ActualWidth;
         g1.Height = mainGrid.ActualHeight / 2;
     }
     private void Button_Click(object sender, RoutedEventArgs e)
     {
         g1.Width = mainGrid.ActualWidth;
         g1.Height = mainGrid.ActualHeight / 2;
     }
