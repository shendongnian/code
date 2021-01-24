    // input to bytes
    List<byte> clearBytes = new List<byte>(Encoding.UTF8.GetBytes("3280:99:20120201123050"));
    // how many padding bytes?
    int needPaddingBytes = 8 - (clearBytes.Count % 8);
    // add them
    clearBytes.AddRange(Enumerable.Repeat((byte)needPaddingBytes, needPaddingBytes));
    // encrypt
    byte[] cipherText = b.Encrypt_ECB(clearBytes.ToArray());
    // to hex
    string cipherTextHex = BitConverter.ToString(cipherText).Replace("-", "").ToLowerInvariant();
