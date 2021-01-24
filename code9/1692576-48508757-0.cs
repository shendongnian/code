    public class MeasurementPoint : ModelBase
    {
      //...
      public void RefreshAllProperties()
      {
        foreach(var prop in this.GetType().GetProperties())
          this.OnPropertyChanged(prop.Name);
      }
    }
