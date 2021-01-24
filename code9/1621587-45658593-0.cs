    string spaced(string text, int spacing, char space)
    {
        string spaces = "".PadLeft(spacing, space);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < text.Length; i++) sb.Append(text[i] + spaces);
        return sb.ToString().Trim(space);
    }
