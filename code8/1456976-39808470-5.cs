    namespace CheckboxesAndPages
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private thirdPage _thirdPage;
            private SecondPage _SecondPage;
            public MainWindow()
            {
                InitializeComponent();
    
            }
    
            bool isCHecked = true;
    
            private void button_Click(object sender, RoutedEventArgs e)
            {
                _SecondPage = _SecondPage != null ? new SecondPage(); 
                main.Content = _SecondPage;
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                _thirdPage = _thirdPage !=null ? _thirdPage : new thirdPage();
                main.Content = _thirdPage;
            }
        }
