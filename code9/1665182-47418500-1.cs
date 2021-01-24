    public class ItemViewModel()
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public ItemViewModel(ClassA classA)
        {
            Name = classA.Name;
            if( classA.Types[0].Count > 0 )
            {
                Type = $"{classA.Types[0].Count}";
            }
            else if (classA.Types[0].Count > 0 && classA.Types[1].Count > 0)
            {
                Type = $"type 1 count: {Types[0].Count} type 2: count: {Types[1].Count}";
            }
        }
    }
