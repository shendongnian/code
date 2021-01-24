    using (var writer = new StreamWriter("file.txt"))
    {
        writer.WriteLine(string.Join(",", grr[0].Keys.ToArray()));
        for (int r = 0; r < row - 1; r++)
        {
            writer.WriteLine(string.Join(",", grr[r].Values.ToArray()));
        }
    }
