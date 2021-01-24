    public static List<System.Drawing.Image> Find(string folderPath, string filenameOrPart)
        {
            List<System.Drawing.Image> imges = new List<System.Drawing.Image>();
            try
            {
                List<string> filesInFolder = Directory.GetFiles(folderPath).ToList();
                List<string> filesFound = filesInFolder.Where(f => f.Replace(folderPath, "").Contains(filenameOrPart)).ToList();
                foreach (var item in filesFound)
                {
                    int pathLen = item.Length;
                    try
                    {
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        using (System.IO.FileStream file = File.OpenRead(item))
                        {
                            byte[] bytes = new byte[file.Length];
                            int read;
                            while ((read = file.Read(bytes, 0, (int)file.Length)) > 0)
                            {
                                ms.Write(bytes, 0, read);
                            }
                            imges.Add(System.Drawing.Image.FromStream(ms));
                        }
                    }
                    catch (Exception e)
                    {
                        //dont add pic
                    }
                }
            }
            catch (Exception)
            {
                //return empty list
            }
            return imges;
        }
