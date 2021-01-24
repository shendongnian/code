            /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void button_Click(object sender, RoutedEventArgs e)
            {
                VisualStateManager.GoToElementState(this.MyGrid, "State1", false);
            }
        }
    }
