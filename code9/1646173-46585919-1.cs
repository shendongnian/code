    private int _size;
    private T[] _items;
    public void Add(T item)
    {
    	if (this._size == this._items.Length)
    	{
    		this.EnsureCapacity(this._size + 1);
    	}
    	this._items[this._size++] = item;
    	this._version++;
    }
    private void EnsureCapacity(int min)
    {
    	if (this._items.Length < min)
    	{
    		int num = (this._items.Length != 0) ? (this._items.Length * 2) : 4;
    		if (num > 2146435071)
    		{
    			num = 2146435071;
    		}
    		if (num < min)
    		{
    			num = min;
    		}
    		this.Capacity = num;
    	}
    }
