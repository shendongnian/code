    void FindAndReplace(List<string> lines, string toFind, string toReplace) {
        for(int i = 0; i < lines.Count ; i++) {
            lines[i] = Regex.Replace(lines[i], $"\b{toFind}\b", toReplace);
        }
    }
