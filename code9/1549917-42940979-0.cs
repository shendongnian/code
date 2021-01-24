    //Bools to Bytes...
    bool[] bools = ...
    BitArray a = new BitArray(bools);
    byte[] bytes = new byte[a.Length / 8];
    a.CopyTo(bytes, 0);
    //Bytes to ints
    int newInt = BitConverter.ToInt32(bytes); //Change the "32" to however many bits are in your number, like 16 for a short
