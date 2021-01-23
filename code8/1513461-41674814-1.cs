    public class ChosenItemsContainer : IItemContainer<FabulousItem>, IItemContainer<NiceItem>, IItemContainer<GreedyItem>
    {
        // these properties are only visible when casting to the correct
        // interface. Which the public properties below will do.
        FabulousItem IItemContainer<FabulousItem>.ChosenItem { get; set; }
        GreedyItem IItemContainer<GreedyItem>.ChosenItem { get; set; }
        NiceItem IItemContainer<NiceItem>.ChosenItem { get; set; }
        // return this as IItemContainer<FabulousItem>
        public IItemContainer<FabulousItem> AsFabulous
        {
            get
            {
                return (IItemContainer<FabulousItem>)this;
            }
        }
        // return this as IItemContainer<NiceItem>
        public IItemContainer<NiceItem> AsNice
        {
            get
            {
                return (IItemContainer<NiceItem>)this;
            }
        }
        // return this as IItemContainer<GreedyItem>
        public IItemContainer<GreedyItem> AsGreedy
        {
            get
            {
                return (IItemContainer<GreedyItem>)this;
            }
        }
    }
---
    ChosenItemsContainer container = new ChosenItemsContainer();
    container.AsFabulous.ChosenItem = new FabulousItem();
    container.AsNice.ChosenItem = new NiceItem();
    container.AsGreedy.ChosenItem = new GreedyItem();
  
