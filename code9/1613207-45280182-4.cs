    private void GenerateColumnsAndData(Language language)
    {
            var countIds = language.Entry.LanguageEntry.Count;
            dataGridView1.ColumnCount = countIds + 1;
            dataGridView1.Columns[0].Name = "Key";
            for (int i = 0; i < language.Entry.LanguageEntry.Count; i++)
			{
                dataGridView1.Columns[i+1].Name = language.Entry.LanguageEntry[i].ID;
			}
            ArrayList row = new ArrayList();
            row.Add(language.Entry.Key);
            foreach (var item in language.Entry.LanguageEntry)
	        {
                row.Add(item.Value);
	        }
            dataGridView1.Rows.Add(row.ToArray());
    }
