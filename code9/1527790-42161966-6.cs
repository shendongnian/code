    public bool IsOrdered<T>(this IEnumerable<T> src) where T: IComparable
    {
        for(int i = 1; i < myList.Count; i++)
        {
            if(myList[i - 1].CompareTo(myList[i]) == 1) return false;
        }
        return true;
    }
