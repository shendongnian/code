    private readonly ConcurrentDictionary<int, object> _gameLocks = new ConcurrentDictionary<int, object>();
    // Finish process:
    if (!GameIsFinished(gameId))
    {    
        lock (_gameLocks.GetOrAdd(gameId, new object())
        {
            if (!GameIsFinished(gameId)) {
                FinishGame(gameId);
            }
        }
    }
