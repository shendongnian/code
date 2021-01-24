        string sourcePath = @"c:\Users\Admin\Desktop\tmp\test1\";
        string destinationPath = @"c:\Users\Admin\Desktop\tmp\test2\";
        string[] files = Directory.GetFiles(sourcePath);
        foreach (string file in files)
        {
            string fname = file.Substring(sourcePath.Length);
            string dest = Path.Combine(destinationPath, fname);
            if(File.Exists(dest))
            {
                var existingFiles = Directory.GetFiles(destinationPath);
                var fileNum = existingFiles.Select(x => x.Substring(destinationPath.Length + 1).StartsWith(fname)).Count();
                dest = Path.Combine(destinationPath,Path.GetFileNameWithoutExtension(dest)+ " copy" + (fileNum > 1 ? " (" + (fileNum-1)+")" : "") + Path.GetExtension(dest));
                File.Copy(file, dest);
            }
            else
            {
                File.Copy(file, dest);
            }
        }
