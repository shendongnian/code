    using System;
    using System.Runtime.InteropServices;
    
    namespace TestSerial
    {
        class Program
        {
            [Flags]
            public enum OpenFlags
            {
                O_RDONLY = 0,
                O_WRONLY = 1,
                O_RDWR = 2,
    
                O_NONBLOCK = 4,
            }
    
            [DllImport("libc")]
            public static extern int cfsetspeed(byte[] termios_data, uint speed);
    
            [DllImport("libc")]
            public static extern int tcgetattr(int fd, [Out] byte[] termios_data);
    
            [DllImport("libc")]
            public static extern int tcsetattr(int fd, int optional_actions, byte[] termios_data);
    
            [DllImport("libc")]
            public static extern int open(string pathname, OpenFlags flags);
    
    
            static void Main(string[] args)
            {
                const string serialDevice = "/dev/serial/by-id/usb-ELT_SENSOR_EK100_V1.0_SN000001-if00-port0";
    
                int fileDescriptor = open(serialDevice, OpenFlags.O_RDONLY | OpenFlags.O_NONBLOCK);
                Console.WriteLine($"Libc.open returned {fileDescriptor}");
    
                byte[] termiosData = new byte[256];
    
                int result = tcgetattr(fileDescriptor, termiosData);
                Console.WriteLine($"Libc.tcgetattr returned {result}");
    
                result = cfsetspeed(termiosData, 38400);
                Console.WriteLine($"Libc.cfsetspeed returned {result}");
    
                result = tcsetattr(fileDescriptor, 0, termiosData);
                Console.WriteLine($"Libc.tcsetattr returned {result}");
            }
        }
    }
