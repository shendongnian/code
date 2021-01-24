    public class MyArray<T>
    {
        private T[] Array;
        private bool Altered = false;
        public MyArray(int size)
        {
            Array = new T[size + 1];
        }
        public T this[int index]
        {
            get
            {
                return Array[index];
            }
            set
            {
                Altered = true;
                Array[index] = value;
            }
            
        }
        public bool HasBeenAltered()
        {
            return Altered;
        }
    }
