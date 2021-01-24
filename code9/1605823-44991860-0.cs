    List<QueryOption> options = new List<QueryOption>
    {
         new QueryOption("$search", "lunch")
    };
    var messages = await client.Me.Messages.Request(options).GetAsync();
