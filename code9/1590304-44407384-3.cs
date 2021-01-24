    List<classList> list1 = new List<classList>();
    List<classList> list2 = new List<classList>();
    
    IEnumerable<classList> enumerable1 = list1;
    IEnumerable<classList> enumerable2 = list2;
    if (list1.Count < list2.Count)
    {
        enumerable1 = enumerable1.Concat(Enumerable.Repeat(default(classList), list2.Count - list1.Count));
    }
    else if (list2.Count < list1.Count)
    {
        enumerable2 = enumerable2.Concat(Enumerable.Repeat(default(classList), list1.Count - list2.Count));
    }
    var resultItems = enumerable1.Zip(enumerable2, (e1, e2) => new CombinedItem
        {
            p1 = e1?.p1,
            p2 = e1?.p2,
            p3 = e1?.p3,
            p4 = e1?.p4,
            q1 = e2?.p1,
            q2 = e2?.p2,
            q3 = e2?.p3,
            q4 = e2?.p4,
        }).ToList();
