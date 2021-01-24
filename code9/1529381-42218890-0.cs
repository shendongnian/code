    public class SomeApi
    {
        private IMapper mapper;
        public SomeApi(IMapper mapper)
        {
            this.mapper = mapper;
        }
        // other code here
    
        public PersonDto FindByName(string name)
        {
            var person = dbContext.People.FirstOrDefault(_ => _.Name == name);
    
            // mapper is IMapper
            return mapper.Map<PersonDto>(person);
        }
    }
