    public class SaveProxyCommand {
        public int Id { get; set; }
    }
    public class ValidationFailure {
        public string PropertyName { get; }
        public string Message { get; }
        public ValidationFailure(string propertyName, string message){
            Message = message;
            PropertyName = propertyName;
        }
    }
