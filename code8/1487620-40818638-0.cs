    public class RandomlyPickedWord
    	{
    		public IList<string> SourceWords{ get; set; }
    
    		protected IList<string> Words{ get; set; }
    
    		public RandomlyPickedWord(IList<string> sourceWords)
    		{
    			SourceWords = sourceWords;
    		}
    
    		protected IList<string> RepopulateWords(IList<string> sources)
    		{
    			Random randomizer = new Random ();
    			IList<string> returnedValue;
    			returnedValue = new List<string> ();
    
    			for (int i = 0; i != sources.Count; i++)
    			{
    				returnedValue.Add (sources [randomizer.Next (sources.Count - 1)]);
    			}
    
    			return returnedValue;
    		}
    
    		public string GetPickedWord()
    		{
    			Random randomizer = new Random ();
    			int curIndex;
    			string returnedValue;
    
    			if ((Words == null) || (Words.Any () == false))
    			{
    				Words = RepopulateWords (SourceWords);
    			}
    				
    			curIndex = randomizer.Next (Words.Count);
    			returnedValue = Words [curIndex];
    			Words.RemoveAt (curIndex);
    
    			return returnedValue;
    		}
    	}
