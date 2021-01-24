        public string PathCombine(string path1, string path2)
        {
            if (path2.Contains("..")) return null;
            if (path2.Contains(":")) return null;
            string result = Path.Combine(path1, path2);
            return (result.Equals(path2) ? null : result);
        }
