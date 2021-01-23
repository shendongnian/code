    var count = new [] { 
    	new { SegmentName = "A", FieldValue = "", Count = 2 }, 
    	new { SegmentName = "A", FieldValue = "ABC", Count = 1 },
    	new { SegmentName = "B", FieldValue = "", Count = 2 },
    	new { SegmentName = "B", FieldValue = "ABC", Count = 1 },
    	new { SegmentName = "C", FieldValue = "", Count = 3 },
    };
    
    var result = count
    	.GroupBy(x => x.SegmentName)
    	.Where(y => y.Count() == 1)
    	.Select(z => z.First()) // Need to implicitly get the first item here
    	.ToList();
    
    foreach(var item in result)
    {
    	Console.WriteLine("SegmentName={0} FieldValue={1} Count={2}", item.SegmentName, item.FieldValue, item.Count);
    }
