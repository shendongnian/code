    public class PersonAppService : IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;
    
        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }
    
        public void CreatePerson(CreatePersonInput input)
        {        
            person = new Person { Name = input.Name, EmailAddress = input.EmailAddress };
            _personRepository.Insert(person);
        }
    }
