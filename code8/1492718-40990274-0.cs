    //get credentials by logging in with a user interface
    var credentialsProvider = new UICredentialsProvider();
     
    var teamProjectCollection = new TfsTeamProjectCollection(collection, credentialsProvider);
    teamProjectCollection.Authenticate();
