    case NotifyCollectionChangedAction.Move:
        // items between New and Old have moved.  The direction and
        // exact endpoints depends on whether New comes before Old.
        int left, right, delta;
        if (e.OldStartingIndex < e.NewStartingIndex)
        {
            left = e.OldStartingIndex + 1;
            right = e.NewStartingIndex;
            delta = -1;
        }
        else
        {
            left = e.NewStartingIndex;
            right = e.OldStartingIndex - 1;
            delta = 1;
        }
 
        foreach (ItemInfo info in list)
        {
            int index = info.Index;
            if (index == e.OldStartingIndex)
            {
                 info.Index = e.NewStartingIndex;
            }
            else if (left <= index && index <= right)
            {
                 info.Index = index + delta;
            }
        }
    break;
