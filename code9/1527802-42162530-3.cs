    if (!stop)
    {
         stop = true;
         path.Add(end);
         path.Add(start);
         path.Reverse();
         arraydeNodes = path.ToArray();
    }
    
    return arraydeNodes;      
