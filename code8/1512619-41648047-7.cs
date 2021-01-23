    public void AppendCsvToDataList(string file, List<Data3> list)
    {
        if (File.Exists(file))
        {
            var lines = File.ReadAllLines(file);
            for (int l = 1; l < lines.Length; l++)
            {
                var pieces = lines[l].Split(',');
                list.Add(new Data3(Convert.ToInt32(pieces[1]),
                                   Convert.ToDouble(pieces[0]), pieces[2]));
            }
        }
    }
