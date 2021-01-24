         class Person // this is your DTO, for serialization (to JSON and so on) and this goes to database
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public int Age { get; set; }
            }
        
            class PersonVM : ReactiveObject // this is your object to display in UI
            {
                private string _firstName;
                private string _lastName;
                private int _age;
        
                public string FirstName
                {
                    get { return _firstName; }
                    set { this.RaiseAndSetIfChanged(ref _firstName, value); }
                }
        
                public string LastName
                {
                    get { return _lastName; }
                    set { this.RaiseAndSetIfChanged(ref _lastName, value); }
                }
        
                public int Age
                {
                    get { return _age; }
                    set { this.RaiseAndSetIfChanged(ref _age, value); }
                }
            }
        
           class PersonVMValidation : PersonVM, INotifyDataErrorInfo // this is your validation class, where you can check if the whole object is valid
    {
        public PersonVMValidation()
        {
            this.WhenAnyValue(x => x.AgeString).Subscribe(_ =>
            {
                if (Int32.TryParse(AgeString, out int age))
                {
                    if (age >= 0)
                    {
                        Age = age;
                        SetError("Age", null);
                    }
                    else
                    {
                        SetError("Age", "Age has to be >= 0");
                    }
                    //and so on
                }
                else
                {
                   // you reset age to 0 for example
                   SetError("Age", "Age has to be numeric");
                }
            });
            // do the same for LastName
            this.WhenAnyValue(x => x.FirstName).Subscribe(_ =>
            {
                if (string.IsNullOrEmpty(FirstName))
                {
                    SetError("FirstName", "First name cannot be empty");
                }
                else
                {
                    SetError("FirstName", null);
                }
            });
        }
        public string AgeString
        {
            get { return _ageString; }
            set { this.RaiseAndSetIfChanged(ref _ageString, value); }
        }
        protected Dictionary<string, List<string>> ErrorsDictionary = new Dictionary<string, List<string>>();
        private bool _hasErrors;
        private string _ageString;
        protected void SetError(string property, string error)
        {
            ErrorsDictionary[property] = new List<string>();
            if (error != null)
            {
                ErrorsDictionary[property].Add(error);
                HasErrors = true;
            }
            else
            {
                if (ErrorsDictionary.All(x => !x.Value.Any()))
                    HasErrors = false;
            }
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("Value"));
        }
    
                var person = someservice.GetPerson();
    
                PersonVMValidation personValidation = Mapper.Map<PersonVMValidation>(person); // notice no exceptions here, you bind UI to this
    
                var canSaveCahnges = personValidation.WhenAnyValue(x => x.HasErrors).Select(x => !x);
                SaveChanges = ReactiveCommand.Create(() =>
                {
    /*do stuff*/
                }, canSaveCahnges);
