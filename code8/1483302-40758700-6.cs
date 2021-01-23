    public class MessageProcessor
        {
            public static void StartProcessing()
            {
                List<string> messages = ExceptionMSMQ.RetrieveMessages();
                foreach(string message in messages)
                {
                    //write message in database
                }
            }
        }
