            // get bytes from SFTP server
            byte[] content = _sftpClient.Download(fileName);
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;
                settings.CheckCharacters = false;
                using(var memoryStream = new MemoryStream(content))
                using (XmlReader xr = XmlReader.Create(memoryStream, settings))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Person));
                    if (ser.CanDeserialize(xr))
                    {
                        Person person = ser.Deserialize(xr) as Person;
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: {0} - {1}", exc.GetType().Name, exc.Message);
            }
