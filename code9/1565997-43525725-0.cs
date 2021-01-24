    public class ItemBuilder
    {
        public ItemBase Build(ItemType itemType)
        {
            Func<ItemBase> buildAction;
    
            if (itemBuilders.TryGetValue(itemType, out buildAction))
            {
                return buildAction();
            }
    
            return null;
        }
    
        public ItemBuilder RegisterBuilder(ItemType itemType, Func<ItemBase>  buildAction)
        {
            itemBuilders.Add(itemType, buildAction);
            return this;
        }
    
        private Dictionary<ItemType, Func<ItemBase>> itemBuilders = new Dictionary<ItemType, Func<ItemBase>> ();
    }
