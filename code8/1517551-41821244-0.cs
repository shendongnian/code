    public class CapitalizeFirstLetterModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(
            ControllerContext controllerContext, 
            ModelBindingContext bindingContext, 
            System.ComponentModel.PropertyDescriptor propertyDescriptor,
            object value)
        {
            if (propertyDescriptor.Attributes.Any(att => typeof(att) == typeof(CapitalizeFirstLetterAttribute))
            {
                var stringValue = (string)value;
                if (!string.IsNullOrWhiteSpace(stringValue))
                {
                    value = stringValue.First().ToString().ToUpper() + stringValue.Substring(1);
                }
                else
                {
                    value = null;
                }
            }
            base.SetProperty(controllerContext, bindingContext, 
                          propertyDescriptor, value);
        }
    }
