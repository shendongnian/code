    public interface IHasId
    {
        int Id { get; }
    }
    public class Foo<T> where T : IHasId
    {
        private List<T> children;
        public IHasId GetById(int id)
        {
            return this.children.FirstOrDefault(x => x.Id == id);
        }
    }
