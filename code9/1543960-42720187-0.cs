    static double[] xarisxi(double[] parsedMasiv)
    {
        double [] returnedMmasiv = new double[parsedMasiv.Length];
        int k = 0;
        while (k < returnedMmasiv.Length)
        {
            returnedMmasiv[k] = Math.Pow(parsedMasiv[k], k);
            Console.WriteLine(returnedMmasiv[k]);
            k++;
        }
        return returnedMmasiv;
    }
