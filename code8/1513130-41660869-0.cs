    int p = 62;
    foreach (string line in File.ReadLines("mac.txt"))
    {
        Console.WriteLine(line);
        var lb = new Label()
        {
           Text = line,
           Location = new Point(58, p)
        };
        panel1.Controls.Add(lb);
        p = p + 30;
    }
