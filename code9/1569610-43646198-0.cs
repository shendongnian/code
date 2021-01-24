    private bool CelularesValidation(string c1, string c2, string c3, string c4)
    {
        return new[] { c1, c2, c3, c4 }.Where(c => !string.IsNullOrEmpty(c))
            .Distinct().Count() == 4;
    }
