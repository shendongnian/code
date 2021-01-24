    private void button2_Click(object sender, EventArgs e)
    {
        DateTime start = new DateTime(2015,01,26);
        DateTime end = new DateTime(2015,01,27);
        var oldLines = System.IO.File.ReadAllLines(txtFileName.Text);
        var newLines = oldLines
            .Select(line => { line, date = DateTime.Parse(line.Split(',')[1]) })
            .Where(line => line.date > start and line.date < end)
            .Select(line => line.line)
            .ToArray();
        System.IO.File.WriteAllLines(txtFileName.Text, newLines);
    }
