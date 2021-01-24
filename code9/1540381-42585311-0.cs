    public interface ICloseable
    {
        event EventHandler CloseRequest;
    }
    public class WindowViewModel : BaseViewModel, ICloseable
    {
        public event EventHandler CloseRequest;
        protected void RaiseCloseRequest()
        {
            var handler = CloseRequest;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow(ICloseable context)
        {
            InitializeComponent();
            context.CloseRequest += (s, e) => this.Close();
        }
    }
