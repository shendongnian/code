    public interface INamed
    {
        string Name { get; }
    }
    public Person : INamed
    {
        public string Name {get; set;}
        // etc.
    }
    public People : INamed
    {
        public string Name {get; set;}
        // etc.
    }
    public static void UpdateItemInCollection(INamed person, ObservableCollection<INamed> collection)
    {
        foreach (var m in collection)
        {
            m.Name = m.id == person.id;
        }
    }
