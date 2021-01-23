    class Page1
    {
      private async void OnSomeEvent()
      {
         await Navigation.PushAsync(new Page2("xyz"));
      }
    }
    
    class Page2
    {
      public Page2(string myValue)
      {
      }
    }
