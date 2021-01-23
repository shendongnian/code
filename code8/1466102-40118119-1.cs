    var root = (JContainer)JToken.Parse(jsonString);
    var nameRegex = new Regex(".*pass.*w.*r.*d.*", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
    var query = root.DescendantsAndSelf()
        .OfType<JProperty>()
        .Where(p => nameRegex.IsMatch(p.Name));
    query.RemoveFromLowestPossibleParent();
