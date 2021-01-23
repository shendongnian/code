    public interface IInventoryManager
    {
        IEnumerable<string> ListItems();
        void AddItem( string item );
        void RemoveItem( string item );
    }
