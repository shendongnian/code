    using System.Collections.Generic;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main (string[] args)
            {
                IMaster<IChild>           master1 = new ConcreteMaster ();
                IMaster<BaseChild>        master2 = new ConcreteMaster ();
                IMaster<ConcreteChild>    master3 = new ConcreteMaster ();
                BaseMaster<ConcreteChild> master4 = new ConcreteMaster ();
            }
        }
        public interface IChild { }
        public interface IMaster<out T> where T : IChild
        {
            IReadOnlyList<T> Children { get; }
        }
        public abstract class BaseMaster<T> : IMaster<T> where T : IChild
        {
            private readonly List<T> children = new List<T> ();
            public IReadOnlyList<T> Children => children;
            public void Add (T child)
            {
                children.Add (child);
            }
        }
        public abstract class BaseChild : IChild { }
        public class ConcreteMaster : BaseMaster<ConcreteChild> { }
        public class ConcreteChild : BaseChild {  }
    }
