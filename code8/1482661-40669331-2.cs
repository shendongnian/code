    // BinaryWriter.Write have overload for Int32
    public static void SaveThreeIntegers(ThreeIntegers value)
    {
        using(var stream = CreateYourStream())
        using (var writer = new BinaryWriter(stream))
        {
            int reordredOne = IPAddress.HostToNetwork(value.One);
            writer.Write(reorderedOne);
            int reordredTwo = IPAddress.HostToNetwork(value.Two);
            writer.Write(reordredTwo);
            int reordredThree = IPAddress.HostToNetwork(value.Three);
            writer.Write(reordredThree);
        }
    }
