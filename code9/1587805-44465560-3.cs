    [DllImport("KERNEL32.DLL")]
            public static extern int VirtualQueryEx(UIntPtr hProcess,
                UIntPtr lpAddress, out _MEMORY_BASIC_INFORMATION64 lpBuffer, int dwLength);
    
            [DllImport("KERNEL32.DLL", SetLastError = true)]
            public static extern bool ReadProcessMemory(
                UIntPtr process, ulong address, byte[] buffer, ulong size, ref uint read);
    
            public List<_MEMORY_BASIC_INFORMATION64> MemoryRegion = new List<_MEMORY_BASIC_INFORMATION64>();
    		
    		[DllImport("KERNEL32.DLL", SetLastError = true)]
            public static extern bool WriteProcessMemory(
                UIntPtr process, ulong address, byte[] buffer, uint size, ref uint written);
    
            [DllImport("KERNEL32.DLL")]
            public static extern bool VirtualProtectEx(UIntPtr process, ulong address,
                uint size, uint access, out uint oldProtect);
    
            [DllImport("KERNEL32.DLL")]
            public static extern int CloseHandle(UIntPtr objectHandle);
    
            [DllImport("KERNEL32.DLL")]
            public static extern UIntPtr OpenProcess(uint access, bool inheritHandler, uint processId);
    
            [Flags]
            public enum Protection
            {
                PEReadWrite = 0x40,
                PReadWrite = 0x04
            }
    
            [Flags]
            public enum Access
            {
                Synchronize = 0x100000,
                StandardRightsRequired = 0x000F0000,
                AllAccess = StandardRightsRequired | Synchronize | 0xFFFF
            }
		
		so, now, compiled for any cpu, it finds adreses corectly for 32 bit and 64 bit proceses
		many thanks to:
		@Dirk
		and
		@Loonquawl
