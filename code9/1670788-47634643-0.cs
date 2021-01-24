    public async Task<bool> DoSomethingAsync()
    {
      statement2;
      await statement3; // << Diverges here
      statement4;
      return true;
    }
    
    // all code below this line is completely irrelevant 
    // to whenever or where the code above diverges
    public async Task MyMethod()
    {
      statement1;
      await DoSomethingAsync().ConfigureAwait( false );
      statement5;
    }
