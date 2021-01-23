    class A
    {
      private List<ItemType> internalList;
      public IEnumerable<ItemType> Items()
      {
        foreach (var item in internalList)
          yield return item;
          // or maybe  item.Copy();
          //           new ItemType(item);
          // depending on ItemType
      }
    
      public RemoveFromList(ItemType toRemove)
      {
        internalList.Remove(toRemove);
        // do other things necessary to keep A in a consistent state
      }
    }
