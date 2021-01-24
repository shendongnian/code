    public IEnumerable<string> JoinWords(IEnumerable<(string text, string script)> words)
    {
        using (var enumerator = words.GetEnumerator())
        {
            if (!enumerator.MoveNext())
                yield break;
            var (text, script) = enumerator.Current;
            var stringBuilder = new StringBuilder(text);
            while (enumerator.MoveNext())
            {
                var (nextText, nextScript) = enumerator.Current;
                if (script == string.Empty)
                {
                    stringBuilder.Append(nextText);
                    script = nextScript;
                }
                else if (nextScript != string.Empty && nextScript != script)
                {
                    yield return stringBuilder.ToString();
                    stringBuilder = new StringBuilder(nextText);
                    script = nextScript;
                }
                else
                    stringBuilder.Append(nextText);
            }
            yield return stringBuilder.ToString();
        }
    }
