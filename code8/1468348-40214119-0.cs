    public class BranchAddModelValidator : AbstractValidator<BranchAddModel>
    {
        public BranchAddModelValidator()
        {
            this.AddDefaultNameValidation(x => x.BranchName);
            
            RuleFor(x => x.ServiceTypeId)
                .NotEmpty();
            RuleFor(x => x.BaseCurrencyId)
                .NotEmpty();
            RuleFor(x => x.TimezoneId)
                .NotEmpty();
        }
    }
    public static class AbstractValidatorExtensions
    {
        public static void AddDefaultNameValidation<T>(this AbstractValidator<T> validator, Expression<Func<T, string>> property)
        {
            validator.RuleFor(property)
                .NotEmpty()
                .Length(0, 128);
        }
    }
