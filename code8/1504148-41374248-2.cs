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
    public class DateTimeToTimeSpanConverter : IValueConverter
    {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        try
        {
            DateTime dt = (DateTime)value;            
            TimeSpan? ts = DateTimeConverter.DateTimeToTimeSpan(dt);
            return ts.GetValueOrDefault(TimeSpan.MinValue);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return TimeSpan.MinValue;
        }
    }
    }
