    void Main()
    {
    	var clientUserViews = new List<Test>();
    	var t1 = new Test()
    	{ 
    		Text = "A", 
    		Value = "A"
    	};
    	var t2 = new Test()
    	{
    		Text = "A",
    		Value = "A"
    	};
    	var t3 = new Test()
    	{
    		Text = "A",
    		Value = "A"
    	};
    
    	clientUserViews.Add(t1);
    	clientUserViews.Add(t2);
    	clientUserViews.Add(t3);
    	List<Test> allClientUserAndCandidateViews = new List<Test>();
    	foreach (var clientUserView in clientUserViews)
    	{
    		Test item =
    			new Test
    			{
    				Value = clientUserView.Value.ToString(),
    				Text = clientUserView.Text
    			};
    		allClientUserAndCandidateViews.Add(item);
    	}
    	
    	allClientUserAndCandidateViews.Dump("allClientUserAndCandidateViews");
    
    	allClientUserAndCandidateViews.GroupBy(x => x.Text, (key, values) => new { key, Count = values.Count() }).Dump();
    	
    }
    
    // Define other methods and classes here
    public class Test
    {
       public string Value { get; set; }
       public string Text { get; set; }	
    }
