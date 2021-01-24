        class MyCollection<T> : IList<T>
        {
            private readonly IList<T> _list = new List<T>();
            public void Insert(int index, T item)
            {
                if (this.Contains(item))
                    throw new IndexOutOfRangeException();
                _list.Insert(index, item);
                //make database call
            }
            // implement all the other features of IList with database calls
