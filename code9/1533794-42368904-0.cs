    public interface IStack
    {
      bool IsEmpty { get; }
    }
    public class StackImpl1 : IStack
    {
      public StackImpl1(int size)
      {
         IsEmpty = true;
      }
      public bool IsEmpty { get; }
    }
    public class StackImpl2 : IStack
    {
      public StackImpl2(int size)
      {
         IsEmpty = true;
      }
      public bool IsEmpty { get; }
    }
