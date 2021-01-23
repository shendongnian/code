    public override string ReadString()
    {
        //Default code page if both programs use the same code page
        Encoding encoder = System.Text.Encoding.Default;
        //or find out what code page the C++ program is using
        //Encoding encoder = System.Text.Encoding.GetEncoding(codepage);
        //or use English code page to always get "ÁåëÀÇ 7555Â"...
        //Encoding encoder = System.Text.Encoding.GetEncoding(1252);
        //(not recommended)
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
