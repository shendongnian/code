    float var1;
    double var2;
    int var3;
    if (float.TryParse(urMom, out var1))
        Console.WriteLine("Float");
    else if (double.TryParse(urMom, out var2))
        Console.WriteLine("Double");
    else if (int.TryParse(urMom, out var3))
        Console.WriteLine("Int");
