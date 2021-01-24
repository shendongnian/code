    public class Student : NotifyPropertyChanged
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged("Address"); }
        }
        int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged("Age"); }
        }
    }
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    } 
