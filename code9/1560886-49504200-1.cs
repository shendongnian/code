        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null) {
          string name = user.DisplayName;
          string email = user.Email;
          System.Uri photo_url = user.PhotoUrl;
          // The user's Id, unique to the Firebase project.
          // Do NOT use this value to authenticate with your backend     server, if you
          // have one; use User.TokenAsync() instead.
          string uid = user.UserId;
        }
