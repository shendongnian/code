    var queries = PersistenceQuery.Get(actorSystem)
        .ReadJournalFor<SqlReadJournal>("path-to-sharding-journal");
    var shardPrefix = "/sharding/" + typeName + "Shard/"
    Source<string, NotUsed> entitySource = queries
        .AllPersistenceIds() 
        .Where(pid => pid.StartsWith(shardPrefix)) // get all shard IDs ever known
        .ConcatMany(shardId => queries.EventsByPersistenceId(shardId)) // get stream of persisted events for each shard
        .Collect(env => env.Event as Shard.EntityStarted) // filter out EntityStarted events
        .Select(e => e.EntityId); // extract entity ID
    using (var mat = system.Materializer())
    {
        // materialize source into a list
        var entityIds = await entitySource
            .RunAggregate(ImmutableList<string>.Emtpy, (acc, id) => acc.Add(id), mat);
    }
