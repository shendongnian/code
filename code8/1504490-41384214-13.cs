    IEnumerable<int> collection = new int[] { 1, 2, 3, 4, 5 };
    var added = collection.Add(6);              // 1, 2, 3, 4, 5, 6
    var inserted = collection.Insert(0, 0);     // 0, 1, 2, 3, 4, 5
    var replaced = collection.Replace(1, 22);   // 1, 22, 3, 4, 5 
    var removed = collection.Remove(2);         // 1, 2, 4, 5
