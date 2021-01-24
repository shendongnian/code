    var cluster = Cluster.Get(system);
    var region = ClusterSharding.Get(system).ShardRegion(typeName);
    var members = cluster.State.Members;
    var regions = members
        .Select(m => region.Path.ToStringWithAddress(m.Address))
        .Select(system.ActorSelection);
    
    // at this point regions variable is a collection of ActorSelections poiting
    // to regions on all known nodes. You can use Ask pattern on them directly
