    public static class RankExtensions
    {
        public static int GetNumericValue(this Rank rank)
        {
            return (rank < Rank.Ten) ? (int)rank : 10;
        }
    }
