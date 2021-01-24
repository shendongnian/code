    ReactiveList<object> sourceCollection = new ReactiveList<object>();
    ...
    using (sourceCollection.SuppressChangeNotifications())
    {
        sourceCollection.Clear();
        foreach(var item in ...)
            sourceCollection.Add(item);
    }
