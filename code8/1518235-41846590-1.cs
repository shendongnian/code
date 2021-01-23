    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            QuestionButtons = new ObservableCollection<QuestionButtonViewModel>();
            Loaded += MainWindow_Loaded;
        }
        public ObservableCollection<QuestionButtonViewModel> QuestionButtons { get; set; }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            grid1.DataContext = this;
        }
        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            QuestionButtons.Add(new QuestionButtonViewModel() { QuestionText = "Enter/Edit your question here" });
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            // whatever you want to do, other than setting visual things
        }
    }
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent([CallerMemberName]string prop = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class QuestionButtonViewModel : BaseViewModel
    {
        private string _QuestionText;
        public string QuestionText
        {
            get { return _QuestionText; }
            set
            {
                if (_QuestionText != value)
                {
                    _QuestionText = value;
                    RaisePropertyChangedEvent();
                }
            }
        }
    }
