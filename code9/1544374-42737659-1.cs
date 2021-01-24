    public string ToCsv(SentencedModel data)
    {
        var csvLines = data.Select(x => String.Join(",", x));
        var csv = String.Join(Environment.NewLine, csvLines);
        return csv;
    }
