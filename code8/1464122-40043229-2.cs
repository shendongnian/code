    public class MyViewModel1 //: INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                //OnPropertyChanged();
            }
        }
    }
