    // for parameters of type int[]
    public static int[] BuildAddress(params int[][] addresses)
    {
         return addresses.SelectMany(x => x).ToArray();
    }
    // for parameters of type int with a base int[]
    public static int[] BuildAddress(int[] baseAddress, params int[] addresses)
    {
         return baseAddress.Concat(addresses).ToArray();
    }
