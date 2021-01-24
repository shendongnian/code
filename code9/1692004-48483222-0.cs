    var someResult = someList.Select(x => new
                                {
                                    FriendIdA = x.FriendTo.FriendID,
                                    FriendIdB = x.FriendFor.FriendID,
                                    SharedCountNumber = x.FriendTo.FriendID * x.FriendFor.FriendID    
                                }) // Projection
                              .OrderByDescending(x => x.SharedCountNumber) // order the list
                              .FirstOrDefault(); // get the first
    
    if (someResult != null)
    {
        Debug.WriteLine($"A : {someResult.FriendIdA}, B : {someResult.FriendIdB}, Product : {someResult.SharedCountNumber}");
    }
