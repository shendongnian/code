        public void Save(string filename, string data)
        {
            var docPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            docPath = Path.Combine(docPath, "My Documents");
            var filepath = Path.Combine(docPath, filename);
            System.IO.File.WriteAllText(filepath, data);
        }
