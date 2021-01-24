    public static int[] GetRandomDistribution2(int sum, int amountOfNumbers)
    {
        int[] numbers = new int[amountOfNumbers];
        var random = new Random();
        for (int i = 0; i < amountOfNumbers; i++)
        {
          numbers[i] = random.Next(sum);
        }
        var compeleteSum = numbers.Sum();
        // Scale the numbers down to 0 -> sum
        for (int i = 0; i < amountOfNumbers; i++)
        {
          numbers[i] = (int)(((double)numbers[i] / compeleteSum) * sum);
        }
        // Due to rounding the number will most likely be below sum
        var resultSum = numbers.Sum();
        // Add +1 until we reach "sum"
        for (int i = 0; i < sum - resultSum; i++)
        {
          numbers[random.Next(0, amountOfNumbers)]++;
        }
        return numbers;
    }
