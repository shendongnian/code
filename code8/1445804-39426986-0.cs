        var client = new MongoClient("mongodb://servername:27017");
        var database = client.GetDatabase("WatchTblDB");
        var collectionWatchtbl = database.GetCollection<WatchTbl>("Watchtbl");
        var collectionUser = database.GetCollection<UserCls>("Users");
        var collectionSymbole = database.GetCollection<SymboleCls>("Users");
        var list = collectionWatchtbl.AsQueryable().Select(x => new WatchTblCls() {
            id = x.id,
            userId = x.userId,
            .....
        });
