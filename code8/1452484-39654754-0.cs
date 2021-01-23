    public class MyPage : ContentPage
    {
      public ContentPage()
      {
        BindingContext = this;
      }
    
      public string WordCount { get { return wordCount; }}
    }
