    abstract class PersonCommand
    {
        Person Person { protected get; } // you can call this payload, or person, w/e
        PersonCommand(Person person)
        {
            Person = person;
        }
    
        public abstract void Apply(); // can be called Execute or Process as well, or w/e. problem domain.
    }
