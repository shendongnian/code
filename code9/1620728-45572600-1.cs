    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication72
    {
        class Program
        {
            static string buffer = "";
            static void Main(string[] args)
            {
     
            }
            static void AddToBuffer(byte[] rxData)
            {
                buffer += Encoding.UTF8.GetString(rxData);
            }
            static string ReadLine()
            {
                int returnIndex = buffer.IndexOf("\n");
                if (returnIndex >= 0)
                {
                    string line = buffer.Substring(0, returnIndex);
                    buffer = buffer.Remove(0, returnIndex + 1);
                    return line;
                }
                else
                {
                    return "";
                }
            }
        }
    }
