    static void ReadAndWrite()
    {
            string line;
            StreamReader sr = new StreamReader("Groceries.txt");
            StreamWriter sw = new StreamWriter("Invoice.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                sw.WriteLine(line + ", " + DateTime.Now);
                line = sr.ReadLine();
            }
            sr.Close();
            sw.Close();
    }
