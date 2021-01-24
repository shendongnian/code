    private const SomeMethodTokenName = "SomeMethodToken";
    [HttpPost]
    public async SomeMethod()
    {
      if (cacheLock.TryEnterWriteLock(timeout));
      {
        try
        {
          var token = Request.Form.Get["__RequestVerificationToken"].ToString();
          var session = Session[SomeMethodTokenName ];
          if (token == session) return;
          session[SomeMethodTokenName] = token
          // DoWork that should be very fast
        }
        finally
        {
          cacheLock.ExitWriteLock();
        }
      }
    }
