    InstalledFontCollection fontCol = new InstalledFontCollection();
    for (int x = 0; x <= fontCol.Families.Length-1;x++ )
    {
        listBox1.Items.Add(fontCol.Families[x].Name);
    }
