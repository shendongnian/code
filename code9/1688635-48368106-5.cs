    public class MessageBuilder
    {
        private static readonly MessageBuilder instance = new MessageBuilder();
        private MessageBuilder() { }
        public static MessageBuilder Instance
        {
            get 
            {
                return instance; 
            }
        }
        public string BuildMessage(string message)
        {
            return message;
        }
    }
    public class MessageDisplayer
    {
        public MessageDisplayer() { }
        public void DisplayErrorMessage(string message)
        {
            MessageBuilder builder = MessageBuilder.Instance;
            Console.Write(builder.BuildMessage("Error message"));
        }
        public void DisplaySuccessMessage(string message)
        {
            MessageBuilder builder = MessageBuilder.Instance;
            Console.Write(builder.BuildMessage("Success message"));
        }
    }
