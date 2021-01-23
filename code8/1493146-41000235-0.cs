    while ((line = file.ReadLine()) != null)
    {
        if (line.Length > 0)
        {
            comboBox1.Items.Add(line);
        }
    }
