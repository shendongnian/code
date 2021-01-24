    public static class FactoryService
    {
        private static readonly Dictionary<Type, Func<IFactory>> factories = new Dictionary<Type, Func<IFactory>>()
        {
            { typeof(IRecipeFactory), () => new RecipeFactory() },
            { typeof(IItemFactory), () => new ItemFactory() },
            { typeof(ITileFactory), () => new TileFactory() }
        };
        public static T GetFactory<T>() where T : IFactory
        {
            T factory = default(T);
            Type requestedType = typeof(T);
            if (factories.ContainsKey(requestedType))
            {
                factory = (T)factories[requestedType].Invoke();
            }
            return factory;
        }
    }
    public interface IFactory { }
    public interface IRecipeFactory : IFactory { }
    public interface IItemFactory : IFactory { }
    public interface ITileFactory : IFactory { }
    public class RecipeFactory : IRecipeFactory { }
    public class ItemFactory : IItemFactory { }
    public class TileFactory : ITileFactory { }
