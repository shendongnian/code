	public void ExtractAllEmails()
    {
        string datafrmAsc = File.ReadAllText(YourASCFile); //read File 
        Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
        MatchCollection emailMatches = emailRegex.Matches(datafrmAsc);
        StringBuilder sb = new StringBuilder();
        foreach (Match emailMatch in emailMatches)
        {
            sb.AppendLine(emailMatch.Value);
        }
        File.WriteAllText(SomeTxtFile, sb.ToString());
    }
