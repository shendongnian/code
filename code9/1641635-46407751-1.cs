    public static void UpdateItemInCollection(AandB person, ObservableCollection<AandB> collection)
    {
        foreach (var m in collection)
        {
            m.Name = "whatever";
        }    
    }
