    public T Dequeue()
    {
        if (Count == 0)
        {
            return default(T);
        }
        var item = items[0].item;
        items[0] = items[Count-1];
        Count--;
        percolateDown(0);
        return item;
    }
    void percolateDown(int index)
    {
        while (true)
        {
            // The rules for adjusting on percolate down are to swap the
            // node with the highest-priority child. So first we have to
            // find the highest-priority child.
            int hpChild = index*2+1;
            if (hpChild >= Count)
            {
                break;
            }
            if (hpChild+1 < Count && HasHigherPriority(items[hpChild+1], items[hpChild]))
            {
                ++hpChild;
            }
            if (HasHigherPriority(items[hpChild, items[index]))
            {
                var temp = items[index];
                items[index] = items[hpChild];
                items[hpChild] = temp;
            }
            else
            {
                break;
            }
            index = hpChild;
        }
    }
