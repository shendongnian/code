    void Main()
    {
    	var a = new List<int> { 10, 11, 12, 14, 45 };
    	var b = new List<int> { 8, 15, 10, 12, 55 };
    	
    	var result = CompareScores(a, b);
    
    	//Expected result is : 
    	// Alice: 3
    	// Bob: 2
    
    	Console.WriteLine($"Alice score: {result.ElementAt(0)} Bob score: {result.ElementAt(1)}");
    }
    
    public List<int> CompareScores(List<int> alice, List<int> bob)
    {
    	var ScoreAlice = 0;
    	var ScoreBob = 0;
    	var i = 0;
    	alice.ForEach(scoreAlice => {
    		if(scoreAlice > bob.ElementAt(i))
    		{
    			ScoreAlice ++;
    		}
    		if(scoreAlice < bob.ElementAt(i))
    		{
    			ScoreBob ++;
    		}
    		i++;
    	});
    	return new List<int> {ScoreAlice, ScoreBob };
    }
