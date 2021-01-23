    namespace CheckboxesAndPages
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                private thirdPage _thirdPage;
                private SecondPage _SecondPage;
                private ThirdPage ThirdPage 
                {
                   get
                   { 
                       _thirdPage = _thirdPage !=null ? new thirdPage();
                       return _thirdPage;
                   }
                   set
                   {
                       _thirdPage = value;
                   }
               }
               
               private SecondPage SecondPage
                {
                   get
                   { 
                       _SecondPage= _SecondPage!=null ? new SecondPage();
                       return _SecondPage;
                   }
                   set
                   {
                       _SecondPage= value;
                   }
               }
                private SecondPage _SecondPage;
                public MainWindow()
                {
                    InitializeComponent();
        
                }
        
                bool isCHecked = true;
        
                private void button_Click(object sender, RoutedEventArgs e)
                { 
                    main.Content = SecondPage;
                }
        
                private void button1_Click(object sender, RoutedEventArgs e)
                {
                    main.Content = ThirdPage;
                }
            }
