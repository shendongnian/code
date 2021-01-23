    foreach (var charact in Characters)
    {
        if (charact.Team == 1)
        {
            Blue_Team.Add(charact);
        }
    
        if (charact.Team == 2)
        {
            Red_Team.Add(charact);
        }    
    }
