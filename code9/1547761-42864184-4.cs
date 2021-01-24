    string[] winSplits = winsRawData.Split('/');
                
    
    for (int i = 0; i < winSplits.Length; i++)
    {
        var dataArray = winSplits[i].Split(',');
        if (dataArray[0] == room.ToString()) //room is the roomPrize that i want to affect
        {
            // sets the new value.
            dataArray[0] = newWins.ToString();
        }
    
        // finalize by recreating the string and push it back to the original array
        winSplits[i] = String.Join(",", dataArray);
    }
    
    var output = String.Join("/", winSplits); // = "100,2/20,5/50,3"
