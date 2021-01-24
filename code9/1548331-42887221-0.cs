    void Main()
    {
	    messages
	    	.Buffer(TimeSpan.FromMinutes(1), 100) // Buffer until 100 items or 1 minute has elapsed, whatever comes first.
	    	.Subscribe(messages => SendMessages(messages)); 	
    }
    Subject<Message> messages = new Subject<Message>();
    public void GotNewMessage(Message msg)
    {
	    messages.OnNext(msg);
    }
