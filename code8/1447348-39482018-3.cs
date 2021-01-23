    public void Test() {
        int[] numbers = { 121, 124, 131, 135, 219, 287, 361, 367, 382, 420 };
        var onlyfirstNumbersLessThanGiven = numbers.TakeWhile(n => n < 135).Last();
        Console.WriteLine("First numbers less than ");
        Console.WriteLine(onlyfirstNumbersLessThanGiven);
    }
