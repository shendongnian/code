    var firstList = new List<bool> { false, false, true };
	var secondList = new List<bool> { true };
		
	for(int i =0; i < firstList.Count; i++)
	{
		var currentItem = firstList[i];
        // If the item in the first list is true, then we need to insert it into the second list
		if(currentItem)
		{
            // If the second list is shorter than the actual index,
            // we insert missing elements so we can be able to insert the matching true in first list 
            // at the exact same position in second list.
			while(secondList.Count < i)
			{
                // Inserting false as you ask
				secondList.Add(false);
			}
			
            // Now the second list has at at least enough elements, 
            // we can insert true at the exact same location. 
            // Note that this will shift all other elements after that index
			secondList.Insert(i, currentItem);
		}
	}
