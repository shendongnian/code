    auth.SignInWithEmailAndPasswordAsync("test@gmail.com", "password").ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
    			if(CheckError(task.Exception, (int)Firebase.Auth.AuthError.EmailAlreadyInUse))
    			{
    				// do whatever you want in this case
    				Debug.LogError("Email already in use");
    			}
    			Debug.LogError("UpdateEmailAsync encountered an error: " + task.Exception);
    		}
    	}
