    public interface IChild<P> {
        P Parent { get; set; }
    }
    public interface IParent<C> {
        IList<C> Children { get; }
    }
    public class ParentBase<P, C> : IParent<C> where C : IChild<P>  {
        public IList<C> Children { get; } = new List<C>();
    }
