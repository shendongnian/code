    for (int i = 0; i < place.Length; i++) // should be <, not <= (throws exception)
    {
        for (int j = 0; j < place.Length - 1; j++) // should be j++ instead of i++
        {
            if (place[j] > place[j + 1])
            {
                int temp = place[j + 1];
                place[j + 1] = place[j];
                place[j] = temp;
            }    
        }
                    
        Console.WriteLine(place[i]); // is it necessary?
    }
                
    Console.WriteLine();
                
    for (int i = 0; i < place.Length; i++)
    {
        Console.WriteLine(place[i]);
    }
