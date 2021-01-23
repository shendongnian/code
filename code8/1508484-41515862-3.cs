        public void write(string Dir, XmlWriter writer)
        {
            try
            {
                writer.WriteStartElement("Folders");
                foreach (string directoryPath in Directory.GetDirectories(Dir))
                {
                    string directoryName = Path.GetFileName(directoryPath);
                    writer.WriteStartElement(XmlConvert.EncodeLocalName(directoryName));
                    foreach (string fileName in Directory.GetFiles(directoryPath))
                    {
                        FileInfo fi = new FileInfo(fileName);
                        writer.WriteElementString(XmlConvert.EncodeLocalName(fileName), XmlConvert.ToString(fi.Length));
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
