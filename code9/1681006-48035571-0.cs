           static void Main(string[] args)
            {
                List<int> original = new List<int>() { 3, 6, 12, 7, 7, 7, 7, 8, 10, 5, 5, 4 };
                List<int> temp = null;
                while (original.Count > 0)
                {
                    int count = 1;
                    for(; (count < original.Count) && (original[count] >= original[count - 1]); count++);
                    temp = original.Take(count).ToList();
                    original = original.Skip(count).ToList();
                }
            }
