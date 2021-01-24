        public class MessageBuilder {
        public MessageBuilder() { }
            public string BuildMessage(string message) {
                return message;
            }
        }
        public class MessageDisplayer
        {
            public MessageDisplayer() { }
            public void DisplayErrorMessage(string message)
            {
                MessageBuilder builder = new MessageBuilder();
                Console.Write(builder.BuildMessage("Error message"));
            }
            public void DisplaySuccessMessage(string message)
            {
                MessageBuilder builder = new MessageBuilder();
                Console.Write(builder.BuildMessage("Success message"));
            }
        }
