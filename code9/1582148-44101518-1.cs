    private static int GetNumberBetweenZeroAndTweleve(int inputNumber)
    {
        if (inputNumber < 12)
            return Math.Max(inputNumber, 1);
        return inputNumber % 12 + 1;
    }
