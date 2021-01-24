    if (filesAreSame)
    {
        MessageBox.Show("They match!");
    }
    else
    {
        var commonItems = oldFileTxt.Intersect(newFileTxt, StringComparer.OrdinalIgnoreCase);
        var uniqueOldItems = oldFileTxt.Except(commonItems, StringComparer.OrdinalIgnoreCase);
        var uniqueNewItems = newFileTxt.Except(commonItems, StringComparer.OrdinalIgnoreCase);
        var notEqualsFileText = new StringBuilder();
        if (uniqueOldItems.Any())
        {
            notEqualsFileText.AppendLine(
                $"Entries in {oldFilePath} that are not in {newFilePath}:");
            notEqualsFileText.AppendLine(string.Join(Environment.NewLine, uniqueOldItems));
        }
        if (uniqueNewItems.Any())
        {
            notEqualsFileText.AppendLine(
                $"Entries in {newFilePath} that are not in {oldFilePath}:");
            notEqualsFileText.AppendLine(string.Join(Environment.NewLine, uniqueNewItems));
        }
        File.WriteAllText(notEqualFilePath, notEqualsFileText.ToString());
        var equalsFileText = new StringBuilder();
        if (commonItems.Any())
        {
            equalsFileText.AppendLine(
                $"Entries that are common in both {newFilePath} and {oldFilePath}:");
            equalsFileText.AppendLine(string.Join(Environment.NewLine, commonItems));
        }
        else
        {
            equalsFileText.AppendLine(
                $"There are no common entries in both {newFilePath} and {oldFilePath}.");
        }
        File.WriteAllText(equalFilePath, equalsFileText.ToString());
        MessageBox.Show("The files are not the same! Please look at 'Not Equal.txt' to see the difference. Look at 'Equal.txt' to see what is the same at this time.");
    }
