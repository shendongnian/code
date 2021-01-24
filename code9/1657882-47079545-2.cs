    public class CatClientModel
    {
        public ObservableCollection<Animal> SomeDynamicList { get; } = new ObservableCollection<Animal>();
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CatClientModel();
        }
    }
