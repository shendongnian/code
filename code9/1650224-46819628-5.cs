    List<Tuple<Rectangle, Bool>> difList = new List<Tuple<Rectangle, Bool>();
    
    // HERE: fill our list by calling LocateDifferences
    LocateDifferences();
    
    var allGood = difList.Where(t => t.Item2 == true).ToList();
    var checkThese = difList.Where(t => t.Item2 == false).ToArray();
        
    for (int i = 0; i < checkThese.Length - 1; i++)
    {
        // check that its not an empty Rectangle
        if (checkThese[i].IsEmpty == false) 
        {
            for (int j = i; j < checkThese.Length; j++)
            {
                // check that its not an empty Rectangle
                if (checkThese[j].IsEmpty == false) 
                {
                    if (ShouldJoinRects(checkThese[i], checkThese[j])
                    {
                        checkThese[i] = JoinRects(checkThese[i], checkThese[j]);
                        checkThese[j] = new Rectangle(0,0,0,0);
                        j = i // restart the inner loop in case we are dealing with a rect that crosses 3 scan areas
                    }
                }
            }
            allGood.Add(checkThese[i]);
        }
    }
    //Now 'allGood' contains all the rects joined where needed.
