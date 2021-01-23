    public interface ITopologicalSort
        {
            string Id { get; }
            IList<ITopologicalSort> Dependencies { get; set; }
        }
