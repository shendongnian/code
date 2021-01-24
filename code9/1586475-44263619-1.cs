    var bytes = new binaryTranslate()
        .ConvertBinstrToBytes("00000000");
    Assert.Equal(bytes.Length, 1);
    Assert.Equal(bytes[0], 0b00000000);
    bytes = new binaryTranslate()
        .ConvertBinstrToBytes("10000000");
    Assert.Equal(bytes.Length, 1);
    Assert.Equal(bytes[0], 0b10000000);
    bytes = new binaryTranslate()
        .ConvertBinstrToBytes("11111111");
    Assert.Equal(bytes.Length, 1);
    Assert.Equal(bytes[0], 0b11111111);
    bytes = new binaryTranslate()
        .ConvertBinstrToBytes("00000001");
    Assert.Equal(bytes.Length, 1);
    Assert.Equal(bytes[0], 0b00000001);
    bytes = new binaryTranslate()
        .ConvertBinstrToBytes("1100110000110011");
    Assert.Equal(bytes.Length, 2);
    Assert.Equal(bytes[0], 0b11001100);
    Assert.Equal(bytes[1], 0b00110011);
