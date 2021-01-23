    public string RemoveAccent(string name)
    {
        string normalizedName = name.Normalize(NormalizationForm.FormD);
        string pattern = @"\p{M}";
        string nameWithoutAccent = Regex.Replace(normalizedName, pattern, "");
        return nameWithoutAccent;
    }
