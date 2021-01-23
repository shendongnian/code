    static void Main(string[] args)
    {
        // Or whatever name you use
        const string myQueue = ".\\myQueue";
        // See my comment on the corresponding line in the Windows Forms application
        if (!MessageQueue.Exists(myQueue))
        {
            MessageQueue.Create(myQueue);
        }
        MessageQueue queue = new MessageQueue(myQueue);
        queue.Formatter = new XmlMessageFormatter(new[] { typeof(string) });
        while (true)
        {
            Message message = queue.Receive();
            string messageText = message.Body.ToString();
            // Close if we received a message to do so
            if (messageText.Trim().ToLower() == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine(messageText);
            }
        }
    }
