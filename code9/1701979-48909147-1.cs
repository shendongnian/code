        public static string CreateDirectory(string path)
        {
            string createPath = GetUniquePath(path);
            Directory.CreateDirectory(createPath);
            return createPath;
        }
        private static string GetUniquePath(string path)
        {
            string result = path;
            int i = 1;
            while (Directory.Exists(result))
                result = $"{path} ({i++})";
            return result;
        }
