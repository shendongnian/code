      await DoSomeReadingAsync();
      public async Task DoSomeReadingAsync()
      {
          using(var connection = new Connection())
          { 
              await SomeReadOperationAsync(connection);
          }
      }
