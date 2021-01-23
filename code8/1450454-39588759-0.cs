    string a = "**MustbeReplaced**asdgasfsff**MustbeReplaced**asdfafasfsa";
    int matchCount = 0, index = 0;
    while ((index = a.IndexOf("MustbeReplaced", index, StringComparison.Ordinal)) >= 0)
    {
        a = a.Remove(index, "MustbeReplaced".Length).Insert(index, "Replaced" + ++matchCount);
    }
