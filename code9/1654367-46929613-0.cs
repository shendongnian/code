        public void SaveMetaData(string fileName, string container, string key, string value)
        {
            try
            {
                var blob = GetBlobReference(fileName, container);
                blob.FetchAttributes();
                blob.Metadata.Add(key, value);
                blob.SetMetadata();//This line of code will save the metadata.
            }
            catch (Exception e)
            {
                _logger.Error(e,
                    "An Exception occured  with blobname = {0} and blobcontainer = {1}", fileName,
                    container);
            }
        }
