    DataTable source = new DataTable();
    
    foreach (string sample in GridSource.SampleName)
    {
        DataRow temp = source.NewRow();
        SampleDictionaries sd = GridSource.Data.Where(x => GridSource.Data.IndexOf(x) == GridSource.SampleName.IndexOf(sample)).First();
        temp.ItemArray = new object[]{sample, "Average"}.Concat(sd.Avg.Values.ToArray());
        source.Rows.Add(temp);
        temp = source.NewRow();
        temp.ItemArray = new object[]{"", "Std. Deviation".Concat(sd.StdDev.Values.ToArray());
    }
