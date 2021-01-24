    string[] files = new string[]{ @"E:\myfile1.txt", @"E:\myfile2.txt", @"E:\myfile3.txt" };
            string fileContent = string.Empty;
            foreach (var fileName in files)
            {
                using (System.IO.StreamReader Reader = new System.IO.StreamReader(fileName))
                {
                    fileContent += Reader.ReadToEnd();
                }
            }
            fileContent = fileContent.Replace(',', '.');
            System.IO.File.WriteAllText(@"E:\myfile.txt", fileContent);
