    public class DynamicCellsDataContext:BaseObservableObject
    {
        public DynamicCellsDataContext()
        {
            DataGridSource = new ObservableCollection<object>
            {
                new PresentedByTextBox("Hello world!!!"),
                new PresentedByCheckBox(true),
                new PresentedByComplexBox("Hello world!!!", true),
            };
        }
        public ObservableCollection<object> DataGridSource { get; set; }
    }
    public class PresentedByComplexBox:BaseObservableObject
    {
        private string _helloWorld;
        private bool _checked;
        public string HelloWorld    
        {
            get { return _helloWorld; }
            set
            {
                _helloWorld = value;
                OnPropertyChanged();
            }
        }
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                OnPropertyChanged();
            }
        }
        public PresentedByComplexBox(string helloWorld, bool isChecked)
        {
            HelloWorld = helloWorld;
            Checked = isChecked;
        }
    }
    public class PresentedByCheckBox:BaseObservableObject
    {
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged();
            }
        }
        public PresentedByCheckBox(bool isChecked)
        {
            IsChecked = isChecked;
        }
    }
    public class PresentedByTextBox:BaseObservableObject
    {
        private string _helloWorld;
        public string HelloWorld
        {
            get { return _helloWorld; }
            set
            {
                _helloWorld = value;
                OnPropertyChanged();
            }
        }
        public PresentedByTextBox(string helloWorld)
        {
            HelloWorld = helloWorld;
        }
    }
