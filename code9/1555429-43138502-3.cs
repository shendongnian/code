    Message message = new Message("/index.html", "GET", IndexDownloaded);
    CommunicationManager.Instance.EnqueueMessage(message);
    // ...
    public void IndexDownloaded(MessageResult result)
    {
        // result available here
    }
