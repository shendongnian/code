            public static byte HexToByte(byte[] buffer, int index)
            {
                return HexToNibble((byte)((buffer[index] * 0x10) + HexToNibble(buffer[index + 1])));
            }
            private static byte HexToNibble(byte HexChar)
            {
                if ((HexChar >= 48) && (HexChar <= 57))
                    return (byte)(HexChar - 48);
                if ((HexChar >= 65) && (HexChar <= 70))
                    return (byte)(HexChar - 55);
                if ((HexChar >= 97) && (HexChar <= 102))
                    return (byte)(HexChar - 87);
                return 0;
            }
    // calculate the checksum
    checksum = 0;
    for (int j = 0; j < count; j++)
        checksum += utils.HexToByte(buffer, buffer[2 + i * 2]);
