    int[] draw = new int[] {3, 33, 12, 34, 15};
    
    var group1 = Enumerable.Range(1, 10);
    var group2 = Enumerable.Range(11, 10);
    var group3 = Enumerable.Range(21, 10);
    
    int missing1 = group1.Count(i => !draw.Contains(i));
    int missing2 = group2.Count(i => !draw.Contains(i));
    int missing3 = group3.Count(i => !draw.Contains(i));
