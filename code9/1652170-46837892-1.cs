    for (int i = 0; minDate <= maxDate; i++)
    {
        for (int list = 0; list < myList.Count; list++)
        {
            if (myList[list].Count <= i || myList[list][i].Item1 != minDate)
            {
                myList[list].Insert(i, Tuple.Create(minDate, 0));
            }
        }
        minDate = minDate.AddMonths(1);
    }
