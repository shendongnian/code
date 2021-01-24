    ///**
		//*  Set up the session object with an app consumer key and secret. This is the standard setup
		//*  method. App keys are available from dev.evernote.com. You must call this method BEFORE the
		//*  sharedSession is accessed.
		//*
		//*   key    Consumer key for your app
		//*   secret Consumer secret for yor app
		//*   host   (optional) If you're using a non-production host, like the developer sandbox, specify it here.
		//*/
		public static void SetSharedSessionConsumerKey(string sessionConsumerKey, string sessionConsumerSecret, string sessionHost = null)
