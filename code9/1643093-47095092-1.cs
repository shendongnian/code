        public void ProcessRequests()
        {
            WorkRequest work;
            if (GetWork(out work))
            {
                try
                {
                    //this actually preallocates 2 * _MAX_MEMORY - for ephemeral segment and LOH
                    // it also performs full GC collect if needed - so you don't need to call it yourself
                    if (!GC.TryStartNoGCRegion(_MAX_MEMORY))
                    {
                        //fail
                    }
                    CancellationTokenSource cts = new CancellationTokenSource(_MAX_PROCESSING_SPAN);
                    long initialMemory = GC.GetTotalMemory(false);
                    Task memoryWatchDog = Task.Factory.StartNew(() =>
                    {
                        while (!cts.Token.WaitHandle.WaitOne(_MEMORY_CHECK_INTERVAL))
                        {
                            if (GC.GetTotalMemory(false) - initialMemory > _MAX_MEMORY)
                            {
                                cts.Cancel();
                                //and error out?
                            }
                        }
                    })
                    DoProcessWork(work, cts);
                    cts.Cancel();
                    GC.EndNoGCRegion();
                }
                catch (Exception e)
                {
                    //request failed
                }
            }
            else
            {
                //Wait on signal from main process
            }
        }
