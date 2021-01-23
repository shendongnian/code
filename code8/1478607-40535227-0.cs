    private string ExtractDateFromFilename(string filename) {
            var m = Regex.Match(filename, @"\\\d{6}");
            if (!string.IsNullOrEmpty(m.Value))
                return m.Value.Substring(1);
            return "";
        } 
