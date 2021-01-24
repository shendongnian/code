    class MultiplePeopleContainer
    {
        public ICollection<Person> AllPersons { get; } // list of all selectable person objects
        public ICollection<PersonContainer> DisplayedPersons { get; } // list of displayed persons where the actual person can be selected from combobox
    }
    
    class PersonContainer
    {
        public Person SelectedPerson { get; set; } // person whos properties should be displayed
    }
    
    class Person
    {
        public string Name { get; set; }
    
        public Image Symbol { get; set; }
    }
