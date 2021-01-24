    public string ToCsv(SentencedModel data)
    {
        var csvLines = data.Sentences.Select(x => String.Join(",", x.Words.Select(w => EscapeForCsv(w))));
        var csv = String.Join(Environment.NewLine, csvLines);
        return csv;
    }
            
    private string EscapeForCsv(string input)
    {
        return String.Format("\"{0}\"", input.Replace("\"", "\"\"\""));
    }
