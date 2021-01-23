    public class MyEnumerable<T> : IEnumerable, IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        { 
            ... // return an enumerator 
        }
        // Note: no access modifiers allowed for explicit declaration
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // call the generic method
        }
    }
