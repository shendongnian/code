    namespace DataGridTest
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow( )
        {
            SwapCommand = new RelayCommand( OnExecuteSwap );
            InitializeComponent( );
            for( int i = 0; i < 10; i++ )
            {
                Classes.Add(
                    new MyClass
                    {
                        First = 10,
                        Second = 20,
                        Third = 30,
                        Fourth = 40
                    } );
            }
          
        }
        private void OnExecuteSwap( )
        {
            Classes.Clear( );
            for( int i = 0; i < 10; i++ )
            {
                Classes.Add(
                    new MyClass
                    {
                        First = 50,
                        Second = 60,
                        Third = 70,
                        Fourth = 80
                    } );
            }
        }
        public ICommand SwapCommand { get; }
        public ObservableCollection<MyClass> Classes { get; } =
            new ObservableCollection<MyClass>( );
    }
    }
