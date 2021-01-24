        public static string CreateDirectory(string path, int suffix = 0)
        {
            string directoryPath = DirectoryPath(path, suffix);
            if (!CreateDirectory(directoryPath))
                return CreateDirectory(path, i + 1);
            return directoryPath;
        }
        private static bool CreateDirectory(string path)
        {
            if (Directory.Exists(path))
                return false;
            Directory.CreateDirectory(path);
            return true;
        }
        private static string DirectoryPath(string path, int suffix)
        {
            return $"{path}{(suffix > 0 ? $" ({suffix})" : string.Empty)}";
        }
