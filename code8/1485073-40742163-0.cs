    static int GetSentenceLocation()
    {
        string[] lines = new string[2];
        lines[0] = "The very first sentence. Second";
        lines[1] = "sentence (multi-line).";
        string sentence = "Second sentence (multi-line).";
        string alltext = string.Join(" ", lines);
        int index = alltext.IndexOf(sentence);
        int charCount = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            charCount += lines[i].Length;
            if (charCount > index)
                return i + 1;
        }
        return -1;
    }
