    string dirScanner = @"\\neen-dsk-010\testunix24$\data\mvp\Scripts\Scanner\";
    if (string.IsNullOrWhiteSpace(txtSerialSearch.Text) || string.IsNullOrWhiteSpace(txtSID.Text))
        return;
    string[] allFiles = Directory.GetFiles(dirScanner, "*.txt");
    foreach (string file in allFiles)
    {
        string[] lines = File.ReadAllLines(file);
        string firstOccurrence = lines.FirstOrDefault(l => l.Contains(txtSerialSearch.Text));
        if (firstOccurrence != null)
        {
            lblOutput.Text = firstOccurrence;
            break;
        }
    }
