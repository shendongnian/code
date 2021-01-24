        public static DateTime GetLastModDate(string FilePath) {
            DateTime retDateTime;
            if (File.Exists(FilePath)) { retDateTime = File.GetLastWriteTime(FilePath); } 
            else { retDateTime = new DateTime(0);  }
            return retDateTime;
        }
