    namespace GenericArray
    {
        public class MyArray<T>
        {
            T[] array = new T[5];
            public MyArray(int size)
            { //Not used in this programme, because the no. of elements is already set above.
            }
            public void SetItem(int index, T value)
            {
                array[0] = value;
            }
            public T GetItem(int index)
            {
                return array[index];
            }
        }
    }
