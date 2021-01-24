    string pn = "MyProcessName.exe";
    var readOpSec  = new PerformanceCounter("Process","IO Read Operations/sec", pn);
    var writeOpSec = new PerformanceCounter("Process","IO Write Operations/sec", pn);
    var dataOpSec  = new PerformanceCounter("Process","IO Data Operations/sec", pn);
    var readBytesSec = new PerformanceCounter("Process","IO Read Bytes/sec", pn);
    var writeByteSec = new PerformanceCounter("Process","IO Write Bytes/sec", pn);
    var dataBytesSec = new PerformanceCounter("Process","IO Data Bytes/sec", pn);
    
    var counters = new List<PerformanceCounter>
                    {
                    readOpSec,
                    writeOpSec,
                    dataOpSec,
                    readBytesSec,
                    writeByteSec,
                    dataBytesSec
                    };
    
    // get current value
    foreach (PerformanceCounter counter in counters)
    {
        float rawValue = counter.NextValue();
    
        // display the value
    }
