    public async Task<IEnumerable<InMatchStat>> GetInMatchStats()
    {
    	const string firebaseUrl = "https://xxxxxxxxxxxxxx.firebaseio.com/";
    	const string firebaseUsername = "xxxxxxxxxxxxxxxxxxxxx@xxxxx.xxx";
    	const string firebasePassword = "xxxxxxxx";
    	const string firebaseApiKey = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
    		
    	bool tryAgain = false;
    	FirebaseAuthLink token = null;
    
    	try
    	{
    		var auth = new FirebaseAuthProvider(new FirebaseConfig(firebaseApiKey));
    
    		do
    		{
    			try
    			{
    				token = await auth.SignInWithEmailAndPasswordAsync(firebaseUsername, firebasePassword);
    			}
    			catch (FirebaseAuthException faException)
    			{
    				// checking for a false tryAgain because we don't want to try and create the account twice
    				if (faException.Reason.ToString() == "UnknownEmailAddress" && !tryAgain)
    				{
    					// create, then signin
    					token = await auth.CreateUserWithEmailAndPasswordAsync(firebaseUsername, firebasePassword, "Greg", false);
    					tryAgain = true;
    				}
    				
    				throw;
    			}
    			catch (Exception)
    			{
    				throw;
    			}
    		}
    		while (tryAgain);
    
    		var firebase = new FirebaseClient(firebaseUrl, new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(token.FirebaseToken) });
    		var stats = await firebase.Child("my/collection/path").OnceAsync<InMatchStat>();
    
    		if (stats == null || !stats.Any())
    		{
    			return null;
    		}
    
    		//return await Convert(stats.AsEnumerable());
    	}
    	catch (Exception exception)
    	{
    		var message = exception.ToString();
    	}
    
    	return null;
    }
