    public sealed class MyClass
    {
      private MyData asyncData;
      public MyClass()
      {
        InitializeAsync();
      }
    
      // BAD CODE!!
      private async void InitializeAsync()
      {
        asyncData = await GetDataAsync();
      }
    }
