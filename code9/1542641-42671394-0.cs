    public partial class MainWindow : Window
        {
            private CheckBox[] _checkboxes;
            private Dictionary<int, Action> _checkboxActions = new Dictionary<int, Action>();
    
            public MainWindow()
            {
                InitializeComponent();
    
                List<CheckBox> checkboxes = new List<CheckBox>();
    
                checkboxes.Add(CheckBox1);
                checkboxes.Add(CheckBox2);
    
                _checkboxes = checkboxes.ToArray();
    
                _checkboxActions.Add(CheckBox1.GetHashCode(), OnCheckBox1Checked);
                _checkboxActions.Add(CheckBox2.GetHashCode(), OnCheckBox2Checked);
            }
    
            public void InvokeCheckboxAction()
            {
                Action action;
    
                foreach(var checkbox in _checkboxes)
                {
                    if(checkbox.IsChecked == true)
                    {
                        int checkboxPtr = checkbox.GetHashCode();
    
                        if(_checkboxActions.TryGetValue(checkboxPtr, out action))
                        {
                            action();
                        }
                    }
                }
            }
    
            private void OnCheckBox1Checked()
            {
                Console.WriteLine("Checkbox 1 was checked");
            }
    
            private void OnCheckBox2Checked()
            {
                Console.WriteLine("Checkbox 2 was checked");
            }
        }
