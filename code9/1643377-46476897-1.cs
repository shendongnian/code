    // Should be 40 * processors
    Console.WriteLine((int)infoLength);
    
    //Problem: result is always InfoLengthMismatch
    NtStatus result = NtQuerySystemInformation(SYSTEM_INFORMATION_CLASS.SystemProcessorPerformanceInformation, 
                          infoPtr, infoLength, out infoLength);
    // Will be bigger than 40 * processors
    Console.WriteLine((int)infoLength);
