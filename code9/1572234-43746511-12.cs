    public class ClassACollectionValidator : AbstractValidator<IEnumerable<A>>
    {
        public ClassACollectionValidator ()
        {
            RuleForEach(x => x.Id).NotEmpty().WithMessage("Id can't be empty");
            RuleForEach(x => x.Name).NotEmpty().Length(10).WithMessage("Name should have length 10");
        }
    }
