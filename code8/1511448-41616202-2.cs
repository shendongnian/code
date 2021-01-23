    static void Main(string[] args)
    {
        List<SomeObject> myCollection = new List<SomeObject>()
        {
            new SomeObject() { Amount = 3 },
            new SomeObject() { Amount = 6 },
            new SomeObject() { Amount = 9 }
        };
        CalculatorSetter commonCalculator = new CalculatorSetter();
        int totalToAccumulate = 0;
        for (int i = 0; i < myCollection.Count; i++)
        {
            PopulateAndCalculate(myCollection[i], commonCalculator, ref totalToAccumulate);
        }
        commonCalculator.UpdateTotalAmount(totalToAccumulate);
        Console.WriteLine($"The total accumulated is: {totalToAccumulate}");
        Console.WriteLine($"The first total accumulated is: {myCollection[0].TotalAmount}");
    }
