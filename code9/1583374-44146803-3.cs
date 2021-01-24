    private void ReadInTimeSheet()
    {
        var fileLines = File.ReadAllLines(@"C:\filepath\MyTimeSheet.txt"))
        for (int i = 0; i + 4 < fileLines.Length; i += 5)
        {
            lvTimeSheet.Items.Add(
                new ListViewItem(new[]
                {
                    fileLines[i],
                    fileLines[i + 1],
                    fileLines[i + 2],
                    fileLines[i + 3],
                    fileLines[i + 4]
                }));
        }
        // Resize the columns
        for (int i = 0; i < lvTimeSheet.Columns.Count; i++)
        {
            lvTimeSheet.Columns[i].Width = -2;
        }
    }
