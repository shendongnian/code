    public class ContentNegotiationConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (action.ActionName.ToLower().EndsWith("view"))
            {
                //Make it match to the action of the same name without 'view', exa: IndexView => Index
                action.ActionName = action.ActionName.Substring(0, action.ActionName.Length - 4);
                foreach (var selector in action.Selectors)                
                    //Add a constraint which will choose this action over the API action when the content type is apprpriate
                    selector.ActionConstraints.Add(new TextHtmlContentTypeActionConstraint());                
            }
        }
    }
    public class TextHtmlContentTypeActionConstraint : ContentTypeActionConstraint
    {
        public TextHtmlContentTypeActionConstraint() : base("text/html") { }
    }
    public class ContentTypeActionConstraint : IActionConstraint, IActionConstraintMetadata
    {
        string _contentType;
        public ContentTypeActionConstraint(string contentType)
        {
                _contentType = contentType;
        }
        public int Order => -10;
        public bool Accept(ActionConstraintContext context) => 
                context.RouteContext.HttpContext.Request.Headers["Accept"].ToString().Contains(_contentType);        
    }
