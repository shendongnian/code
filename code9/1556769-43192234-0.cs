                String[] allfiles = Directory.GetFiles(imagePath, "*.*", SearchOption.AllDirectories);
                //List<Image> allImages = new List<Image>();
                List<Byte[]> allImagesBytes = new List<Byte[]>();
                foreach (string file in allfiles)
                {
                    using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        if (IsImage(stream))
                        {
                            Console.Clear();
                            Console.Write(allImagesBytes.Count());
                            //allImages.Add(Image.FromStream(stream));
                            //allImages.Add(Image.FromFile(file));
                            allImagesBytes.Add(File.ReadAllBytes(file));
                        }
                    }
                }
