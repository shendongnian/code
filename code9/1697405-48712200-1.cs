    public class RegistrationValidation : IRegistrationValidation
    {
        public List<string> Validate(AccountRegisterModel model)
        {
            List<string> errors = new List<string>();
            ...
            return errors;
        }
    }
    public class RegistrationController : ApiController
    {
        private readonly IRegistrationValidation validator;
        // with a DI container
        public RegistrationController(IRegistrationValidation validator)
        {
            this.validator = validator;
        }
        // without a DI container
        public RegistrationController()
        {
            this.validator = new RegistrationValidation();
        }
        public IHttpActionResult ValidateRegistrationStep3(AccountRegisterModel accountModel)
        {
            var errors = validator.Validate(accountModel);
            if (error.Count() == 0)
                return Content(HttpStatusCode.OK, "Register Model-3 Valid");
            ...
        }
        public IHttpActionResult FinishRegistration(AccountRegisterModel accountModel)
        {
            var errors = validator.Validate(accountModel);
            if (errors.Count() == 0)
            {
                ...
            }
        }
    }
