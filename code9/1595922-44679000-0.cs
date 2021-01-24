        var input = Pinvoke.CreateFile(inputFile, DesiredAccess.GENERIC_READ, 0, ref securityAttributes,
                    CreationDisposition.OPEN_EXISTING, 0, IntPtr.Zero);
        var output = Pinvoke.CreateFile(outputFile, DesiredAccess.GENERIC_WRITE, 0, ref securityAttributes,
                     CreationDisposition.CREATE_NEW, 0, IntPtr.Zero);
        startupInfo.hStdInput = input;
        startupInfo.hStdOutput = output;
        ...
        public enum DesiredAccess : uint
        {
            GENERIC_WRITE = 30,
            GENERIC_READ = 31
        }
        public enum CreationDisposition : uint
        {
            CREATE_NEW = 1,
            CREATE_ALWAYS = 2,
            OPEN_EXISTING = 3,
            OPEN_ALWAYS = 4,
            TRUNCATE_EXISTING = 5
        }
