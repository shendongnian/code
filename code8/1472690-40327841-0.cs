            string PathFiletoCopy = @"C:\temp\out.csv";
            string PathToCopy = System.IO.Path.GetDirectoryName(PathFiletoCopy);
            string FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(PathFiletoCopy);
            string Extension = System.IO.Path.GetExtension(PathFiletoCopy);
            for (int i = 1; i < 51; i++)
            {
               System.IO.File.Copy(PathFiletoCopy, System.IO.Path.Combine(PathToCopy, FileNameWithoutExtension + "-" + i.ToString("D4") + Extension));
            }
