    using System.Collections.Generic;
    using IMyMap = SomeExample.IMap<int, System.Collections.Generic.IEnumerable<bool>>;
    namespace SomeExample
    {
        public interface IMap<T, S>
        {
            T Map(S source);
        }
        public class ExampleUsage
        {
            public IMyMap Foo { get; set; }
            public void SetFoo()
            {
                Foo = (IMyMap) new object();
                Foo = (IMap<int, IEnumerable<bool>>) new object(); // Same thing
            }
        }
    }
