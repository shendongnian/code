    using System;
    using System.Runtime.InteropServices;
    
    //Notes: remove the console references when using this in WPF)
    namespace LPTtestdrive
    {
        class LPT_X
        {
            //inpout.dll
    
            [DllImport("inpout32.dll")]
            private static extern UInt32 IsInpOutDriverOpen();
    
            [DllImport("inpout32.dll")]
            private static extern void Out32(int PortAddress, short Data);
    
            [DllImport("inpout32.dll")]
            private static extern char Inp32(int PortAddress);
    
            //inpoutx64.dll
    
            [DllImport("inpoutx64.dll", EntryPoint = "IsInpOutDriverOpen")]
            private static extern UInt32 IsInpOutDriverOpen_x64();
    
            [DllImport("inpoutx64.dll", EntryPoint = "Out32")]
            private static extern void Out32_x64(int PortAddress, short Data);
    
            [DllImport("inpoutx64.dll", EntryPoint = "Inp32")]
            private static extern char Inp32_x64(int PortAddress);
    
            private bool _X64;
            private int _PortAddress;
    
            public LPT_X(int PortAddress)
            {
                _PortAddress = PortAddress;
    
                try
                {
                    uint nResult = 0;
                    try
                    {
                        Console.WriteLine("trying to load 32bit");
                        nResult = IsInpOutDriverOpen();
                        _X64 = false;
                    }
                    catch (BadImageFormatException)
                    {
                        Console.WriteLine("failed");
                        Console.WriteLine("try 64bit");
                        nResult = IsInpOutDriverOpen_x64();
                        if (nResult != 0)
                            Console.WriteLine("success");
                        _X64 = true;
                    }
                    if (nResult == 0)
                    {
                        Console.WriteLine("failed");
                        throw new ArgumentException("Unable to open InpOut32 driver");
                    }
                }
                catch (DllNotFoundException)
                {
                    Console.WriteLine("where is it?");
                    throw new ArgumentException("Unable to find InpOut32.dll");
                }
            }
    
            public void Write(short Data)
            {
                if (_X64)
                {
                    Out32_x64(_PortAddress, Data);
                }
                else
                {
                    Out32(_PortAddress, Data);
                }
            }
    
            public byte Read()
            {
                if (_X64)
                {
                    return (byte)Inp32_x64(_PortAddress);
                }
                else
                {
                    return (byte)Inp32(_PortAddress);
                }
            }
        }
    }
