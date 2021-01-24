        public long GetDirSize(DirectoryInfo dir, bool includeSubfolders)
        {
            if (!dir.Exists) return 0;
            return dir.GetFiles("*.*", includeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Sum(x => x.Length);
        }
