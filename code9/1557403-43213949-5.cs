    /// <summary>
    /// Returns a string with newText inserted into parentText
    /// </summary>
    /// <param name="newText">The new text to insert</param>
    /// <param name="parentText">The parent text to insert into</param>
    /// <returns>The parent string with the newText inserted</returns>
    private string GetInsertedText(string newText, string parentText)
    {
        var newParentText = parentText;
        var matches = Regex.Matches(newParentText, "}\\s}");
        // Replace from the last occurrence, since each insert will 
        // change the length of our string and alter the insert location
        for(int index = matches.Count - 1; index >= 0; index--)
        {
            var match = matches[index];
            newParentText = newParentText.Substring(0, match.Index + 1) + 
                Environment.NewLine + newText +
                newParentText.Substring(match.Index + 1);
        }
        return newParentText;
    }
