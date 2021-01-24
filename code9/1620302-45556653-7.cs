        public static void CountFiles(string path)
        {
            int xFileCount = 0;
            int yFileCount = 0;
            int zFileCount = 0;
            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
            foreach(string file in files)
            {
                string folder = new DirectoryInfo(Path.GetDirectoryName(file)).Name;
                if (folder == "FOLDER_X")
                    xFileCount++;
                if (folder == "FOLDER_Y")
                    yFileCount++;
                if (folder == "FOLDER_Z")
                    zFileCount++;
            }
            Console.WriteLine("X Files : {0}", xFileCount);
            Console.WriteLine("Y Files : {0}", yFileCount);
            Console.WriteLine("Z Files : {0}", zFileCount);
        }
