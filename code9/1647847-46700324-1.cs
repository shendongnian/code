    void DoUpdates(int[,] allCombinations)
    {
        .
        .
        foreach (var myObject in myDependency.Objects)
        {
            foreach (var otherObject in myMatchingObjects)
            {
                .
                .
                var existingValue = allCombinations[myObject.Index, otherObject.Index];
                .
                . 
