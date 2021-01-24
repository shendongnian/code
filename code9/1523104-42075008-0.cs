     public static byte[] Serialize<T>(T recordObj) where T : ISpecificRecord
        {
            Log.Info("Serializing {0} object to Avro.",typeof(T));
            try
            {
                using(var ms = new MemoryStream())
                {
                    var specDatumWriter = new SpecificDatumWriter<T>(recordObj.Schema);
                    var specDataWriter = Avro.File.DataFileWriter<T>.OpenWriter(specDatumWriter, ms);
                    specDataWriter.Append(recordObj);
                    specDataWriter.Flush();
                    specDataWriter.Close();
                    return ms.ToArray();
                }
            } 
            catch(Exception ex)
            {
                Log.Error("Failed to Avro serialize object. {0}",ex);
                return null;
            }
        }
