     using (FileStream fileStream = System.IO.File.Create(oldFilePath))
                    {
                        await item.CopyToAsync(fileStream);
                    }
     var newFileName = someCustomString + fileName;
     var newFilePath = folderPath + newFileName;
     System.IO.File.Copy(oldFilePath, newFilePath, true);
     System.IO.File.Delete(oldFilePath);
