    public class ValidDecimalValidator : DataAnnotationsModelValidator<ValidDecimal>
    {
        public ValidDecimalValidator(ModelMetadata metadata, ControllerContext context, ValidDecimal attribute)
            : base(metadata, context, attribute)
        {
            if (!attribute.IsValid(context.HttpContext.Request.Form[metadata.PropertyName]))
            {
                var propertyName = metadata.PropertyName;
                context.Controller.ViewData.ModelState[propertyName].Errors.Clear();
                context.Controller.ViewData.ModelState[propertyName].Errors.Add(attribute.ErrorMessage);
            }
        }
    }
