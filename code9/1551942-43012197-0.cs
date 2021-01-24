    private void MoveItem(List<Page> source, int fromOrder, int toOrder)
    {
      if (fromOrder == toOrder)
      { return; }
      
      if (fromOrder < toOrder)
      {
        foreach(Page page in source)
        {
          bool match = page.Order == fromOrder;
          bool between = fromOrder < page.Order && page.Order <= toOrder;
          page.Order = match ? toOrder :
             between ? page.Order - 1 :
             page.Order;
        }
      }
      else
      {
        foreach(Page page in source)
        {
          bool match = page.Order == fromOrder;
          bool between = toOrder <= page.Order && page.Order < fromOrder;
          page.Order = match ? toOrder :
             between ? page.Order + 1 :
             page.Order;
        }
      }
    }
