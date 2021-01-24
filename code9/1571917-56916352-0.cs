    private void SignInWithGoogle(bool linkWithCurrentAnonUser)
       {
          GoogleSignIn.Configuration = new GoogleSignInConfiguration
          {
             RequestIdToken = true,
             // Copy this value from the google-service.json file.
             // oauth_client with type == 3
             WebClientId = "[YOUR API CLIENT ID HERE].apps.googleusercontent.com"
          };
    
          Task<GoogleSignInUser> signIn = GoogleSignIn.DefaultInstance.SignIn();
    
          TaskCompletionSource<FirebaseUser> signInCompleted = new TaskCompletionSource<FirebaseUser>();
          signIn.ContinueWith(task =>
          {
             if (task.IsCanceled)
             {
                signInCompleted.SetCanceled();
             }
             else if (task.IsFaulted)
             {
                signInCompleted.SetException(task.Exception);
             }
             else
             {
                Credential credential = Firebase.Auth.GoogleAuthProvider.GetCredential(((Task<GoogleSignInUser>)task).Result.IdToken, null);
                if (linkWithCurrentAnonUser)
                {
                   mAuth.CurrentUser.LinkWithCredentialAsync(credential).ContinueWith(HandleLoginResult);
                }
                else
                {
                   SignInWithCredential(credential);
                }
             }
          });
       }
