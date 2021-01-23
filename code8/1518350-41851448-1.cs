    public interface IHasPropertyP { Foo P { get; } }
    public class B: D, IHasPropertyP { ... }
    public class C: D, IHasPropertyP { ... }
    List<D> dees = ... //I don't care if the type of the items is B, C or D
    var onlyThoseWhoHavePropertyP = dees.OfType<IHasPropertyP>();
    onlyThoseWhoHavePropertyP.Where(v => v.P == x).{whatever needs to be done...}
