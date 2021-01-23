    public interface IItemContainer
    {
        List<Item> ChosenItems { get; set; }
        T ChosenItem<T>() where T : Item;
    }
