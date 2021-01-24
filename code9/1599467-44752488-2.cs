            foreach (IListFileItem item in result)
            {
                if (item is CloudFile)
                {
                    var cloudFile = (CloudFile)item;
                    cloudFile.FetchAttributes();
                    // You can now access metadata and properties
                    var rest = cloudFile.Metadata;
                    //cloudFile.Properties
                }
                else if (item is CloudFileDirectory)
                {
                    var cloudFileDirectory = (CloudFileDirectory)item;
                    // You can now access metadata and properties
                    cloudFileDirectory.FetchAttributes();
                   var rest = cloudFileDirectory.Metadata;
                    //cloudFileDirectory.Metadata
                    //cloudFileDirectory.Properties
                }
            }
