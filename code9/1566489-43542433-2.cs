    public static List<int> RemoveSmallest(List<int> numbers)
    {
    
    	   if (numbers.Count < 1) return numbers;
    	   var newList = new List<int>();
    	   var lowest = numbers[0]; // treat this as the smallest
    
    	   for (var i = 1; i < numbers.Count; i++)
    	   {
    			if (numbers[i] < lowest) // compare it against other elements
    			{
    				lowest = numbers[i]; // update lowest
    			}
    
    		}
    
    		foreach (var num in numbers)
    		{
    			if (num != lowest)  // dont add the lowest
    			{
    				newList.Add(num);
    			}
    		}
    
    		return newList;
    }
