    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // Don't make fields public. If you do want to expose the list
        // use a public read-only property. And even there, think carefully
        // about whether you want callers to be able to modify the list; you
        // can return a `ReadOnlyCollection<string>` that wraps your list if
        // you only want callers to be able to examine the contents, rather than
        // modify it.
        //
        // Also, make any field that you never change "readonly".
        private readonly List<string> namesList = new List<string>();
        // Here's the index that keeps track of which string is selected
        private int _index;
    
        public string SelectedName
        {
            get { return namesList[_index]; }
        }
    
        public MainWindow()
        {
            InitializeComponent();
    
            namesList.Add("ABC");
            namesList.Add("DEF");
            namesList.Add("GHI");
    
            this.DataContext = this;
        }
    
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (_index > 0)
            {
                _index--;
                NotifyPropertyChanged(nameof(SelectedName));
            }
            // I don't know what you expect this to do. You are setting the window's
            // "IsEnabled" property to false, which doesn't seem useful. More likely,
            // you intend to set the "Previous" button's enabled state, but even there
            // you really only want to set it to false if the _index value is 0. If the
            // _index value had been 2 and was just set to 1, you still want the
            // "Previous" button enabled. This would actually be an excellent place for
            // you to learn how to implement an ICommand, to have its CanExecute() method
            // return a value based on the _index value (where the "Previous" ICommand
            // object would return true unless _index is 0, and the "Next" ICommand
            // object would return true unless _index is namesList.Count - 1). Then you
            // can bind the button's "Command" property to the appropriate ICommand
            // object for the button and WPF will automatically deal with enabling
            // or disabling the button according to the command's state
            this.IsEnabled = false;
        }
    
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (_index < namesList.Count - 1)
            {
                _index++;
                NotifyPropertyChanged(nameof(SelectedName));
            }
    
            // See comment above.
            this.IsEnabled = false;
        }
        protected void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.DynamicInvoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
