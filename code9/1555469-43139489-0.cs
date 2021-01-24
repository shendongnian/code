    public partial class DataBinding : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if ( PropertyChanged != null )
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        string text;
        public string TextString
        {
            get { return text; }
            set { text = value; NotifyPropertyChanged(); }
        }
        // rest of your code here
    }
