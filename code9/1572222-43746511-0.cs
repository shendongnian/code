    public class ClassAValidator : AbstractValidator<A>
    {
        public ClassAValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("The Idcan't be Empty or Zero");
            RuleFor(x => x.Name).NotEmpty().Length(10).WithMessage("Name Should be Six Char length");
        }
    }
    public class ClassACollectionValidator : AbstractValidator<IEnumerable<A>>
    {
        public ClassACollectionValidator ()
        {
            RuleFor(x =>x).SetValidator(new ClassAValidator());
        }
    }
