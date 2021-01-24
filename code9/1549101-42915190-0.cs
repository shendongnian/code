    public partial class MainWindow : Window
     {
       public MainWindow()
       {
         // attempting to find elements
         // before the call to InitializeComponent();
         // results in null references
         // this won't work.
          WorkWithLabels();
         InitializeComponent();
         this.Loaded += MainWindow_Loaded;
       }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
          // this works.
          WorkWithLabels();
        }
        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
          // so does this.
          WorkWithLabels();
        }
        private void WorkWithLabels()
        {
          Label lbl;
          var samplingRate = 1.5;
          for (int n = 1; n <= 12; n++)
          {
            lbl = (Label)FindName($"f{n}");
            lbl.Content = $"{samplingRate / 2 / n}kHz";
          }
        }
      }
