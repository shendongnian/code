    for (int i = 0; i < 20; i++)
    {
        tablica2[i] = tablica1[20 - (i + 1)];
    
        Console.WriteLine("Tablica 1st :: " + tablica1[i] + " Tablica 1 Reverse "      + tablica1[20 - (i + 1)] + " Tablica 2 " + tablica2[i]);
    }
