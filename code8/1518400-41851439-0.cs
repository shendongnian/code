    public void Login(String username, String password)
    {
        if(DoesOldHashMatch(username, password)){
            var newHash = NewHasher.GetPasswordHash(password);
            UpdateUserPasswordHash(username, newHash);
            SetLoginCookie(username);
            return;
        }
        if(NewHashMatch(username, password))
        {
            SetLoginCookie(username);
        }
    }
