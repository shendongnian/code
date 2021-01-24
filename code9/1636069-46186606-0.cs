    public class MyList<T>
    {
        List<T> _FullList = new List<T>();
        List<T> _FilteredList = new List<T>();
        public void Add(T item)
        {
            Insert(_FullList, item);
            if(somecondition)
                Insert(_FilteredList, item);
        }
        public void Remove(T item)
        {
            _FullList.Remove(item);
            _FilteredList.Remove(item);
        }
        void Insert(List<T> list, T item)
        {
            var index = list.BinarySearch(item);
            if (index < 0) index = ~index;
            list.Insert(index, item);
        }
        //other methods needed 
    }
