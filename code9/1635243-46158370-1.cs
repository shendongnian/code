    public class BaseY<T>
    {
    }
    public interface IBaseX<T, I>
           where T : BaseY<I>
    {
    }
    public class BaseX<T, I> : IBaseX<T, I>
           where T : BaseY<I>
    {
    }
    // it works but,
    public interface IMyClass<T, I>
           where T : BaseY<I>, IBaseX<T, I>
    {
    }
    public class MyClass<T, I>
           where T : BaseY<I>, IBaseX<T, I>, IMyClass<T, I>
    {
    }
