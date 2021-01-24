    public class PersonViewModel : Notifier
    {
        private Person _person;
    
        public Person Person
        {
            get { return _person; }
            set
            {
                _person= value;
                RaisePropertyChanged(); //No need to pass "Person".
            }
        }
    }
