    public class ChosenItemsContainer : IItemContainer<FabulousItem>, IItemContainer<NiceItem>, IItemContainer<GreedyItem>
    {
        FabulousItem IItemContainer<FabulousItem>.ChosenItem { get; set; }
        NiceItem IItemContainer<NiceItem>.ChosenItem { get; set; }
        GreedyItem IItemContainer<GreedyItem>.ChosenItem { get; set; }
    	
    	public T GetChosenItem<T>()
    		where T : Item
    	{
    		return ((IItemContainer<T>)this).ChosenItem;
    	}
    	public void SetChosenItem<T>(T value)
    		where T : Item
    	{
    		((IItemContainer<T>)this).ChosenItem = value;
    	}
    }
