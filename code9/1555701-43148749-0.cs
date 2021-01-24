    public class SemanticComparer : IComparer<string>
    {
        private static Regex _splitter = new Regex("\\W+");
        /// <summary>Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.</summary>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, 
        /// as shown in the following table.Value Meaning Less than zero<paramref name="x" /> is less than <paramref name="y" />.Zero
        /// <paramref name="x" /> equals <paramref name="y" />.Greater than zero<paramref name="x" /> is greater than <paramref name="y" />.</returns>
        /// 
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
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
