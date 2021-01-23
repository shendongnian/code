    public interface IItemList
    {
        IEnumerable<string> ListItems();
    }
    public interface IItemStorage
    {
        void AddItem( string item );
        void RemoveItem( string item );
    }
