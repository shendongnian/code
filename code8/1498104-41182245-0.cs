                // grab the files and locations out of the xml file.
                string[] xmlFiles = xdoc.Descendants("ItemGroup")
                    .Descendants("Build")
                    .Select(s => s.Attribute("Include"))
                    .Select(s => s.Value)
                    .Where(s => s.Contains("Stored Procedures") || s.Contains("Tables") || s.Contains("Functions") || s.Contains("Views"))
                    .ToArray();
                for (int i = 0; i < xmlFiles.Length; i++)
                {
                    string fileXml = xmlFiles[i];
                    // get just the file name
                    string path = fileXml;
                    string[] pathArr = path.Split('\\');
                    string[] fileArr = pathArr.Last().Split('\\');
                    string fileNameXml = fileArr.Last().ToString();
                    String[] filesOnDrive = Directory.GetFiles(_filePath, fileNameXml, SearchOption.AllDirectories);
                    for (int j = 0; j == filesOnDrive.Length; j++)
                    {
                        Console.WriteLine("no file = " + fileNameXml);
                    }
                }
