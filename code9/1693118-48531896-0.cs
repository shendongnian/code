    public class PersonValidator : AbstractValidator<Person>
    {
        public static readonly PersonValidator PersonValidator1 = new PersonValidator();
    
        static PersonValidator()
        {
            PersonValidator1.Initialize();
        }
    
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
        public void Initialize()
        {
            RuleFor(x => x.Twin).SetValidator(PersonValidator1);
        }
    }
