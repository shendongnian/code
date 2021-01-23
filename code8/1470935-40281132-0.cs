    public class Person : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool CheckPopulationRegistry(Person p)
        {
            // TODO:
            return false;
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsRealPerson));
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsRealPerson));
                }
            }
        }
        // IdNumber is omitted
        public bool IsRealPerson => CheckPopulationRegistry(this);
        public event PropertyChangedEventHandler PropertyChanged;
    }
