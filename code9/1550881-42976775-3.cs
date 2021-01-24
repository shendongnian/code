    List<TableEntry[]> desiredFormat = new List<TableEntry[]>();
    int pages = entries.Count() / 8;
    for (int page = 0; page < pages; page++)
    {
        TableEntry[] row = entries.OrderBy(e => e.pkiNotesLineEntriesId).Skip(page * 8).Take(8).ToArray();
        desiredFormat.Add(row);
    }
