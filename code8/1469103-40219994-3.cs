            finally
            {
                p.OutputDataReceived -= OutputDataReceived;
                p.ErrorDataReceived -= ErrorDataReceived;
                p.Dispose();
                p = null;
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true);
            }
