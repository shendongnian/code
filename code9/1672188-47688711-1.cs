            string folder = @"F:\\WorkingCopy\\files\\";
            var files = System.IO.Directory.GetFiles(folder, filename + ".*");
            if (files.Any())
            {
                string ext = System.IO.Path.GetExtension(files.First()).Substring(1);
            }
