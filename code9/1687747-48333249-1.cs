    public BoundedBag(string name, int size)
    {
         bagName = name;
         this.size = size;
         items = new T[size];
         lastIndex = -1;
    }
    public bool isFull()
    {
        return lastIndex == size - 1;
    }
