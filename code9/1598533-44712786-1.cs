    float var1;
    double var2;
    int var3;
    float.TryParse(urMom, out var1);
    double.TryParse(urMom, out var2)
    int.TryParse(urMom, out var3)
    if (var1 != null)
        Console.WriteLine("Float");
    else if (var2 != null)
        Console.WriteLine("Double");
    else if (var3 != null)
        Console.WriteLine("Int");
