    public class CoordArray<T> : IEnumerable<T>
    {
    
        // ... some other members
        private T[,] arr;
    
        public CoordArray(int width, int height)
        {
            // ... other intialization
            arr = new T[height, width];
        }
    
        private IEnumerable<T> ArrAsEnumerableT
        {
            get
            {
                foreach (var elmt in arr)
                    yield return elmt;
            }
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return ArrAsEnumerableT.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ArrAsEnumerableT.GetEnumerator();
        }
    }
