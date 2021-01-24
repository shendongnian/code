    public class DateWithAttributes
    {
      public string Date {get;set;}
      public Attribute Attribute1 {get;set;}
      public Attribute Attribute2 {get;set;}
    ...
    }
    
    List<DateWithAttributes> DateWithAttributesList = new List<DateWithAttributes>()
    {
      DateWithAttribute1,
      DateWithAttribute2
    }
    List<DateWithAttributes> sortedDateList = DateWithAttributesList.OrderBy(x => x.date).ToList();
