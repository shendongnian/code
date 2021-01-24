    public class Options
    {
        public HashSet<int> TrueIds
        {
            get
            {
                return RestrictedCategoryIds?.ToHashSet();
            }
        }
        private int[] Ids{ get; set; }
    }
