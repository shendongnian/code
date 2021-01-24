    public void Add(Base baseItem)
    {
         if(items.Any(x => baseItem.IsDuplicateOf(x)))
             throw new DuplicateItemException(...);
         items.Add(baseItem);
    }
