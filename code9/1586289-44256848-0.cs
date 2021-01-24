    public class Item
    {
        public int Id { get; }
        public Item(int id)
        {
            Id = id;
        }
    }
    public class Equip : Item
    {
        public Equip(int id) : base(id)
        {
        }
    }
    public class CacheManager
    {
        public TItem GetItem<TItem>(int id) where TItem : Item
        {
            if (typeof(TItem) == typeof(Equip))
            {
                return Server.Instance.Data.Equips[id];
            }
            return Server.Instance.Data.Items[id];
        }
    }
