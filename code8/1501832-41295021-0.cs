           string[] ImageNames = Directory.GetFiles(@"Source-Directory\", "*.*", SearchOption.AllDirectories);
            string[] ImageItem = ImageNames.Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
            string FilePath = @"Destination.txt";
            using (var writer = new StreamWriter(FilePath))
            {
                for (int i = 1; i < ImageNames.Length - 1; i++)
                {
                    string LinkPath = ImageNames[i].ToString();
                    string PartNum = ImageItem[i - 1].ToString().Split('_').Last();
                    string LinkName = "Full Image_" + i;
                    var line = i + delimiter + PartNum + delimiter + LinkName + delimiter + LinkPath + delimiter + "Item Maintenance";
                    if (PartNum != "Thumbs")
                    {
                        writer.WriteLine(line);
                    }
                }
            }
