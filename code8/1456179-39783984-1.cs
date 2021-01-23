    string dirScanner = @"\\mypath\";
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
