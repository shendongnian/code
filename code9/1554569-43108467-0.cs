    private const string DefaultSaveFile = @"C:\temp\testfile.txt";
    private void CopyUniqueClipboardTextToFile(string filePath = null, 
        bool updateListbox = true)
    {
        // Use global default file if nothing was passed
        if (filePath == null) filePath = DefaultSaveFile;
        // Ensure our files exist
        if (!File.Exists(filePath)) File.CreateText(filePath);
        string fileContents = File.ReadAllText(filePath);
        string clipboardText = Clipboard.GetText();
        // Update the file with any new clipboard text
        if (Clipboard.ContainsText() && !fileContents.Contains(clipboardText))
        {
            var text = $"{Environment.NewLine}{clipboardText}¢";
            File.AppendAllText(filePath, text);
        }
        // Re-read the new file into a list and remove blank lines
        List<string> distinctFileContents = File.ReadAllLines(filePath)
            .ToList()
            .Where(item => item != string.Empty)
            .Distinct()
            .ToList();
        // Update listbox if necessary
        if (updateListbox)
        {
            listBox1.BeginUpdate();
            listBox1.DataSource = distinctFileContents;
            listBox1.EndUpdate();
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        CopyUniqueClipboardTextToFile();
    }
