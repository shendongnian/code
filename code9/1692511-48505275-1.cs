    // read
    byte[] arr = File.ReadAllBytes(fileName);
    TSensor val = default;
    fixed (byte* ptr = arr)
    {
        Unsafe.Copy(ref val, ptr);
    }
    System.Console.WriteLine(val.b1);
    System.Console.WriteLine(val.i1);
    System.Console.WriteLine(val.f1);
