    public abstract class ObtainableItem
    {
        public string Name { get; private set; }
        public ObtainableItem(string name)
        {
            Name = name;
        }
    }
    public abstract class WorldItem
    {
    }
    public interface IActsOn<in TWorldItem>
        where TWorldItem : WorldItem
    {
        void ApplyTo(TWorldItem worldItem);
    }
    public class World
    {
        // If profiling shows that this is a performance issue, a cache keyed by tWorldItem, tInvItem 
        // should fix it.  No expiry or invalidation should be needed.
        private Action<ObtainableItem, WorldItem> GetApplyTo(Type tWorldItem, Type tInvItem)
        {
            var tActOn = typeof(IActsOn<>).MakeGenericType(tWorldItem);
            if (!tActOn.IsAssignableFrom(tInvItem))
            {
                return null;
            }
            var methodInfo = tActOn.GetMethod(nameof(IActsOn<WorldItem>.ApplyTo));
            return new Action<ObtainableItem, WorldItem>((invItem, worldItem) =>
            {
                methodInfo.Invoke(invItem, new object[] { worldItem });
            });
        }
        public bool IsDropTarget(WorldItem worldItem, ObtainableItem item) 
            => GetApplyTo(worldItem.GetType(), item.GetType()) != null;
        public void ActOn(WorldItem worldItem, ObtainableItem item)
        {
            var actOn = GetApplyTo(worldItem.GetType(), item.GetType());
            if (actOn == null)
            {
                throw new InvalidOperationException();
            }
            actOn(item, worldItem);
        }
    }
