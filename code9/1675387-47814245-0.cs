    // INotifyPropertyChanged should be handled by `Fody.PropertyChanged`
    public class MyViewModel : INotifyPropertyChanged
    {
      public IList<string> MyData { get; set; }
      AlsoNotifyFor(nameof(MyPickerShouldBeVisible))
      public bool ShouldShowPicker => MyData.Any();
    }
