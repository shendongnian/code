    public static ThreeIntegers LoadThreeIntegers()
    {
        using(var stream = CreateYourStream())
        using (var writer = new BinaryReader(stream))
        {
            int rawValueOne = reader.ReadInt32();
            int valueOne = IPAddress.NetworkToHostOrder(rawValueOne);
            int rawValueTwo = reader.ReadInt32();
            int valueTwo = IPAddress.NetworkToHostOrder(rawValueTwo);
            int rawValueThree = reader.ReadInt32();
            int valueThree = IPAddress.NetworkToHostOrder(rawValueThree);
        }
    }
