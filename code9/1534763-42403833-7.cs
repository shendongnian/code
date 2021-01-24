    static bool almostIncreasingSequence<T>(IEnumerable<T> sequence) where T : IComparable<T>
    {
        bool foundOne = false;
        int i = 0;
        T previous = default(T), previousPrevious = default(T);
        foreach (T t in sequence)
        {
            bool deleteCurrent = false;
            if (i > 0)
            {
                if (previous.CompareTo(t) >= 0)
                {
                    if (foundOne)
                    {
                        return false;
                    }
                    // So, which one do we delete? If the element before the previous
                    // one is in sequence with the current element, delete the previous
                    // element. If it's out of sequence with the current element, delete
                    // the current element. If we don't have a previous previous element,
                    // delete the previous one.
                    if (i > 1 && previousPrevious.CompareTo(t) >= 0)
                    {
                        deleteCurrent = true;
                    }
                    foundOne = true;
                }
            }
            if (!foundOne)
            {
                previousPrevious = previous;
            }
            if (!deleteCurrent)
            {
                previous = t;
            }
            i++;
        }
        return true;
    }
