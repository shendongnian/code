    public static List<int> RemoveSmallest(List<int> numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException("numbers");
        }
        if (numbers.Count > 1)
        {
            int smallest = numbers[0];
            int smallestIdx = 0;
            for (int i = 1; i < numbers.Count; ++i)
            {
                if (numbers[i] < smallest)
                {
                    smallest = numbers[i];
                    smallestIdx = i;
                }
            }
            return new List<int>(numbers.Where((value, index) => index != smallestIdx));
        }
        else
        {
            return new List<int>(0);
        }
    }
