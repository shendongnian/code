    public void RemoveAt(int index) {
        if ((uint)index >= (uint)_size) {
            ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        Contract.EndContractBlock();
        _size--;
        if (index < _size) {
            Array.Copy(_items, index + 1, _items, index, _size - index); // here the entire array will be traversed again
        }
        _items[_size] = default(T);
        _version++;
    }
