    public class ADPropertyValidator : AbstractValidator<Property>
    {
        public ADPropertyValidator()
        {
            When(p => p.Name.Equals("sAMAccountName"), () =>
            {
                RuleFor(p => p.input)
                    .NotEmpty()
                    .MyOtherValidationRule();
            });
            When(p => p.Name.Equals("anotherName"), () =>
            {
                RuleFor(p => p.input)
                    .NotEmpty()
                    .HereItIsAnotherValidationRule();
            });
        }
    }
    public class ADPropertiesValidator : AbstractValidator<EditPersonalInfoViewModel>
    {
        public ADPropertiesValidator()
        {
            RuleForEach(vm => vm.UserPropertyList)
                .SetValidator(new ADPropertyValidator());
        }
    }
