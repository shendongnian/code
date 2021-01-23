      await DoSomeReadingAsync();
      public Task DoSomeReadingAsync()
      {
          using(var connection = new Connection())
          { 
               return SomeReadOperationAsync(connection);
          }
      } 
