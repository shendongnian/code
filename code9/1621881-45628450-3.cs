    public IEnumerable<(string text, string script)> SplitIntoWords(string text)
    {
        if (text.Length == 0)
            yield break;
        var script = scripts.GetScript(text[0]);
        var start = 0;
        for (var i = 1; i < text.Length - 1; i += 1)
        {
            var nextScript = scripts.GetScript(text[i]);
            if (nextScript != script)
            {
                yield return (text.Substring(start, i - start), script);
                start = i;
                script = nextScript;
            }
        }
        if (start < text.Length)
            yield return (text.Substring(start, text.Length - start), script);
    }
