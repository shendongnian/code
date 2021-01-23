    int x;
    string newX = "0x00A3B43C";
    
    if (int.TryParse(newX.Substring(2), NumberStyles.HexNumber, CultureInfo.CurrentCulture, out x))
    {
        Console.WriteLine("x = {0}", x); // 10728508
    }
