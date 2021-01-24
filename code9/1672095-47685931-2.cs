    public class FileGroupItem
    {
        public string DatePart { get; set; }
        public string GroupName { get; set; }
        public string FilePath { get; set; }
        public static FileGroupItem Parse(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) return null;
            // Split the file name on the '.' character to get the group and date parts
            var fileParts = Path.GetFileName(filePath).Split('.');
            if (fileParts.Length != 2) return null;
            return new FileGroupItem
            {
                GroupName = fileParts[0],
                DatePart = fileParts[1],
                FilePath = filePath
            };
        }            
    }
