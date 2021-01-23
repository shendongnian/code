    public static unsafe void doit(short[] inarray, short[][] demux, int nSignals, int nSamples)
    {
        fixed (short *pin=inarray)
        {
            for(int block=0; block < nSamples; block+=64)
            {
                for(int sig=0; sig<nSignals; ++sig)
                {
                    fixed(short *psig = demux[sig])
                    {
                        short* s = pin + block * nSignals + sig;
                        short* d = psig + block;
                        short* e = d + Math.Min(64, nSamples - block);
                        while(d<e)
                        {
                            *d++ = *s;
                            s += nSignals;
                        }
                    }
                }
            }
        }
    }
    public static void Main()
    {
        int nSignals = 16384;
        int nSamples = 20000;
        short[][] demux = new short[nSignals][];
        for (int i = 0; i < demux.Length; ++i)
        {
            demux[i] = new short[nSamples];
        }
        short[] mux = new short[nSignals * nSamples];
        //warm up
        doit(mux, demux, nSignals, nSamples);
        doit(mux, demux, nSignals, nSamples);
        doit(mux, demux, nSignals, nSamples);
        //time it
        var watch = System.Diagnostics.Stopwatch.StartNew();
        doit(mux, demux, nSignals, nSamples);
        watch.Stop();
        Console.WriteLine("Time (ms): " + watch.ElapsedMilliseconds);
    }
