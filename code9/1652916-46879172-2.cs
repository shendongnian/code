     static void Main(string[] args)
        {
            string lin = @"C:\Users\user\Desktop\New folder (7)\flltest.txt";
            using (StreamReader fs = new StreamReader(lin, Encoding.GetEncoding("windows-1255")))
                while (true)
                {
                    string temp = fs.ReadLine();
                    Char delimiter = ',';
                    String[] substrings = temp.Split(delimiter);
                    foreach (var substring in substrings)
                        Console.WriteLine(String.Join(",",substring,48));
                    if (temp == null) break;
                    {
                        Console.WriteLine("end");
                        Console.ReadLine();
                    }
                }
        }
