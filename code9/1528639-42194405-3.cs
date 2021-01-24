    private void SearchforFrac()
    {
        string pattern = @"(\d+)(/)(\d+)";
        this.labelCurrentOperation.Text = System.Text.RegularExpressions.Regex.Replace(this.labelCurrentOperation.Text, pattern, evaluator);
    }
    private string evaluator(System.Text.RegularExpressions.Match match)
    {
        decimal numerator = int.Parse(match.Groups[1].Value);
        decimal denominator = int.Parse(match.Groups[3].Value);
        return (numerator / denominator).ToString();
    }
