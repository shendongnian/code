        public class MessageDisplayer
        {
            public MessageDisplayer() { }
            private MessageBuilder _builder;
            public MessageBuilder Builder { 
                get(return _builder || _builder = new MessageBuilder(););
            }
            public void DisplayErrorMessage(string message)
            {
                Console.Write(Builder.BuildMessage("Error message"));
            }
            public void DisplaySuccessMessage(string message)
            {
                Console.Write(Builder.BuildMessage("Success message"));
            }
        }
