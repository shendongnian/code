    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication33
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                string ip1 = "123.45.67.5";
                string ip2 = "123.45.67.15";
                string mask = GetMask(ip1, ip2);
     
            }
            static string GetMask(string ip1, string ip2)
            {
                int[] ip1Array = ip1.Split(new char[] { '.' }).Select(x => int.Parse(x)).ToArray();
                int[] ip2Array = ip2.Split(new char[] { '.' }).Select(x => int.Parse(x)).ToArray();
                int[] mask = new int[] { 0, 0, 0, 0 };
                Boolean done = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 7; j >= 0; j--)
                    {
                        if ((ip1Array[i] & (1 << j)) == (ip2Array[i] & (1 << j)))
                        {
                            mask[i] |= (1 << j);
                        }
                        else
                        {
                            done = true;
                            break;
                        }
                    }
                    if (done) break;
                }
                return string.Join(".", mask);
            }
        }
        
    }
