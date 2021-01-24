    public static IEnumerable<Segment> FindLongestPath(Segment segment)
    {
    	var queue = new Queue<Segment>(); //or a Stack<Segment> with Push and Pop
    	queue.Enqueue(segment);
    	
    	while(queue.Any())
    	{
    		var currentSegment=queue.Dequeue();
    		foreach(var n in currentSegment.Next)
    		{
    			queue.Enqueue(segment);
    		}
    		//process currentSegment
    	}
    }
