    public interface IGenerator<T> where T : IItem
    {
        IList<T> Generate();
    }
    public class ItemAGenerator : IGenerator<ItemA>
    {
        public IList<ItemA> Generate()
        {
            // do stuff
            return List<ItemA>;
        }
    }
