    for (var i = minDate; i <= maxDate; i = i.AddMonths(1))
    {
        for (int list = 0; list < myList.Count; list++)
        {
            if (!myList[list].Any(tuple => tuple.Item1 == i))
            {
                myList[list].Add(Tuple.Create(i, 0));
            }
        }
    }
    myList.ForEach(item => item.Sort((x, y) => x.Item1.CompareTo(y.Item1)));
