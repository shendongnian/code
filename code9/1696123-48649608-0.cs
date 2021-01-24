    public static class Extensions
    {
        public static bool IsSubsequencetOf<T>(this T[] subset, T[] items)
        {
            if (subset.Length < 1)
                return true;
            if (items.Length < 1)
                return false;
            for (int itemsIndex = 0; itemsIndex <= items.Length - subset.Length; ++itemsIndex)
            {
                if (items[itemsIndex].Equals(subset[0])) // Found a potential start of the subset
                {
                    bool isMatch = true;
                    int itemsIndexInner = itemsIndex + 1;
                    for (int subsetIndex = 1; itemsIndexInner < items.Length && subsetIndex < subset.Length; ++subsetIndex)
                    {
                        if (!items[itemsIndexInner].Equals(subset[subsetIndex]))
                        {
                            isMatch = false;
                            break;
                        }
                        itemsIndexInner++;
                    }
                    if (isMatch)
                        return true;
                }
            }
            return false;
        }
    }
