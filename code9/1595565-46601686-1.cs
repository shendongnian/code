    public bool ValidateGoogleToken(string token)
    {
      try
      {
        if(GoogleJsonWebSignature.ValidateAsync(token).Wait(1000))
          return true; //success
        //timeout exceeded
      }
      catch (Exception e)
      {
        //tampered token    
      }
      return false;
    }
