    var myFirstDictionary = new SortedDictionary(myFirstList.Count);
    foreach(var item in myFirstList)
    {
        myFirstDictionary[item.Id] = item;
    }
    //updating/creating values in first list by using second list values
    foreach(var item in mySecondList)
    {
        myFirstDictionary[item.Id] = item;
    }
