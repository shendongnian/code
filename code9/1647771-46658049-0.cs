           foreach (var file in dir.EnumerateFiles())
            {
                string temppath = Path.Combine(destDirName, file.Name);
                using (FileStream reader = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream writer = new FileStream(temppath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        await reader.CopyToAsync(writer);
                      
                    }
                   File.SetLastWriteTime(temppath, file.LastWriteTime);
                }
            }
