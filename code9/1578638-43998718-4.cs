    public class Class1: INotifyPropertyChanged
    {
    
        private int _id;
        private string _question;
    
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
    
        public string question
        {
            get { return _question; }
            set
            {
                _question = value;
                RaisePropertyChanged("question");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
