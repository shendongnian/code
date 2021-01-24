    class FileEntry
    {
        public string Website { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public static FileEntry Parse(string fileLine)
        {
            var result = new FileEntry();
            if (string.IsNullOrWhiteSpace(fileLine)) return result;
            var lineParts = fileLine.Split('=');
            result.Website = lineParts[0];
            if (lineParts.Length > 1) result.UserName = lineParts[1];
            if (lineParts.Length > 2) result.Password = lineParts[2];
            return result;
        }
    }
