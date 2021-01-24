    public class CustomPlaceAttribute : ValidationAttribute
    {
        private readonly string[] _others
        public CustomPlaceAttribute(params string[] others)
        {
            _others= others;
        }
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
               // TODO: validate the length of _others to ensure you have all required inputs
               var property = validationContext.ObjectType.GetProperty(_others[0]);
               if (property == null)
               {
                   return new ValidationResult(
                    string.Format("Unknown property: {0}", _others[0])
                   );
               }
               // This is to get one of the other value information. 
               var otherValue = property.GetValue(validationContext.ObjectInstance, null);
               
               // TODO: get the other value again for the date -- and then apply your business logic of determining the capacity          
        }
    }
