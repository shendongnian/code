        public static string GetFilePathConcenated(string folderPath)
        {
            if (Directory.Exists(folderPath){
                string[] fileList = Directory.GetFiles(folderPath);
                return string.Join(",", fileList).TrimEnd(',');
            }
            return string.Empty;
        }
