    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace BackupMBR
    {
        class Program
        {
    
            [DllImport("kernel32")]
            private static extern IntPtr CreateFile(
               string lpFileName,
               uint dwDesiredAccess,
               uint dwShareMode,
               IntPtr lpSecurityAttributes,
               uint dwCreationDisposition,
               uint dwFlagsAndAttributes,
               IntPtr hTemplateFile);
    
            static void Main(string[] args)
            {
                IntPtr handle = CreateFile(
                    @"\\.\PHYSICALDRIVE0",
                    0x80000000, 
                    1, 
                    IntPtr.Zero, 
                    3, 
                    0, 
                    IntPtr.Zero
               );
                using (FileStream disk = new FileStream(handle, FileAccess.Read))
                {
                    byte[] mbrData = new byte[512];
                    Console.WriteLine("Starting MBR Backup...");
                    try
                    {
                        disk.Read(mbrData, 0, mbrData.Length);
                        FileStream mbrSave = new FileStream("mbr.img", FileMode.Create);
                        mbrSave.Write(mbrData, 0, mbrData.Length);
                        Console.WriteLine("MBR Backuped to mymbr.img success!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
    
                Console.ReadKey();
    
            }
        }
    }
