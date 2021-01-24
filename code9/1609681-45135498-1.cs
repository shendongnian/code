    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using static System.Console;
    
    class Program
    {
        [DllImport("libc", SetLastError = true)]
        private static extern int chmod(string pathname, int mode);
    
        // user permissions
        const int S_IRUSR = 0x100;
        const int S_IWUSR = 0x80;
        const int S_IXUSR = 0x40;
    
        // group permission
        const int S_IRGRP = 0x20;
        const int S_IWGRP = 0x10;
        const int S_IXGRP = 0x8;
    
        // other permissions
        const int S_IROTH = 0x4;
        const int S_IWOTH = 0x2;
        const int S_IXOTH = 0x1;
    
        static void Main(string[] args)
        {
            WriteLine("Setting permissions to 0755 on test.sh");
            const int _0755 =
                S_IRUSR | S_IXUSR | S_IWUSR
                | S_IRGRP | S_IXGRP
                | S_IROTH | S_IXOTH;
            WriteLine("Result = " + chmod(Path.GetFullPath("test.sh"), (int)_0755));
    
            WriteLine("Setting permissions to 0644 on sample.txt");
            const int _0644 =
                S_IRUSR | S_IWUSR
                | S_IRGRP
                | S_IROTH;
            WriteLine("Result = " + chmod(Path.GetFullPath("sample.txt"), _0644));
    
            WriteLine("Setting permissions to 0600 on secret.txt");
            const int _0600 = S_IRUSR | S_IWUSR;
            WriteLine("Result = " + chmod(Path.GetFullPath("secret.txt"), _0600));
        }
    }
