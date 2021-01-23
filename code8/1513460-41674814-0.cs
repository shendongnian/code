    public class ChosenItemsContainer : IItemContainer<FabulousItem>, IItemContainer<NiceItem>, IItemContainer<GreedyItem>
    {
        FabulousItem IItemContainer<FabulousItem>.ChosenItem { get; set; }
        GreedyItem IItemContainer<GreedyItem>.ChosenItem { get; set; }
        NiceItem IItemContainer<NiceItem>.ChosenItem { get; set; }
        // return this as IItemContainer<FabulousItem>
        public IItemContainer<FabulousItem> Fabulous
        {
            get
            {
                return (IItemContainer<FabulousItem>)this;
            }
        }
        // return this as IItemContainer<NiceItem>
        public IItemContainer<NiceItem> Nice
        {
            get
            {
                return (IItemContainer<NiceItem>)this;
            }
        }
        // return this as IItemContainer<GreedyItem>
        public IItemContainer<GreedyItem> Greedy
        {
            get
            {
                return (IItemContainer<GreedyItem>)this;
            }
        }
    }
---
    ChosenItemsContainer c = new ChosenItemsContainer();
    c.Fabulous.ChosenItem = new FabulousItem();
    c.Nice.ChosenItem = new NiceItem();
    
