    public static Boolean GetBitX(byte[] bytes, int x) {
        var index = x/8;
        System.Collections.BitArray ba = new BitArray(new byte[]{bytes[index]});
        return ba.Get(x);
    } 
