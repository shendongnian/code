    private void button1_Click(object sender, EventArgs e)
    {
        // Or whatever name you end up calling it if you created the queue manually
        const string myQueue = ".\\myQueue";
        // It's possible that this won't work on certain computers
        // If not, you'll have to create the queue manually
        // You'll also need to turn the Message Queueing feature on in Windows
        // See the following for instructions (for Windows 7 and 8): https://technet.microsoft.com/en-us/library/cc730960(v=ws.11).aspx
        if (!MessageQueue.Exists(myQueue))
        {
            MessageQueue.Create(myQueue);
        }
        using (MessageQueue queue = new MessageQueue(myQueue))
        {
            queue.Formatter = new XmlMessageFormatter(new[] { typeof(string) });
            queue.Send("Test");
        }
    }
