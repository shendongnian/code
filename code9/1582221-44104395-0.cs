    using System;
    using System.IO;
    using System.Text;
    
    namespace ConsoleStreamReaderTest
    {
        class Program
        {
            public static StreamReader GetYAMLAsStreamReader(string yamlfile)
            {
                byte[] data = Encoding.ASCII.GetBytes(yamlfile);
                MemoryStream stm = new MemoryStream(data, 0, data.Length);
                return new StreamReader(stm);
            }
    
    
            static void UseStreamReader1(StreamReader b)
            {
                Console.WriteLine(b.ReadLine());
            }
    
    
            static void Main(string[] args)
            {
                string s = "Hello world";
                StreamReader a = GetYAMLAsStreamReader(s);
                UseStreamReader1(a);
            }
    
    
        }
    }
