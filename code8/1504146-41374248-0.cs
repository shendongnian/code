    public class MainViewModel : ObservableObject
    {
     
      //Initialize someDateTime with a default value
      private DateTime someDateTime = DateTime.Parse("07/21/1969 2:56AM");
     
      public DateTime SomeDateTime
      {
        get { return someDateTime; }
        set { Set(ref someDateTime,value); }
      }
        
    }}
