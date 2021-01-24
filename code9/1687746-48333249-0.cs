    public void insert(T item)
    {
        // fill in the code as directed below:
        // insert item into items container
        // throws FullBagException if necessary
        if(isFull())
        {
           throw new FullBagException();
        }
        items[++lastIndex] = item;
    }
