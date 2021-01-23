    private static IPrincipal CreatePrincipal()
    {
      var identity = new GenericIdentity("test.user", "test");
      var roles = new string[] { "admin" };
      return new GenericPrincipal(identity);
    }
