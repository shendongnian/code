    private void SearchforFrac()
    {
        string pattern = @"(\d+)(/)(\d+)";
        labelCurrentOperation.Text = System.Text.RegularExpressions.Regex.Replace(labelCurrentOperation.Text, pattern,delegate (System.Text.RegularExpressions.Match match)
        {
            decimal numerator = int.Parse(match.Groups[1].Value);
            decimal denominator = int.Parse(match.Groups[3].Value);
            return (numerator / denominator).ToString();
        });
    }
