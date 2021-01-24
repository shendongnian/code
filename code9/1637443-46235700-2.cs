    public static class RangeExt
    {
        public static int GetRandomNumberHelper(this Range<int> self)
        {
            return new Random().Next(self.Minimum, self.Maximum);
        }
    }
