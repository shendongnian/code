    public static bool ReplaceLine(TextBox box, int lineNumber, string text)
    {
        int first = box.GetFirstCharIndexFromLine(lineNumber);
        if (first < 0)
            return false;
        int last = box.GetFirstCharIndexFromLine(lineNumber + 1);
        box.Select(first,
            last < 0 ? int.MaxValue : last - first - Environment.NewLine.Length);
        box.SelectedText = text;
        return true;
    }
