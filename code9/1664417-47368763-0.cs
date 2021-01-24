    {
            string filename = "text.txt"; //setting file name
            string resouceFolderName = "Resources";
            //Destination Path
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //CurrentDirectory return src\\Bin\\Debug so extracting src root folder path
            string parentFolderPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName;
            //combining parent folder path with resource folder name
            string folderPath = Path.Combine(parentFolderPath, resouceFolderName); // <--- need to use Resources folder in the project folder here
            //Checking if exist or not
            if (!Directory.Exists(folderPath) || !Directory.Exists(path))
            {
                Console.WriteLine("Error");
                return;
            }
            //filename and location combining to be copied
            string source = Path.Combine(folderPath, filename);
            string destination = Path.Combine(path, filename);
            if (true)
            {
                File.Copy(source, destination, true); //copying
            }
        }
