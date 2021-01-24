    for (int i = 0; i < listBox1.Items.Count; i++)
    {
        TimeSpan time = TimeSpan.Parse(listBox1.Items[i].ToString());
        listBox1.Items[i] = time.TotalMinutes;
    }
