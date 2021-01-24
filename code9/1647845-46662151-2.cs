    foreach (var myObj in myDependency.Objects)
    {
        foreach (var otherObj in myMatchingObjects)
        {
            if (myObj.Id != otherObj.Id)
            {
                var ids = new IdById(myObj.Id, otherObj.Id);
                var existingValue = allCombinations[ids];
                var minValue =
                    allCombinations[new IdById(myObj.Id, myDependency.FromObjectId)] +
                    allCombinations[new IdById(myDependency.ToObjectId, otherObj.Id)] +
                    myDependency.MinValue;
                var maxValue =
                    allCombinations[new IdById(myObj.Id, myDependency.ToObjectId)] +
                    allCombinations[new IdById(myDependency.FromObjectId, otherObj.Id)] -
                    myDependency.MaxValue;
                allCombinations[ids] =
                    Math.Max(Math.Max(existingValue, minValue), maxValue);
            }
        }
    }
