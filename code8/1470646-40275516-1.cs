    public class LoginRegisterModelValidator : AbstractValidator<LoginRegisterViewModel>
    	{
            public RegistryAddEditModelValidator()
            {
                /* Define the rule set to call them specifically inside contrller action parameter with CustomizeValidator Attribute */
                RuleSet("LoginRuleSet", LoginRuleSet);
                RuleSet("RegisterRuleSet", RegisterRuleSet);            
    		}
    protected void LoginRuleSet()
            {
               RuleFor(x => x.UserName).NotEmpty();
               RuleFor(x => x.Password).NotEmpty();
            }
    	    protected void RegisterRuleSet()
    	    {
               RuleFor(x => x.Email).NotEmpty();
               RuleFor(x => x.FirstName).NotEmpty();
    	    }
    }
