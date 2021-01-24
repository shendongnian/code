    Console.WriteLine(String.Format("{0,8}{1,3}{2,3}","A","B","C"));
    Console.WriteLine();
    string[,] deska = new string[,] {
        { "1", "2", "3" },
        { "0", "0", "0" },
        { "0", "0", "0" },
        { "0", "0", "0" },
    };
    for (int j = 0; j < deska.GetLength(1)-1 ; j++)
    {
        Console.WriteLine(String.Format("{0,-5}{1,3}{2,3}{3,3}",deska[0,j],deska[1,j],deska[2,j],deska[3,j]));
    }
    Console.ReadKey();
