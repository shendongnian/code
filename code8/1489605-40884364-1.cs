    String pattern = "md5: \[([a-zA-Z0-9]*)\]";
    Regex reg = new Regex(pattern);
    Match m = reg.Match(content);
    if(m.Success) {
        Group g = m.Groups[1]; // This should be the hash
        String hash = g.Value;
    }
