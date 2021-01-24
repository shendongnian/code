    public interface IView
    {
        double Top { get; }
        double Left { get; }
        double Height { get; }
        double Width { get; }
    }
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel(this);
        }
    }
    public class ViewModel
    {
        private readonly IView _view;
        public ViewModel(IView view)
        {
            _view = view;
        }
        //...
    }
