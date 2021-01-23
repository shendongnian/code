    namespace ViewModel
    {
        #region ViewModelBase
        public class ViewModelBase : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] String propName = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            #endregion INotifyPropertyChanged
        }
        #endregion ViewModelBase
        //  This is the class we'll put in the grid. 
        public class CodeItem : ViewModelBase
        {
            private String _value = default(String);
            public String Value
            {
                get { return _value; }
                set
                {
                    if (value != _value)
                    {
                        _value = value;
                        OnPropertyChanged();
                    }
                }
            }
        }
        public class VMText : ViewModelBase
        {
            public String CodeString
            {
                get {
                    return String.Join("\n", Codes.Select(ci => ci.Value));
                }
                set
                {
                    var q = (value ?? "")
                                .Split(new[] { '\n' })
                                .Select(s => new CodeItem { Value = s });
                    Codes = new ObservableCollection<CodeItem>(q);
                }
            }
            #region Codes Property
            private ObservableCollection<CodeItem> _codes = default(ObservableCollection<CodeItem>);
            public ObservableCollection<CodeItem> Codes
            {
                get { return _codes; }
                set
                {
                    if (value != _codes)
                    {
                        _codes = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Codes Property
        }
    }
