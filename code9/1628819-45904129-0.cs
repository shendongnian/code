    Console.WriteLine("ilk aracın hızını giriniz");
    bool missingV1 = !int.TryParse(Console.ReadLine(), out var v1);
    Console.WriteLine("ikinci aracın hızını giriniz");
    bool missingV2 = !int.TryParse(Console.ReadLine(), out var v2);
    Console.WriteLine("yolun uzunluğunu giriniz");
    bool missingX = !int.TryParse(Console.ReadLine(), out var x);
    Console.WriteLine("karşılaşma sürelerini giriniz");
    bool missingT = !int.TryParse(Console.ReadLine(), out var t);
    if (missingV1) {
        v1 = x / t - v2;
        Console.WriteLine(v1);
    } else if (missingV2) {
        ...
    }
