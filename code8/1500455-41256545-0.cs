     [SetUp]
      public void OnTestInitialize()
      {
          UriParser.Register(new GenericUriParser(
          GenericUriParserOptions.GenericAuthority), "pack", -1);
      }
