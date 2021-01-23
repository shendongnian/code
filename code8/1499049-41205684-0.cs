    private static int[] StringToIntArray(string str)
        {
            List<int> ints = new List<int>();
            foreach (char chr in str)
            {
                // Technically you don't have to be explicit about the cast but I include it here for clarity
                int chrAsInt = (int)chr;
                // Do the following if you don't care about capital vs. lowercase
                // Otherwise, tweak the numbering system a little
                if (chrAsInt >= 97)
                {
                    ints.Add(chrAsInt - 96);
                }
                else
                {
                    ints.Add(chrAsInt - 64);
                }
            }
            return ints.ToArray();
        }
