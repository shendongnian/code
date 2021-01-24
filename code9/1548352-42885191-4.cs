    var order = new[] { "anger", "fear", "sadness", "disgust", "joy" };
    var highestEmotions = emotions
        .GroupBy(e => e.Item1)  // Put items with equal values together
        .MaxBy(g => g.Key)      // Get the group with the highest value
        .Select(e => e.Item2)   // Get the names in the group
        .InOrder(order);        // Get the names according to the order
