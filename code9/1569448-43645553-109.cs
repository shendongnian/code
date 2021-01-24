     public interface ISelectable
        {
            bool CheckStatus { get; set; }
        }
    public class CheckBoxListModel : INotifyPropertyChanged, ISelectable
    {
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                RaiseChanged("Text");
            }
        }
    
        private bool checkStatus;
        public bool CheckStatus
        {
            get { return checkStatus; }
            set
            {
                checkStatus = value;
                RaiseChanged("CheckStatus");
            }
        }
    
        private void RaiseChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
       }
    }
