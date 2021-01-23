    Func<OracleMessage, bool> isMessageCommitable; //...application handling logic here
    var appHandledMessages = oracleSourceMessages
        .Select(m => Tuple.Create(m, isMessageCommitable(m)))
        .Publish()
        .RefCount();
    
    appHandledMessages
        .Where(t => t.Item2)
        .Subscribe(t => Commit(t.Item1));
    appHandledMessages
        .Where(t => !t.Item2)
        .Subscribe(t => Rollback(t.Item1));
