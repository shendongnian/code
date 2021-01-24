    public void CopyTo_Fast(Stream Destination, int Buffersize)
    {
        byte[] BufferA = new byte[Buffersize];
        byte[] BufferB = new byte[Buffersize];
        int Abytes = Read(BufferA, 0, BufferA.Length);//read first buffer
        if (Abytes < Buffersize) //trivial case stream too small for two buffers
        {
            Destination.Write(BufferA, 0, Abytes);
            return;
        }
        int Bbytes = 0;
        Task Writer;
        Task Reader;
    
        while(true) //Read to end
        {
            Writer = Task.Run(() => Destination.Write(BufferA, 0, Abytes));
            Reader = Task.Run(() => Bbytes = Read(BufferB, 0, Buffersize));
            Task.WaitAll(Writer, Reader);
            if (Bbytes == 0) return;
    
            Writer = Task.Run(() => Destination.Write(BufferB, 0, Bbytes));
            Reader = Task.Run(() => Abytes = Read(BufferA, 0, Buffersize));
            Task.WaitAll(Writer, Reader);
            if (Abytes == 0) return;
        }
    }
