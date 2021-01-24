     using (FileStream fileStream = System.IO.File.Create(oldFilePath))
                    {
                        await item.CopyToAsync(fileStream);
                    }
     System.IO.File.Copy(oldFilePath, newFilePath, true);
     System.IO.File.Delete(oldFilePath);
