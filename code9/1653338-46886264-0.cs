    for (a = 0; a < baris; a++)
    {
    	int rowSum = 0; //Below loop can be avoided using LINQ
    	for (b = 0; b < kolom; b++)
    	{
    	  rowSum += matrik_a[a, b];
    	}
    	for (b = 0; b < kolom; b++)
    	{
    		matrik_b[a, b] = matrik_a[a, b] + rowSum;
    		Console.Write("{0:d}\t", matrik_b[a, b]);
    	}
    }
