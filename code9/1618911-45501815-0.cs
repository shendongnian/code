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
            }
            return files;
        }
