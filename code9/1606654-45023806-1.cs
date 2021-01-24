    public interface IProtein
    {
    	int Count { get; set; }
    
    	[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    	DateTime Date { get; set; }
    }
