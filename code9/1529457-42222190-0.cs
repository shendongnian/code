    public class Foo
    {
        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set {
                _dateOfBirth = value;
                if(Age != null)
                   Age.DateOfBirth = value;
            }
        }
        public Age Age { get; set; }
    }
