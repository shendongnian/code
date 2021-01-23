    int pingLocalResult = StartProcess("ping", "-n 1 127.0.0.1");
    if (pingLocalResult != 0)
    {
        throw new Exception("Ping 127.0.0.1 failed.");
    }
    int pingZeroResult = StartProcess("ping", "-n 1 0");
    if (pingZeroResult != 0)
    {
        throw new Exception("Ping 0 failed.");
    }
