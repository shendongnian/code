    var list1 = inpArray.ToList();
    var list2 = x.B.Select(b => b.CodeID).ToList();
    if(list1.Count == 0 || list1.Intersect(list2).Count() == list1.Count)
    {
        //Your code
    }
