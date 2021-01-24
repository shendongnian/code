    using System;
    using System.IO;
    
    namespace SharpTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string path = "XXX/test.csv";
                string savePath = "XXX/test2.txt";          
                using(StreamReader sr = new StreamReader(path))
                {
                    string headerLine = sr.ReadLine();
                    string[] headers = headerLine.Split(';');
                    using(StreamWriter sw = new StreamWriter(savePath))
                    {
                        while (true)
                        {
                            string line = sr.ReadLine();
                            if (line == null) return;
                            string[] ss = line.Split(';');
                            if (ss.Length != headers.Length) continue;
                            for (int i = 1; i < headers.Length; i++)
                            {
                                sw.WriteLine(ss[0] + ";" + headers[i] + ";" + ss[i]);
                            }
                        }
                    }
                }
            }
        }
    }
