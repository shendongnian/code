    double[] numbers1 = { 2.0, 2.1, 2.2, 2.3, 2.4, 2.5 };
    double[] numbers2 = { 2.0, 2.1, 2.2, 2.3, 2.4, 2.5 };
    
    IEnumerable<double> onlyInFirstSet = numbers1.Except(numbers2);
    if(onlyInFirstSet.Count() ==0)
     Console.WriteLine("equal");
