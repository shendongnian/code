    public interface IView
    {
        bool SimulateClick(object param);
    }
    public partial class View : UserControl, IView
    {
        public View()
        {
            InitializeComponent();
            DataContext = new ViewModel(this);
        }
        public bool SimulateClick(object param)
        {
            //...
        }
    }
