    static void Main(string[] args)
    {
        string readLine;
        string[] lines = { "First line", "Second line", "Third line" };
        int linecounter = 0;
        System.IO.StreamReader file =
           new System.IO.StreamReader("c:\\inputtest.txt");
        while ((readLine = file.ReadLine()) != null)
        {
            using (System.IO.StreamWriter outputfile =
                new System.IO.StreamWriter(@"C:\Desktop\TestFolder\WriteLines.txt"))
            {
                outputfile.WriteLine(lines[linecounter] + readLine + lines[linecounter]);
                linecounter++;
                if (linecounter == 3)
                {
                    linecounter = 0;
                }
            }
        }
        file.Close();
    }
