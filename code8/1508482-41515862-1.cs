        public void write(string Dir, XmlWriter writer)
        {
            try
            {
                writer.WriteStartElement("Folders");
                foreach (string directoryPath in Directory.GetDirectories(Dir))
                {
                    string directoryName = Path.GetFileName(directoryPath);
                    writer.WriteStartElement("Folder");
                    writer.WriteAttributeString("Name", directoryName);
                    foreach (string fileName in Directory.GetFiles(directoryPath))
                    {
                        FileInfo fi = new FileInfo(fileName);
                        writer.WriteStartElement("File");
                        writer.WriteAttributeString("Name", fileName);
                        writer.WriteValue(fi.Length);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    write(directoryPath, writer);
                }
                writer.WriteEndElement();
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
