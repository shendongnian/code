     public class ValidGuidAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {           
                ErrorMessage = "please select a device";
                var input = Convert.ToString(value);
                if (string.IsNullOrEmpty(input))
                {
    
                    return false;
                }
    
                Guid guid;
                if (!Guid.TryParse(input, out guid))
                {
                    return false;
                }
                if (guid == Guid.Empty)
                {
                    return false;
                }
                return true;
            }
    
            public class ValidGuid : DataAnnotationsModelValidator<ValidGuidAttribute>
            {
                public ValidGuid(ModelMetadata metadata, ControllerContext context, ValidGuidAttribute attribute)
                    : base(metadata, context, attribute)
                {
                    if (!attribute.IsValid(context.HttpContext.Request.Form[metadata.PropertyName]))
                    {
                        if (context.Controller.ViewData.ModelState.Count != 0)
                        {
                            var propertyName = metadata.PropertyName;
                            context.Controller.ViewData.ModelState[propertyName].Errors.Clear();
                            context.Controller.ViewData.ModelState[propertyName].Errors.Add(attribute.ErrorMessage);
                        }
                       
                    }
                }
            }
        }
