    for (int j = 0; j < 21; j++)
    {
        for (int i = 0; i <= 21; i++)
        {
            names[j, i] = myArray[j*21 + i].ToString();
            Console.WriteLine(j + " names " + i);    
        }
    }
