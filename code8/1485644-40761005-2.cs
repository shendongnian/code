        int r;
        int c;
        Console.Write("Enter number of rows: ");
        r = (int)Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter number of columns: ");
        c = (int)Convert.ToInt32(Console.ReadLine());
        c++; //add an extra column for the added 0's
        int[,] matrix = new int[r, c];
