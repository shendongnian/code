    // Store the list at the class level so other methods can access it:
    private List<FileEntry> fileEntries;
    private void Form1_Load(object sender, EventArgs e)
    {
        var filePath = @"C:\Users\snogueir\Desktop\Coding\sandbox\keychainarray.txt";
        fileEntries = File.ReadAllLines(filePath).Select(FileEntry.Parse).ToList();
        textboxWebsite.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        textboxWebsite.AutoCompleteSource = AutoCompleteSource.CustomSource;
        var autoComplete = new AutoCompleteStringCollection();
        autoComplete.AddRange(fileEntries.Select(fe => fe.Website).ToArray());
        textboxWebsite.AutoCompleteCustomSource = autoComplete;
    }
