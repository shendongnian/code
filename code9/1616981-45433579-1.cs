    public partial class DemoClass 
    {
      [NotMapped]
      public string MyDateString {
        get
        { 
          if(this.MyDate.HasValue)
          {
            return this.MyDate.Value.ToString("{ 0:dd.MM.yyyy}");
          }
          else
          {
            return "";
          }
        }
    }
