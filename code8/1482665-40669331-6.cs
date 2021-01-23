    // BinaryWriter.Write have overload for Int32
    public static void SaveThreeIntegers(ThreeIntegers value)
    {
        using(var stream = CreateYourStream())
        using (var writer = new BinaryWriter(stream))
        {
            int reordredOne = IPAddress.HostToNetworkOrder(value.One);
            writer.Write(reorderedOne);
            int reordredTwo = IPAddress.HostToNetworkOrder(value.Two);
            writer.Write(reordredTwo);
            int reordredThree = IPAddress.HostToNetworkOrder(value.Three);
            writer.Write(reordredThree);
        }
    }
