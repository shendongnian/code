    public enum BinaryType : uint
    {
        SCS_32BIT_BINARY = 0,
        SCS_64BIT_BINARY = 6,
        SCS_DOS_BINARY = 1,
        SCS_OS216_BINARY = 5,
        SCS_PIF_BINARY = 3,
        SCS_POSIX_BINARY = 4,
        SCS_WOW_BINARY = 2
    }
    public static BinaryType? GetBinaryType(string path)
    {
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            stream.Seek(0x3C, SeekOrigin.Begin);
            using (var reader = new BinaryReader(stream))
            {
                if (stream.Position + sizeof(int) > stream.Length)
                    return null;
                var peOffset = reader.ReadInt32();
                stream.Seek(peOffset, SeekOrigin.Begin);
                if (stream.Position + sizeof(uint) > stream.Length)
                    return null;
                var peHead = reader.ReadUInt32();
                if (peHead != 0x00004550) // "PE\0\0"
                    return null;
                if (stream.Position + sizeof(ushort) > stream.Length)
                    return null;
                switch (reader.ReadUInt16())
                {
                    case 0x14c:
                        return BinaryType.SCS_32BIT_BINARY;
                    case 0x8664:
                        return BinaryType.SCS_64BIT_BINARY;
                    default:
                        return null;
                }
            }
        }
    }
