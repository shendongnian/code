    var tasks = this.services.Select(s => s.QueryAsync(messageHandled, CancellationToken.None)).ToArray();
    var winner = this.BestResultFrom(await Task.WhenAll(tasks));
    
    IntentActivityHandler handler = null;
    if (winner == null || !this.handlerByIntent.TryGetValue(winner.BestIntent.Intent, out handler))
    {
        handler = this.handlerByIntent[string.Empty];
    }
    
    if (handler != null)
    {
        await handler(context, item, winner?.Result);
    }
