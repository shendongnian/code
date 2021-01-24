    string WebGreeting()
    {
      try
      {
         return _greetingService.HelloWorld();
      }
      catch(Exception ex)
      {
          _logger.Error("Some good error message");
          //throw;  // when this is missing, you get the compiler error "not all paths ..."
      }
    }
