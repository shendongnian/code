    using (StreamReader reader = new StreamReader(od.Filename))
    {
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            listbox1.Items.Add(line);
        }
    }
