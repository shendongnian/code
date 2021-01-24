    namespace ClassLibrary1
    {
        public class BaseThingy { }
    
        public class DerivedThingy : BaseThingy { }
    
        public class BaseEnumerator : IReadOnlyCollection<BaseThingy>
        {
            public int Count => throw new NotImplementedException();
 
            public IEnumerator<BaseThingy> GetEnumerator()
            {
                throw new NotImplementedException();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
        public class DerivedEnumerator : BaseEnumerator, IReadOnlyCollection<DerivedThingy>
        {
            IEnumerator<DerivedThingy> IEnumerable<DerivedThingy>.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
        public class Application
        {
            public void Main()
            {
                BaseEnumerator baseEnumerator = new BaseEnumerator();
                DerivedEnumerator derivedEnumerator = new DerivedEnumerator();
                // Works...
                var x = baseEnumerator.Where(s => s.GetHashCode() == s.GetHashCode());
                // Works now
                var y = derivedEnumerator.Where<DerivedThingy>(s => s.GetHashCode() == s.GetHashCode());
            }
        }
    }
