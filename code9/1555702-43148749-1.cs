    public class SemanticComparer : IComparer<string>
    {
        private static Regex _splitter = new Regex("\\W+");
        public int Compare(string x, string y)
        {
            string[] partsX = _splitter.Split(x);
            string[] partsY = _splitter.Split(y);
            int shortest = Math.Min(partsX.Length, partsY.Length);
            for (int index = 0; index < shortest; index++)
            {
                int intX, intY;
                int result;
                if (int.TryParse(partsX[index], out intX) && int.TryParse(partsY[index], out intY))
                {
                    result = intX.CompareTo(intY);
                }
                else
                {
                    result = string.Compare(partsX[index], partsY[index], StringComparison.Ordinal);
                }
                if (result != 0)
                {
                    return result;
                }
            }
            return 0;
        }
    }
