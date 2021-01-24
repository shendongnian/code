    foreach (string line in lines)
    {
         string[] _line = line.Split('|');
         string value1 = _line[0];
         string value2 = _line[1];
         ...
         dataGridView1.Rows.Add(value1 , value2 , ...);
    }
