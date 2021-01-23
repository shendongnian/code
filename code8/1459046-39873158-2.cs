    static void Main(string[] args)
        {
            string readLine;
            string[] lines = { "First line", "Second line", "Third line" };
            int linecounter = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Temp\inputtest.txt");
            System.IO.StreamWriter outputfile = new System.IO.StreamWriter(@"C:\Desktop\TestFolder\WriteLines.txt");
            while ((readLine = file.ReadLine()) != null)
            {    
                    outputfile.WriteLine(lines[linecounter] + readLine + lines[linecounter]);
                    linecounter++;
                    if (linecounter == 3)
                    {
                        linecounter = 0;
                    }
            }
            file.Close();
            outputfile.Close();
        }
