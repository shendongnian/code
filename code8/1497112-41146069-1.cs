    public static unsafe void dopart(short[] inarray, short[][] demux, int offset, int nSignals, int nSamples)
    {
        fixed (short* pin = inarray)
        {
            for (int block = 0; block < nSamples; block += 64)
            {
                for (int sig = 0; sig < nSignals; ++sig)
                {
                    fixed (short* psig = demux[sig])
                    {
                        short* s = pin + (offset + block) * nSignals + sig;
                        short* d = psig + offset + block;
                        short* e = d + Math.Min(64, nSamples - block);
                        while (d < e)
                        {
                            *d++ = *s;
                            s += nSignals;
                        }
                    }
                }
            }
        }
    }
    public static unsafe void doit(short[] inarray, short[][] demux, int nSignals, int nSamples)
    {
        int steps = (nSamples + 1023) / 1024;
        ParallelOptions options = new ParallelOptions();
        options.MaxDegreeOfParallelism = 4;
        Parallel.For(0, steps, options, step => {
            int offset = (int)(step * 1024);
            int size = Math.Min(1024, nSamples - offset);
            dopart(inarray, demux, offset, nSignals, size);
        });
    }
