    // This part of the code of creating the TestObject isn't what I'm using in development, 
    // this is just for showing you that I'm using an object.
    TestObject item = new TestObject();
    item.Text = "Hello World!";
    item.Number = 5;
    MessageQueue messageQueue;
    Message message;
    XmlMessageFormatter format = new XmlMessageFormatter(
        new Type[] {
            typeof(string),
            typeof(TestObject)}
    );
    messageQueue = new MessageQueue(@".\Private$\myqueue");
    message = new Message(item);
    message.Formatter = format;
    messageQueue.Send(message);
    // ...
    message = messageQueue.Receive();
    Type messageType = message.Body.GetType();
    if (messageType == typeof(string))
    {
        string newString = (string)message.Body;
    }
    else if (messageType == typeof(TestObject))
    {
        TestObject receiveItem = (TestObject)message.Body;
    }
