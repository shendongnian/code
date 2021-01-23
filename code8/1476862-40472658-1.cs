    static void Calculate(int[] numbers)
    {
        int[] CalculateMultTable = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] * numbers[i];
            }
        }
    }
