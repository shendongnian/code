    public int[] practice_5(List<int> items)
    {
        if (items == null)
        {
           return null;
        }
        else
        {
           return items.OrderBy(p => p).ToArray();
        }
    }
