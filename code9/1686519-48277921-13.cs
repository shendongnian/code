    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace ConsoleApp1
    {
        class Program
        {
            const string dllname = "Dll1.dll";
    
            [DllImport(dllname, CallingConvention = CallingConvention.StdCall)]
            static extern uint mfcsez_initialisation(ushort serial);
    
            [DllImport(dllname, CallingConvention = CallingConvention.StdCall)]
            static extern byte mfcs_get_serial(uint handle, out ushort serial);
    
            [DllImport(dllname, CallingConvention = CallingConvention.StdCall)]
            static extern byte mfcs_read_chan(uint handle, byte canal, out float pressure, out ushort chrono);
    
            static void Main(string[] args)
            {
                uint retval1 = mfcsez_initialisation(11);
                Console.WriteLine("return value = " + retval1.ToString());
                Console.WriteLine();
    
                ushort serial;
                byte retval2 = mfcs_get_serial(12, out serial);
                Console.WriteLine("serial = " + serial.ToString());
                Console.WriteLine("return value = " + retval2.ToString());
                Console.WriteLine();
    
                float pressure;
                ushort chrono;
                byte retval3 = mfcs_read_chan(13, 14, out pressure, out chrono);
                Console.WriteLine("pressure = " + pressure.ToString());
                Console.WriteLine("chrono = " + chrono.ToString());
                Console.WriteLine("return value = " + retval3.ToString());
    
                Console.ReadLine();
            }
        }
    }
