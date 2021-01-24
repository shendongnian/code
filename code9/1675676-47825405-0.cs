    class ValidationResultNode
    {
        public string PropertyName {get; private set;}
        public string ErrorMessage {get; private set;}
        public List<ValidationResultNode> Children {get; private set;}
        public ValidationResult(string propName, string errMsg)
        {
            PropertyName = propName;
            ErrorMessage = errMsg;
            Children = new List<ValidationResultNode>();
        }
        
        // method to add a child error
        public ValidationResultNode AddChildError(string propName, string errMsg)
        {
            var result = new ValidationResultNode(propName, errMsg);
            Children.Add(result);
            return result;
        }
