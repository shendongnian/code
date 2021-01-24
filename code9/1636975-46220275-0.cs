    public static string ReplacePlaceHolder(string value)
    {
        var HTMLToConvert = HttpUtility.UrlDecode(value)       
        return HTMLToConvert.Replace("<span class=\"sample_class\" id=\"sample_id\"></span>", GenerateHTMLTable());
    }
