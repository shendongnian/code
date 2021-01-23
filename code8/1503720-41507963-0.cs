    using System;
    using System.Runtime.InteropServices;
    using static System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Doing stuff");
            try
            {
                Marshal.StructureToPtr(1, new IntPtr(1), true);
            }
            catch (AccessViolationException)
            {
                WriteLine("Should not reach this.");
            }
            finally
            {
                WriteLine("Should not reach even this.");
            }
            WriteLine("Waiting");
            ReadKey();
        }
    }
