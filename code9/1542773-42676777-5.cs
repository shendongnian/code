    using SimpleMvvmToolkit;
    
    namespace LocationToNamespace.Derp
    {
        public class YourViewModel : ViewModelBase<YourViewModel>
        {
            private string _selectedValue;
            public string SelectedValue
            {
                get
                {
                    return _selectedValue;
                }
                set
                {
                    _selectedValue = value;
                    NotifyPropertyChanged(m => m.SelectedValue);
                }
            }
            public void OnNewClicked()
            {
                SelectedValue = string.Empty;
            }
        }
    }
