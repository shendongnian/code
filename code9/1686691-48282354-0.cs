    public void InsertRange(int index, IEnumerable<T> collection) {
        // ...
 
        ICollection<T> c = collection as ICollection<T>;
        if( c != null ) {    // if collection is ICollection<T>
         // this is the optimzed version if you use ArrRange with a list
            int count = c.Count;
            if (count > 0) {
                EnsureCapacity(_size + count);
                if (index < _size) {
                    Array.Copy(_items, index, _items, index + count, _size - index);
                }
                
                // If we're inserting a List into itself, we want to be able to deal with that.
                if (this == c) {
                    // Copy first part of _items to insert location
                    Array.Copy(_items, 0, _items, index, index);
                    // Copy last part of _items back to inserted location
                    Array.Copy(_items, index+count, _items, index*2, _size-index);
                }
                else {
                    T[] itemsToInsert = new T[count];
                    c.CopyTo(itemsToInsert, 0);
                    itemsToInsert.CopyTo(_items, index);                    
                }
                _size += count;
            }                
        }
        else {
        // this is the loop version that you use
            using(IEnumerator<T> en = collection.GetEnumerator()) {
                while(en.MoveNext()) {
                    Insert(index++, en.Current);                                    
                }                
            }
        }
        _version++;            
    }
