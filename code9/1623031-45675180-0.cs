    public class MyViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public virtual string this[string columnName]
        {
            get
            {
                if (columnName == "Text1")
                {
                    if (string.IsNullOrEmpty(Text1))
                    {
                        return "Text is required!";
                    }
                }
                return null;
            }
        }
        private string _Text1;
        public string Text1
        {
            get { return _Text1; }
            set { _Text1 = value; RaisePropertyChangedEvent(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent([CallerMemberName]string prop = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(prop));
        }
    }
