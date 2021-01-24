    public class ClassAValidator : AbstractValidator<A>
    {
        public ClassAValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can't be empty");
            RuleFor(x => x.Name).NotEmpty().Length(10).WithMessage("Name should have length 10");
        }
    }
    public class ClassACollectionValidator : AbstractValidator<IEnumerable<A>>
    {
        public ClassACollectionValidator ()
        {
            RuleFor(x =>x).SetCollectionValidator(new ClassAValidator());
        }
    }
