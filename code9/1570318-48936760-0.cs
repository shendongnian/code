    public EventStore()
    {
        _connection = EventStoreConnection.Create(
            new IPEndPoint(
                IPAddress.Parse("127.0.0.1"),
                1113
            )
        );
        _connection.ConnectAsync().Wait();
    }
    public void Publish(DomainEvent domainEvent)
    {
        _connection.AppendToStreamAsync(
            "stream-name",
            ExpectedVersion.Any,
            new EventData(
                Guid.NewGuid(),
                domainEvent.GetType().FullName,
                false, 
                Encoding.UTF8.GetBytes(domainEvent.ToString()),
                new byte[] {}
            )
        ).Wait();
    }
