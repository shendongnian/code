    public interface IChild<P, C> where P : IParent<P, C> where C : IChild<P, C> {
        P Parent { get; set; }
    }
    
    public interface IParent<P, C> where P : IParent<P, C> where C : IChild<P, C> {
        IList<C> Children { get; }
    }
