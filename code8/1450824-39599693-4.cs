    public async Task<String> Get(int id)
    {
	    log.Info("[GET] Search for Lync User: " + id);
    	Lync lync = new Lync();
	    ////lync.signIn();
	    Boolean isSignedIn = lync.isUserSignedIn();
    	if (isSignedIn)
	    {
		    log.Info("User is Signed In");
	    	Console.Write("Enter search key : ");
    		var lyncContacts = await SearchAsync("medina");
 	    	log.Info("Results found: " + lyncContacts.Count);
    		return lyncContacts.ToString();
    	}
    	else
    	{
	    	log.Info("User is not Signed In!");
		    // TODO: Return status 500
    		return "testUser";
	    }
    	//Console.ReadLine();
	    //return "testUser";
    }
