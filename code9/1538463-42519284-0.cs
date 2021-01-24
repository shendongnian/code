    var RoomType = new ArrayList();
    var bedrooms = 0;
    
    RoomType.Add("workflow");
    RoomType.Add("Bedroom");
    RoomType.Add("Bedroom");
    
    foreach (string row in RoomType) // RoomType is the ArrayList
    {
    
    	if (row.Equals("Bedroom"))
    	{
    		bedrooms++;
    	}
    }
    
    Console.WriteLine(bedrooms);
