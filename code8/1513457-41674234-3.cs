    public class ItemContainer : IItemContainer
    {
        IItemContainer.ChosenItems
        {
            get { // your implementation
            }
            set { // your implementation
            }
        }
    
        T IItemContainer.ChosenItem<T>()
        {
            return ((IItemContainer)this).ChosenItems.OfType<T>().FirstOrDefault();
        }
    }
