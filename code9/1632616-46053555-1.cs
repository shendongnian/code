    public class Webinar
    {
       public DateTime Date { get; set; }
       public string Title { get; set; }
       public string Desc { get; set; }
       public string StartTime { get; set; }
       public string EndTime { get; set; }
       public WebFilters[] Categories { get; set; } //Converted it into a collection
    }
