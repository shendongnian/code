    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
    
            [DllImport(@"testdll.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern ulong makeArray(byte[] sendArr, ulong sendArrLen, [Out] byte[] recvArr, ref ulong recvArrLen);
    
            static byte[] MakeArray()
            {
                byte[] arrSend = new byte[] { 0x00, 0x12, 0x34 };
                ulong nRecvArrLen = 0;
                ulong ret = 0;
                byte[] arrRecv = new byte[3]; // assign in c++ dll function (variable size)
    
                try
                {
                    if ((ret = makeArray(arrSend, (ulong)arrSend.Length, arrRecv, ref nRecvArrLen)) > 0)
                    {
                        if(arrRecv != null)
                            Console.WriteLine("nRecvArrLen2============>" + arrRecv.Length);
                        
    
                        return arrRecv;
                    }
                   
                }
                catch (DllNotFoundException dne)
                {
                    Console.WriteLine("============> dll not found....");
                }
                
    
                return null;
            }
            
    
            static void Main(string[] args)
            {
                byte[] retbytes = MakeArray();
    
                if (retbytes != null)
                {
                    Console.WriteLine("=====LEN=======>" + retbytes.Length);
    
                    for (int i = 0; i < retbytes.Length; i++)
                        Console.WriteLine("====ITEM========>" + retbytes[i]);
                }
                else
                    Console.WriteLine("=====NULL=======>");
    
                
            }
        }
    }
