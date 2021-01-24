    public interface ItemsRepository
    {
       IEnumerable<Item> GetAll();
       void Update(Item item);
    }
