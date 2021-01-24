    public interface IHasId
    {
        int Id { get; }
    }
    public class Foo<T>
    {
        private List<T> children;
        public IHasId GetById<SubT>(int id)  where SubT : IHasId
        {
            foreach (var child in children.Cast<IHasId>())
            {
                if (child.Id == id)
                {
                    return child;
                }
            }
            return null;
        }
    }
