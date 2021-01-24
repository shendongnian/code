    public class ValidUrlAttribute : Attribute, IModelValidator
    {
        public string ErrorMessage { get; set; }
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var url = context.Model as string;
            if (url != null && Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
            return new List<ModelValidationResult>
            {
                new ModelValidationResult(context.ModalMetadata.PropertyName, ErrorMessage)
            };
        }
    }
