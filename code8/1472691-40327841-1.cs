            string PathFiletoCopy = @"C:\temp\out.csv";
            string Extension = System.IO.Path.GetExtension(PathFiletoCopy);
            string PartialNewPathFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(PathFiletoCopy), System.IO.Path.GetFileNameWithoutExtension(PathFiletoCopy) + "-");
            for (int i = 1; i < 11; i++)
                System.IO.File.Copy(PathFiletoCopy, PartialNewPathFile + i.ToString("D4") + Extension);
