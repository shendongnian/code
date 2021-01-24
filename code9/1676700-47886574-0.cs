    #region Documents
            private void AddDocument()
            {
                Console.WriteLine(string.Format("\nCalling AddDocument()..."));
                using (FileStream fs = File.OpenRead(_filepathToIngest))
                {
                    var result = _discovery.AddDocument(_createdEnvironmentId, _createdCollectionId, _createdConfigurationId, fs as Stream, _metadata);
    
                    if (result != null)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
                        _createdDocumentId = result.DocumentId;
                    }
                    else
                    {
                        Console.WriteLine("result is null.");
                    }
                }
            }
