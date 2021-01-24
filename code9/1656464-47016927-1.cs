    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    public unsafe struct INFO
    {
        [FieldOffset(0)]
        public fixed byte Name[260];
        [FieldOffset(260)]
        public int Number;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //CustomSecurity.AddAccessRule(new System.Security.AccessControl.AccessRule<MemoryMappedFileRights>("everyone", MemoryMappedFileRights.FullControl, System.Security.AccessControl.AccessControlType.Allow));
            //access memory mapped file (need persistence)
            using (var memMapFile = MemoryMappedFile.CreateOrOpen(
                "Local\\INFO_MAPPING",
                1024,
                MemoryMappedFileAccess.ReadWriteExecute,
                MemoryMappedFileOptions.None,
                System.IO.HandleInheritability.Inheritable))
            {
                using (var accessor = memMapFile.CreateViewAccessor())
                {
                    accessor.Read<INFO>(0, out INFO data);
                    string name;
                    unsafe
                    {
                        name = new String((sbyte*)data.Name, 0, 260);
                    }
                    Console.WriteLine(name);
                    Console.WriteLine(data.Number);
                }
            }
        }
