    public void UpdateCollection(List<String> newValues)
    {
        Test2.Clear(); //notifies the list box with the CollectionChanged event
        foreach(var value in newValues)
        {
            Test2.Add(value); //notifies the list box with the new item in the collection
        }
    }
