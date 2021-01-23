    private Messenger messenger = new Messenger();
    
    private void Initialize() { //I would expect this to be in the constructor
        messenger.MessageHandler = MessageHandler;
    }
    
    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        messenger.SendAsync(data);
    }
    
    private void MessageHandler(object message)
    {
        List<object> data = (List<object>)message;
        Port.WriteLine(STARTCHARACTER + XMLSET + XML_TAG_START + data[0] + XML_TAG_STOP + data[1] + ENDCHARACTER);
        string received = Port.ReadLine();
    }
