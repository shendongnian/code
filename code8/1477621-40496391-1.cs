    public static async Task PopulateListAsync(ObservableCollection<MyClass> myList) 
    {
        // newList can be an List<MyClass> type, not ObservableCollection
        var newList = await FormatListAsync();
        // change displayed list with new data
        myList.Clear();
        foreach(var newValue in newList)
            myList.Add(newValue);
    }
