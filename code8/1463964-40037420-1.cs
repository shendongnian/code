    using System;
    using System.Runtime.InteropServices;
    
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
            private int DataAddress;
            private int StatusAddress;
            private int ControlAddress;
    
            public LPT_X(int PortAddress)
            {
                DataAddress = PortAddress;
                StatusAddress = (int)(DataAddress + 1);
                ControlAddress = (int)(DataAddress + 2);
    
                //now the code tries to determine if it should use inpout32.dll or inpoutx64.dll
                uint nResult = 0;
    
                try
                {
                    Console.WriteLine("trying 32 bits");
                    nResult = IsInpOutDriverOpen();
                    if (nResult != 0)
                    {
                        Console.WriteLine("using 32 bits");
                        return;
                    }
                }
                catch (BadImageFormatException)
                {
                    Console.WriteLine("32 bits failed");
                }
                catch (DllNotFoundException)
                {
                    throw new ArgumentException("Unable to find InpOut32.dll");
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
    
                try
                {
                    Console.WriteLine("trying 64 bits");
                    nResult = IsInpOutDriverOpen_x64();
                    if (nResult != 0)
                    {
                        Console.WriteLine("using 64 bits");
                        _X64 = true;
                        return;
                    }
                }
                catch (BadImageFormatException)
                {
                    Console.WriteLine("64 bits failed");
                }
                catch (DllNotFoundException)
                {
                    throw new ArgumentException("Unable to find InpOutx64.dll");
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
    
                throw new ArgumentException("Unable to open either inpout32 and inpoutx64");
            }
    
            public void WriteData(short Data)
            {
                if (_X64)
                {
                    Out32_x64(DataAddress, Data);
                }
                else
                {
                    Out32(DataAddress, Data);
                }
            }
    
            public void WriteControl(short Data)
            {
                if (_X64)
                {
                    Out32_x64(ControlAddress, Data);
                }
                else
                {
                    Out32(ControlAddress, Data);
                }
            }
            public byte ReadData()
            {
                if (_X64)
                {
                    return (byte)Inp32_x64(DataAddress);
                }
                else
                {
                    return (byte)Inp32(DataAddress);
                }
            }
    
            public byte ReadControl()
            {
                if (_X64)
                {
                    return (byte)Inp32_x64(ControlAddress);
                }
                else
                {
                    return (byte)Inp32(ControlAddress);
                }
            }
    
            public byte ReadStatus()
            {
                if (_X64)
                {
                    return (byte)Inp32_x64(StatusAddress);
                }
                else
                {
                    return (byte)Inp32(StatusAddress);
                }
            }
        }
    }
