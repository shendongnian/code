    var input = @"addresses { 1.1.1.1; 2.2.2.2; 3.3.3.3; }";
    var regex = new Regex(@"[^{]+{([^}]+)}", RegexOptions.Multiline);
    var addresses = regex.Match(input).Groups[1].Value
        .Split(';')
        .Select(s => s.Trim())
        .Where(s => !String.IsNullOrWhiteSpace(s))
        .ToList();
