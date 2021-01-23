    public class ExceptionMSMQ
        {
            private static readonly string description = "Example description";
            private static readonly string path = @".\Private$\myqueue";
            private static MessageQueue exceptionQueue;
            public static MessageQueue ExceptionQueue
            {
                get
                {
                    if (exceptionQueue == null)
                    {
                        try
                        {
                            if (MessageQueue.Exists(path))
                            {
                                exceptionQueue = new MessageQueue(path);
                                exceptionQueue.Label = description;
                            }
                            else
                            {
                                MessageQueue.Create(path);
                                exceptionQueue = new MessageQueue(path);
                                exceptionQueue.Label = description;
                            }
                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {
                            exceptionQueue.Dispose();
                        }
                    }
                    return exceptionQueue;
                }
            }
    
            public static void PushMessage(string message)
            {
                ExceptionQueue.Send(message);
            }
    
            private static List<string> RetrieveMessages()
            {
                List<string> messages = new List<string>();
                using (ExceptionQueue)
                {
                    System.Messaging.Message[] queueMessages = ExceptionQueue.GetAllMessages();
                    foreach (System.Messaging.Message message in queueMessages)
                    {
                        message.Formatter = new XmlMessageFormatter(
                        new String[] { "System.String, mscorlib" });
                        string msg = message.Body.ToString();
                        messages.Add(msg);
                    }
                }
                return messages;
            }
    
            public static void Main(string[] args)
            {
                ExceptionMSMQ.PushMessage("my exception string");
    
            }
        }
