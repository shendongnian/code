    public class MyArray<T>
    {
        private T[] array;
        private bool altered = false;
        public MyArray(int size)
        {
            array= new T[size + 1];
        }
        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                altered = true;
                array[index] = value;
            }
            
        }
        public bool HasBeenAltered()
        {
            return altered;
        }
    }
