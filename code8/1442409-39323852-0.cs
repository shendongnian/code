    public void CleanFile(string[] lines) {
        var oddLines = new HashSet<String>();
        for(int i = 1; i <= lines.Length; i += 2) {
            if(!oddLines.Add(lines[i]) {
                lines[i] = //whatever your rewriting it with
            }
        }
    }
