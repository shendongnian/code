    public bool Exists(Predicate<T> match)
    {
        return FindIndex(match) != -1;
    }
    
    public int FindIndex(Predicate<T> match)
    {
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < Count);
        return FindIndex(0, _size, match);
    }
    
    public int FindIndex(int startIndex, int count, Predicate<T> match)
    {
        if ((uint) startIndex > (uint) _size)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex,
                ExceptionResource.ArgumentOutOfRange_Index);
        }
    
        if (count < 0 || startIndex > _size - count)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count,
                ExceptionResource.ArgumentOutOfRange_Count);
        }
    
        if (match == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
        }
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < startIndex + count);
        Contract.EndContractBlock();
    
        int endIndex = startIndex + count;
        for (int i = startIndex; i < endIndex; i++)
        {
            if (match(_items[i])) return i;
        }
        return -1;
    }
