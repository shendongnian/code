    using (var writer = new StreamWriter("file.txt"))
    {
        var array = grr[0].Keys.ToArray();
        writer.WriteLine(array[0] + "," + array[1] + "," + array[2] + "," + array[3]);
        for (int r = 0; r < row - 1; r++)
        {
            var grrr = grr[r].Values.ToArray();
            writer.WriteLine(grrr[0] + "," + grrr[1] + "," + grrr[2] + "," + grrr[3]);
        }
    }
