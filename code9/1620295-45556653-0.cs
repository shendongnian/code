        public static void CountFiles(string path)
        {
            int xFileCount = 0;
            int yFileCount = 0;
            int zFileCount = 0;
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
            
            foreach(string file in files)
            {
                if (Path.GetDirectoryName(file) == "FOLDER_X")
                    xFileCount++;
                if (Path.GetDirectoryName(file) == "FOLDER_Y")
                    yFileCount++;
                if (Path.GetDirectoryName(file) == "FOLDER_Z")
                    zFileCount++;
            }
            Console.WriteLine("X Files : {0}", xFileCount);
            Console.WriteLine("Y Files : {0}", yFileCount);
            Console.WriteLine("Z Files : {0}", zFileCount);
        }
