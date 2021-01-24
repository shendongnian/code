    public class FormPostFilterAttribute : ActionMethodSelectorAttribute
    {
      private readonly string _elementId;
      private readonly string _requiredValue;
    
      public FormPostFilterAttribute(string elementId, string requiredValue)
      {
        _elementId = elementId;
        _requiredValue = requiredValue;
      }
    
      public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
      {
        if (string.IsNullOrEmpty(controllerContext.HttpContext.Request.Form[_elementId]))
        {
          return false;
        }
    
        return (controllerContext.HttpContext.Request.Form[_elementId] == _requiredValue);
      }
    }
