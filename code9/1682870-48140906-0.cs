    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class ValidateMetaFieldsAttribute : Attribute, IArgumentValidator
    {
        public void Validate(object argument)
        {
            //todo: put your validation logic here
        }
    }
