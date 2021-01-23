    public class PersonalDetailViewModelValidator : AbstractValidator<PersonalDetailViewModel>
        {
        
           public PersonalDetailViewModelValidator()
                {
                    RuleFor(p => p.Address).Length(0, 99);
                    RuleFor(p => p.ZipCode).Length(0, 10);
                    RuleFor(p => p.City).Length(0, 100);
                }
        }
