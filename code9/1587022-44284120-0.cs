    public class DemoData
    {
         public string CompanyName { get; set; }
         // DateTime? - DateCompleted is Nullable<DateTime>   
         public DateTime? DateCompleted { get; set; }
         public int TotalRecords { get; set; }
    }
    ...
    if (dataRow["DateCompleted"] == DBNull.Value)
    {
        dataRow["DateCompleted"] = null;
    }
