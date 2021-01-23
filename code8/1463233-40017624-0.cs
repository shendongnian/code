          public class RequiredIfAttribute : RequiredAttribute
            {
                private string PropertyName { get; set; }
                private object DesiredValue { get; set; }
                public RequiredIfAttribute(string propertyName, object desiredvalue)
                {
                    PropertyName = propertyName;
                    DesiredValue = desiredvalue;
                }
                protected override ValidationResult IsValid(object value, ValidationContext context)
                {
                    object instance = context.ObjectInstance;
                    Type type = instance.GetType();
                    Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
                    if (proprtyvalue.ToString() == DesiredValue.ToString())
                    {
                        ValidationResult result = base.IsValid(value, context);
                        return result;
                    }
                    return ValidationResult.Success;
                }
            }
