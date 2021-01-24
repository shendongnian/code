    public override int Read(byte[] buffer, int offset, int count)
    {
        // read header...
        int res = -1;
        if (base.Position + count - offset > base.Length)
        {
            // EOF, skip the last four bytes (adler32) and read them without decompressing
            res = _deflate.Read(buffer, offset, count - sizeof(int));
        }
        else
        {
            res = _deflate.Read(buffer, offset, count);
        }
        // continue processing the data
    }
