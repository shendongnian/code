    public int[] practice_5(List<int> items)
    {
        if (items == null)
        {
           return null;
        }
        else
        {
           List<int> items_sorted = items.OrderBy(p => p).ToList();
           return items_sorted.ToArray();
        }
    }
