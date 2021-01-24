    public class ClassACollectionValidator : AbstractValidator<IEnumerable<A>>
    {
        public ClassACollectionValidator ()
        {
            RuleForEach(x => x.Id).NotEmpty().WithMessage("The Idcan't be Empty or Zero");
            RuleForEach(x => x.Name).NotEmpty().Length(10).WithMessage("Name Should be Six Char length");
        }
    }
