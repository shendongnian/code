    public override string ReadString()
    {
        Encoding encoder = Encoding.GetEncoding(1252);
        byte blen = ReadByte();
        if (blen < 0xff)
            return encoder.GetString(ReadBytes(blen));
        var slen = (ushort)ReadInt16();
        if (slen == 0xfffe)
            throw new NotSupportedException(
                ServerMessages.UnicodeStringsAreNotSupported());
        if (slen < 0xffff)
            return encoder.GetString(ReadBytes(blen));
        var ulen = (uint)ReadInt32();
        if (ulen < 0xffffffff)
        {
            var bytes = new byte[ulen];
            for (uint i = 0; i < ulen; i++)
                bytes[i] = ReadByte();
            return encoder.GetString(ReadBytes(blen));
        }
        throw new NotSupportedException(
            ServerMessages.EightByteLengthStringsAreNotSupported());
    }
