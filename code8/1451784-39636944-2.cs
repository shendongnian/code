    public class ControllerActionDescriptor : ActionDescriptor
    {
        public string ControllerName { get; set; }
        public virtual string ActionName { get; set; }
        public MethodInfo MethodInfo { get; set; }
        public TypeInfo ControllerTypeInfo { get; set; }
        
        ...
    }
