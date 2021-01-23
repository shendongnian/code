    public class PersonSettings
    {
        public string Name;
    }
    
    public class Person
    {
        PersonSettings _settings;
    
        public Person(IOptions<PersonSettings> settings)
        {
            _settings = settings.Value;
        }
        
        public string Name => _settings.Name;
    }
