    public class JClsTbInventory : IListContainer<MyClass>
    {
        // ... other properties
        public List<MyClass> LstDetails { get; set; }
        public void SetList(List<MyClass> list)
        { 
            LstDetails = value;
        }
