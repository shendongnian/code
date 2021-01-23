    public class Student : INotifyPropertyChanged
    {
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set
            {
                FirstName = value.Split(" ".ToCharArray())?[0];
                LastName = value.Split(" ".ToCharArray())?[1];
                FirePropertyChanged("FullName");
                FirePropertyChanged("FirstName");
                FirePropertyChanged("LastName");
            }
        }
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                FullName = value + " " + LastName;
            }
        }
        private string lastName;
        public string LastName
        {
            get
            {
                return firstName;
            }
            set
            {
                lastName = value;
                FullName = FirstName + " " + value;
            }
        }
        public void FirePropertyChanged (string PropertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
