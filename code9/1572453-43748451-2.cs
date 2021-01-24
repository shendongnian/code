     int[] a = new int[s];
     string[] input = Console.ReadLine().Split(' ');
     
     for (i = 0; i < s; i++)
     {
        if (Int32.TryParse(input[i], out a[i])) 
        {
            //successfully parsed
        }
     }
