        int currentLine = 1;
        string pick = null;
        foreach (string line in File.ReadLines("C:\\First Names.txt"))
        {
            if (r.Next(currentLine) == 0)
            {
                pick = line;
            }
            ++currentLine;
            textBox1.Text = pick;
        }       
        currentLine=0;pick=0;
        foreach (string line in File.ReadLines("C:\\Last Names.txt"))
            {
                if (r.Next(currentLine) == 0)
                {
                    pick = line;
                }
                ++currentLine;
                textBox2.Text = pick;
            }
        }`
