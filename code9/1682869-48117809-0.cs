    [AttributeUsage(AttributeTargets.Parameter)]
    public class ValidateMetaFieldsAttribute : Attribute
    {
        public ValidateMetaFieldsAttribute([CallerMemberName] string member = null)
        {
            ...
        }
    }
