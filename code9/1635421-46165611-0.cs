    public class ClassOfInts : IHaveInts<MyInt>
    {
        public MyInt IntHolder { get; }
    }
    public interface IHaveInts<out T> where T : IInt
    {
        T IntHolder { get; }
    }
