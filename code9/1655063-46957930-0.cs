    public class UniqueEmail : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return $"This email ({name}) is already registered";
        }
        protected override ValidationResult IsValid(object objValue,ValidationContext context)
        {
            var email = objValue as string;
            int userId= Int32.MinValue;
            var idProperty = context.ObjectType.GetProperty("Id");
            if (idProperty != null)
            {
                var idValue = idProperty.GetValue(context.ObjectInstance, null);
                if (idValue != null)
                {
                    userId = (int) idValue;
                }
            }
            var userRepository = new UserRepository();
            var e = userRepository.GetUser(email);
            
            if (e!=null && userId!=e.Id)
            {
                return new ValidationResult(FormatErrorMessage(email));
            }
            return ValidationResult.Success;
        }
    }
