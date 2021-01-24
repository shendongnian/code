    int height = 4;
    string empty = "    ";
    String star = "";
    for(int i = 0; i<height; i++)
    {
        star += " *";
        empty = empty.Length > 0 ? empty.Remove(0,1) : " ";
        Console.WriteLine(empty + star);
    }
    Console.ReadLine();
