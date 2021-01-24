        // main method - declares a matrix, fills one value, prints all
        static void Main()
        {
            Mat m = new Mat(8, 8);
            m[4, 2] = 55;
            Console.WriteLine(m);
            Console.ReadLine();
        }
        private class Mat
        {
            public Mat(int mRow, int mCol)
            {
                maxCol = mCol;
                maxRow = mRow;
                // prefill data with 0 - could use default
                data = new List<int>(Enumerable.Range(0, mCol * mRow).Select(n => 0)); 
            }
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/
            public int this[int row, int col]
            {
                get
                {
                    return data[row * maxCol + col];
                }
                set { data[row * maxCol + col] = value; }
            }
            // lenghty to string method 
            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append("[ ");
                for (int r = 0; r < maxRow; r++)
                {
                    sb.Append("[ ");
                    for (int c = 0; c < maxCol; c++)
                    {
                        sb.Append(this[r, c]);
                        if (c < maxCol - 1)
                            sb.Append(", ");
                    }
                    sb.Append(" ]\n");
                    if (r < maxRow - 1)
                        sb.Append(", ");
                }
                sb.Append(" ]\n");
                return sb.ToString();
            }
            private int maxCol;
            private int maxRow;
            private List<int> data { get; set; }
        }
