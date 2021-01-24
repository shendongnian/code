    Dictionary<int, int> sum = polinomio1.Sum(polinomio2);
    for (int i = 0; i < sum.Count; i++)
    {
       Console.WriteLine($"{sum.Keys.ElementAt(i)} {sum.Values.ElementAt(1)}");
    }
