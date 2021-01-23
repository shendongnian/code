    public static ThreeIntegers LoadThreeIntegers()
    {
        using(var stream = CreateYourStream())
        using (var writer = new BinaryReader(stream))
        {
            int rawValueOne = reader.ReadInt32();
            int valueOne = IPAddress.NetworkToHost(rawValueOne);
            int rawValueTwo = reader.ReadInt32();
            int valueTwo = IPAddress.NetworkToHost(rawValueTwo);
            int rawValueThree = reader.ReadInt32();
            int valueThree = IPAddress.NetworkToHost(rawValueThree);
        }
    }
