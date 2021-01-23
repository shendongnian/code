    public class PersonViewModel : ViewModelBase
    {
        private Genders _gender;
        private string _firstname;
        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged();
            }
        }
    
        public Genders Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }
    
        public List<Genders> AvailableGenders
    
        {
            get
            {
                return Enum.GetValues(typeof(Genders)).Cast<Genders>().ToList();
            }
        }
    
    }
