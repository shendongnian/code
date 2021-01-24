    for (int i = 1; i < n; i++)
    {
       nfac = nfac * i;
    }
    for (int j = 1; j < k; j++)
    {
       kfac = kfac * j;
    }
    for (int p = 1; p < (n-k); p++)
    {
       nkfac = nkfac * p;
    }
    Console.WriteLine(mfac/(kfac*nkfac));
