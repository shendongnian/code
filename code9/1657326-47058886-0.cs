    using FluentValidation;
    using System.Linq;
    
    public class InputsValidator : AbstractValidator<Inputs>
    {
        public InputsValidator()
        {
            RuleFor(x => x.MobileNos).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                                     .Must(x => x.Count() <= 100).WithMessage("List should not contain more than 100 mobile numbers.");
            RuleForEach(x => x.MobileNos).NotNull().SetValidator(new MobileValidator());
        }
    }
