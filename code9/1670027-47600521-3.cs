    internal static class SillyThing
    {
        static public IList<int>
            SortBigger_K_InFrontAnscendingThenAddSmallerEqual_K_Ascending(
                this IList<int> list, int K)
        {
            var biggerK = list
                .Where(item => item > K)   // filter all bigger K
                .OrderBy(i => i)           // order them by value ascending
                .ToList();                 // make list to allow AddRange() later
            // I am putting 4rs into this list
            var smallerK = list
                .Where(item => item <= K)  // filter all smalller equal K
                .OrderBy(i => i);          // order them by value ascending
            biggerK.AddRange(smallerK);    // add to first list
            return biggerK;
        }
    }
