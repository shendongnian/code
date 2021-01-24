    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
   
     // Handle initialization of the necessary firebase modules:
        void InitializeFirebase() {
          Debug.Log("Setting up Firebase Auth");
          auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
          auth.StateChanged += AuthStateChanged;
          AuthStateChanged(this, null);
        }
    // Track state changes of the auth object.
        void AuthStateChanged(object sender, System.EventArgs eventArgs) {
            if (auth.CurrentUser != user) {
                bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
                if (!signedIn && user != null) {
                  Debug.Log("Signed out " + user.UserId);
                }
                user = auth.CurrentUser;
                if (signedIn) {
                  Debug.Log("Signed in " + user.UserId);
                }
            }
        }
    
        void OnDestroy() {
          auth.StateChanged -= AuthStateChanged;
          auth = null;
        }
