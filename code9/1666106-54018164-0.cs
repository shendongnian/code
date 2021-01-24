              /// <summary>
             ///Get data from a binary file.
            /// </summary>
           /// <param name="filename"></param>
          /// <param name="path"></param>
         /// <returns>Null if no object is found </returns>
            public static T GetData<T>(string filename, string path)
            {
                //Path is empty.
                if (string.IsNullOrEmpty(path)) throw new NullReferenceException("Path can not be null or empty");
    
                //file is empty.
                if (string.IsNullOrEmpty(filename)) throw new NullReferenceException("File name can not be null or empty.");
    
    
                //Storage path
                var storagePath = Path.Combine(path, filename);
    
                //check file not exist
                if (!File.Exists(storagePath))
                    throw new NullReferenceException("No file with the name " + filename + "at location" + storagePath);
                else
                    try
                    {
                        //create new binary formatter .
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        //Read the file.
                        using (FileStream fileStream = File.Open(storagePath, FileMode.Open))
                        {
                            //result .
                            var result = binaryFormatter.Deserialize(fileStream);
                            //Set file stream to zero .
                            //to avoid Exception: FailedSystem.IO.EndOfStreamException: 
                            //Failed to read past end of stream.
                            fileStream.Position = 0;
                            //Check if casting is possible and raise error accordin to that .
                            return (T)Convert.ChangeType(binaryFormatter.Deserialize(fileStream), typeof(T));
    
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Failed" + ex);
                    }
            }
