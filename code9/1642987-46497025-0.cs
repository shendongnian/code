    public unsafe void DoSomething(byte[] data, long src)
    {
        fixed (byte* ptra = data)
        {
            byte* ptrb = ptra + src;
            // do your work... e.g.
            //   ptrb[0] = 10;
            //   ...is equivalent to...
            //   data[src] = 10;
        }
    }
