    private Task<bool> Authenticate(string userName,string password)
    {
        provider = new FirebaseAuthProvider(new FirebaseConfig(firebaseApiKey));
        return provider.SignInWithEmailAndPasswordAsync(userName, password)
            .Success(r => r.User != null)
            .Error(ex => false);
    }
