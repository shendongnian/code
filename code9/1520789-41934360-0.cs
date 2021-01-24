    // inputs
    double[] o8o10 = new double[] { 2, 1, 0 }; // Scoring!$O$8:$O$10
    double[] n8n10 = new double[] { 1, 1.5, 9999999999 }; // Scoring!$N8:$N10
    double e28 = 0; // E28
    
    // entries to SUMPRODUCT
    List<int> test1 = new List<int>();
    List<int> test2 = new List<int>();
    Array.ForEach(n8n10, x => { test1.Add((e28 <= x) ? 0 : 1); });
    Array.ForEach(n8n10, x => { test2.Add((e28 >= x) ? 0 : 1); });
    // ROW(INDIRECT("'Scoring'!$M1:$M3")) should be an array !
    List<int> test3 = new List<int> { 1, 1, 1 }; 
    
    // evalue SUMPRODUCT
    int sumProductResult = 0;
    for (var i=0; i<test1.Count; i++)
    {
        sumProductResult += test1[i] * test2[i] * test3[i];
    }
    
    // evalute INDEX
    double indexResult = 0;
    indexResult = o8o10[sumProductResult];
    
    // output
    Console.WriteLine(indexResult);
    Console.ReadKey();
