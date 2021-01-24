    static void Main(string[] args)
        {
            var files = GetFileNames("D:\\Documents","docx");
        }
        public static string[] GetFileNames(string dirPath,string extention)
        {
            string[] files = { };
            if (Directory.GetFiles(dirPath, "*." + extention).Length > 0)
            {
                files = Directory.GetFiles(dirPath, "*." + extention);
                List<string> tempList = new List<string>();
                foreach (string file in files)
                {
                    tempList.Add(file.Substring(file.LastIndexOf("\\") + 1, file.Length - file.LastIndexOf("\\") - 1));
                }
                files = tempList.ToArray();
            }
            return files;
        }
