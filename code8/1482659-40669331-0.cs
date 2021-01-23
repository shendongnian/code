    public struct ThreeIntegers
    {
        public int One;
        public int Two;
        public int Three;
    }
    public static byte[] ToBytes(this ThreeIntegers value )
    {
        byte[] bytes = new byte[12];
        byte[] bytesOne = IntegerToBytes(value.One);
        Buffer.BlockCopy(bytesOne, 0, bytes, 0, 4);
        byte[] bytesTwo = IntegerToBytes(value.Two);
        Buffer.BlockCopy(bytesTwo , 0, bytes, 4, 4);
        byte[] bytesThree = IntegerToBytes(value.Three);
        Buffer.BlockCopy(bytesThree , 0, bytes, 8, 4);
        return bytes;
    } 
    public static byte[] IntegerToBytes(int value)
    {
        int reordered = IPAddress.HostToNetwork(value);
        return BiConverter.GetBytes(reordered);
    }
