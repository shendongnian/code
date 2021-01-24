    private const string DefaultSaveFile = @"C:\temp\testfile.txt";
    private void CopyUniqueClipboardTextToFile(string filePath = null,
        bool updateListbox = true)
    {
        // Use global default file if nothing was passed
        if (filePath == null) filePath = DefaultSaveFile;
        // Ensure our files exist
        if (!File.Exists(filePath)) File.CreateText(filePath).Close();
        string fileContents = File.ReadAllText(filePath);
        string clipboardText = Clipboard.GetText();
        // Update the file with any new clipboard text
        if (Clipboard.ContainsText() && !fileContents.Contains(clipboardText))
        {
            // Save the lines to our file, with a '¢' character at the end
            File.AppendAllText(filePath, $"{Environment.NewLine}{clipboardText}¢");
        }
        // Re-read the new file into a single string
        string entireFileAsOneLine = string.Join(" ", 
            File.ReadAllLines(filePath).Distinct().ToList());
        // Now split that string on the '¢' character
        string[] listItems = entireFileAsOneLine.Split('¢');
        // Update listbox if necessary
        if (updateListbox)
        {
            listBox1.BeginUpdate();
            listBox1.DataSource = listItems;
            listBox1.EndUpdate();
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        CopyUniqueClipboardTextToFile();
    }
