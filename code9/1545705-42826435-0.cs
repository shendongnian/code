        public static Image GetDiagramImage(this Project projectInterface, string eaDiagramGuid, ApplicationLogger _logger)
        {
            Image diagramImage;
            try
            {
                var diagramByGuid = projectInterface.GUIDtoXML(eaDiagramGuid);
                string tempFilename = string.Format("{0}{1}{2}", Path.GetTempPath(), Guid.NewGuid().ToString(), ".png");
                bool imageToFileSuccess = projectInterface.PutDiagramImageToFile(diagramByGuid, tempFilename, FileExtensionByName);
                if (imageToFileSuccess)
                {
                    using (var imageStream = new MemoryStream(File.ReadAllBytes(tempFilename)))
                    {
                        diagramImage = Image.FromStream(imageStream);
                    }
                    File.Delete(tempFilename);
                }
                else
                {
                    throw new Exception(string.Format("Image to file exprot fail {0}", projectInterface.GetLastError()));
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return diagramImage;
        }
