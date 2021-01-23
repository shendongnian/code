    class Person : ViewModelBase // use a base from any MVVM framework or roll your own
    {
        private string _firstName;
        public string FirstName 
        { 
           get { return _firstName; }
           set 
           { 
               _firstname = value;
               RaisePropertyChanged(nameof(FirstName));
               RaisePropertyChanged(nameof(IsRealPerson));
           }
        }
    
        // the same for the other properties
        // IsRealPerson can remain as is
    
     }
  
