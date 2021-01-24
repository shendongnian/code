    AmazonEnvelopeMessage message = new AmazonEnvelopeMessage();
    foreach (...)
    {
        list.Add(message); // you keep passing reference to the same object.
    }
