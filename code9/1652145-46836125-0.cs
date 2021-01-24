        readListbox.Text = Open.FileName;
        string[] lines = System.IO.File.ReadAllLines(Open.FileName);
        decimal[] values = lines.Select(x => decimal.Parse(x)).ToArray();
        labelHigh.Text = values.Max().ToString();
        labelMin.Text = values.Min().ToString();
        labelAvg.Text = values.Average().ToString();        
        readListbox.Items.AddRange(lines);
