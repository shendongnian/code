    public partial class Window3 : Window
    {
        Window3ViewModel viewModel = new Window3ViewModel();
        public Window3()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            viewModel.Validate();
        }
    }
    public class Window3ViewModel : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, string> _validationErrors = new Dictionary<string, string>();
        public void Validate()
        {
            bool isValid = !string.IsNullOrEmpty(_text);
            bool contains = _validationErrors.ContainsKey(nameof(Text));
            if (!isValid && !contains)
                _validationErrors.Add(nameof(Text), "Mandatory field!");
            else if (isValid && contains)
                _validationErrors.Remove(nameof(Text));
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(nameof(Text)));
        }
        public bool HasErrors => _validationErrors.Count > 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public IEnumerable GetErrors(string propertyName)
        {
            string message;
            if (_validationErrors.TryGetValue(propertyName, out message))
                return new List<string> { message };
            return null;
        }
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value; 
            }
        }
    }
