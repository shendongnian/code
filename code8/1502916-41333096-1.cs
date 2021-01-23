     public IEnumerable<FileObject> EnumerateImagesInPath(string folderPath, int firstAssignedID)
        {
            List<FileObject> FilesBuffer = new List<FileObject>();
            Directory.EnumerateFiles(folderPath).
                ToList().
                ForEach
                (
                    FileName => FilesBuffer.Add(new FileObject(FileName, firstAssignedID++))
                );
            foreach (FileObject File in FilesBuffer)
            {
                yield return File;
            }
        }
