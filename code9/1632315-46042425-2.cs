    public class ExpanderData : INotifyPropertyChanged
    {
        private string _someText;
    
        public string SomeText
        {
            set
            {
                _someText = value;
                OnPropertyChanged();
            }
            get
            {
                return _someText;
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    Here you have your Text that is assign to each of your Expander/TextBox, and event that will fire if you want to update your text from code behind. 
