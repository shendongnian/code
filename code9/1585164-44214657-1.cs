    foreach (...)
    {
        AmazonEnvelopeMessage message = new AmazonEnvelopeMessage();
        list.Add(message); // now you're passing a new one each time
    }
