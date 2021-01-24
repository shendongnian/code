    private void SplitString(WWW www)
    {
        // Use regular matching expression.
        MatchCollection result = new Regex(@"[0-9]{1,};").Matches(www?.text ?? string.Empty);
        // Time Organizational. (if you used a StringBuilder it could be a touch faster)
        string time = string.Empty;
        foreach (var item in result) // Loop through all results no matter how many.
            time += time + item.Value.TrimEnd(';') + ":";
        time = time.TrimEnd(':'); // Get rid of the last unnecessary colon.
        // Unsure what this does, but your original code contained it.
        if(time.Length >= 10)
            call(time);
    }
