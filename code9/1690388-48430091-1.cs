    // Output is : 1 3 5 7 9 
    for (int i = 0; i < 10; i++)
    {
       if ((i % 2) == 0) // If i is even,
          continue; // continue with next iteration
       Console.Write (i + " ");
    }
