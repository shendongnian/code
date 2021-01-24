    int propCount = 0;
    string [] propnames = typeof(classList).GetProperties().Select(x=>x.Name).ToArray();
    for (int i = 0; i < dataGridView1.Columns.Count; i++)
    {
        dataGridView1.Columns[i].HeaderText = propnames[propCount];
        propCount = i % propnames.Length;
    }
