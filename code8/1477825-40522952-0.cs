    private void button3_Click(object sender, EventArgs e)
    {
        //first we read all lines into a list
        List<string> allLines = new List<string>();
        using (var reader = new System.IO.StreamReader(@"D:\Sample.txt"))
            while (reader.Peek() >= 0)
                allLines.Add(reader.ReadLine());
        //if there are more than 1 lines...
        if (allLines.Count > 1)
        {
            //copy first line to end
            allLines.Add(allLines.First());
            //remove first line
            allLines.RemoveAt(0);
            //finally we write everything back in the same file
            using (var writer = new System.IO.StreamWriter(@"D:\Sample.txt"))
                foreach (var line in allLines)
                    writer.WriteLine(line);
        }
    }
