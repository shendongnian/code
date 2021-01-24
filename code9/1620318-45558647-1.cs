    System.IO.File.ReadLines()
    .Skip(1)                  // header line. Assume trusted to be correct.
    .AsParallel()
    .Select(ParseRecord)      // RecordClass ParseRecord(string line)
    .ForAll(ProcessRecord);   // void ProcessRecord(RecordClass)
