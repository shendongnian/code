        do
        {
            DataRow row = dt.NewRow();
            string[] itemArray = line.Split('\t');
            row.ItemArray = itemArray;
            dt.Rows.Add(row);
            i = i + 1;
            line = sr.ReadLine();
        } while (!string.IsNullOrEmpty(line));
