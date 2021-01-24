     var KernelSession = new TraceEventSession(KernelTraceEventParser.KernelSessionName, null);
            var KernelSource = new ETWTraceEventSource(KernelTraceEventParser.KernelSessionName, TraceEventSourceType.Session);
            var KernelParser = new KernelTraceEventParser(KernelSource);
            KernelSession.StopOnDispose = true;
            
            KernelSession.EnableKernelProvider(
                KernelTraceEventParser.Keywords.DiskFileIO |
                KernelTraceEventParser.Keywords.FileIOInit |
                KernelTraceEventParser.Keywords.Thread |
                KernelTraceEventParser.Keywords.FileIO
                );
            KernelParser.All += GetLog;
           
            KernelSource.Process();
           
        }
        private static void GetLog(TraceEvent obj)
        {
            var log = obj.ToString();
            if (log.Contains(@"E:\Final\ETW"))//&& !log.Contains("FileIo/Create")
            {
                Console.WriteLine(log);
            }  
        }
