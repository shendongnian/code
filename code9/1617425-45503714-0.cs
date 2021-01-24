    public class MyViewModel
    {
      public NotifyTask<string> LabelContent { get; }
      ViewModel()
      {
        LabelContent = NotifyTask.Create(
            async () => (await Sentiment("en", "text")).ToString(),
            "Loading...");
      }
    }
