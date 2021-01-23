    var objWithMinReduceCost = sub[minRCIndex];
    //Now you have the object of Subproblem derived from your logic.
    //You can access x property of it have further logic to process it.
    for (int i = 0; i < DC1; ++i)
    {
        for (int j = 0; j < DC1; ++j)
        {
             Console.WriteLine(objWithMinReduceCost.x[i, j]);
        }
    }
