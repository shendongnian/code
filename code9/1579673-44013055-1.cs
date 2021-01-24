    public class ValidationMessage
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public static ValidationMessage operator &(ValidationMessage message1, ValidationMessage message2)
        {
            return message1.Success ? message2 : message1;
        }
        public static ValidationMessage operator |(ValidationMessage message1, ValidationMessage message2)
        {
            return message1.Success ? message1 : message2;
        }
        public static bool operator true(ValidationMessage message)
        {
            return message.Success;
        }
        public static bool operator false(ValidationMessage message)
        {
            return !message.Success;
        }
    }
