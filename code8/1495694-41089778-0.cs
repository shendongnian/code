    var startmom = DateTime.Now;
    var timeoutmom = startmom.AddMinutes(2);
    while (!pr.HasExited && DateTime.Now < timeoutmom)
        pr.WaitForExit(200);
    
    if (pr.HasExited)
    {
        WaitForExit();//Ensure that redirected output buffers are flushed
        pr.CancelOutputRead();
        pr.CancelErrorRead();
        __logger.Debug("Execution finished with exit status code: " + pr.ExitCode);
        return pr.ExitCode;
    }
    else
    {
        pr.CancelOutputRead();
        pr.CancelErrorRead();
        __logger.Debug("Timeout while waiting for execution to finish");
        pr.Kill();
        return -100;
    }
