    int num = 5;
    Func<double[], double> del = CreateLambda<double>(num);
    
    double[] values = Enumerable.Range(1, num).Select(x => (double)x).ToArray();
    double result = del(values);
    
    Console.WriteLine("{0}={1}", string.Join("+", values), result);
