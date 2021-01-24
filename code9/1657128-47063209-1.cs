    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport(@"Win32Project1.dll", CallingConvention=CallingConvention.Cdecl)]
            public static unsafe extern int fillArray(float** floatArray, int* count);
    
            static void Main(string[] args)
            {
                unsafe
                {
                    float* floatArray;
                    int count;
                    if (fillArray(&floatArray, &count) == 0)
                        for (int i = 0; i < count; i++)
                            Console.WriteLine(floatArray[i]);
                }
            }
        }
    }
