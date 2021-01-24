    var A = 3;
    int iterationMax = 0;
    double actualMax = 0;
    List<double> tmp = new List<double> {400,0,-300,400,600,300,400,1200,900,400,1200,1500};
    List<double> listMax = new List<double>();
    for (int i = 0; i < tmp.Count; i++)
    {
        if (iterationMax < A) // A == 3
        {
            if (tmp[i] > actualMax)
            {
                actualMax = tmp[i];
            }
            iterationMax++;
        }
        if (iterationMax == A)
        {
            listMax.Add(actualMax);
            actualMax = 0;
            iterationMax = 0;
        }
    }
    Console.WriteLine("\nMaxs: ");
    foreach (double max in listMax)
    {
        Console.Write(max + ", ");
    }
