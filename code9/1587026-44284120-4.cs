    public class DemoData
    {
         public string CompanyName { get; set; }
         // DateTime? - DateCompleted is Nullable<DateTime>   
         public DateTime? DateCompleted { get; set; }
         public int TotalRecords { get; set; }
    }
    ...
    DemoData demoValue = new DemoData {
      CompanyName = dataRow["CompanyName"].ToString(),
      DateCompleted = dataRow.IsDbNull("DateCompleted") 
        ? null // <- now we can assign null to Nullable<T>   
        : (DateTime?) dataRow["DateCompleted"],
      TotalRecords = (int)dataRow["TotalRecords"]
    };
