    int[] info = { 74, 90, 80, 63 };
    int[] link = { 2, 6, 0, 3 };
    for(int i = 0; i < Math.Min(info.Length, link.Length); i++)
    {
        Console.Write(info[i] + " ");
        Console.Write(link[i] + " ");
    }
