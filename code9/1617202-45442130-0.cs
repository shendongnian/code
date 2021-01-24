    public partial class MainWindow : Window
    {
        pulic MainWindow(ViewModel vm)
        {
             InitializeComponent();
             DataContext = vm;
        }
    }
