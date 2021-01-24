    public static class Volatile
    {
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static bool Read(ref bool location)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }
 
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static void Write(ref byte location, byte value)
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }
    }
