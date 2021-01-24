    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication50
    {
        class Program
        {
            static void Main(string[] args)
            {
                IEnumerable<byte> bytes = ByteStream;
                byte[] temp = null;
                int position = 0;
                Console.WriteLine("Count = '{0}'", bytes.Count());
                do 
                {
                    temp =    bytes.Skip(position).TakeWhile(b => b != 0).ToArray();
                    position += temp.Length + 1; 
                    Console.WriteLine("position {0} : {1}", position,string.Join("",temp.Select(x => x.ToString("X2"))));
                } while (position < bytes.Count()) ;
            }
            /// <summary>
            /// A random number of null-terminated random strings of random length. The final
            /// string is just a null terminator (empty string).
            /// </summary>
            static IEnumerable<byte> ByteStream
            {
                get
                {
                    var rand = new Random();
                    for (var i = rand.Next(64, 128); i != 0; i--)
                    {
                        for (var j = rand.Next(2, 10); j != 0; j--)
                        {
                            yield return (byte)rand.Next(97, 122);
                        }
                        yield return 0;
                    }
                    yield return 0;
                }
            }
        }
    }
