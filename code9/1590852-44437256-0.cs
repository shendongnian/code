    var pull = _db.CreatePullReplication(syncGatewayUri);
    var push = _db.CreatePushReplication(syncGatewayUri);
    
     _db.SetFilter("byUser", (revision, filterParams) =>
    {
      //We get the type property
      var docType = (string)revision.GetProperty("type");
      //We make sure it's a user
      return !String.IsNullOrEmpty(docType) && docType.toLowerCase() == "user";
    });
    
    pull.Filter ="byUser";
